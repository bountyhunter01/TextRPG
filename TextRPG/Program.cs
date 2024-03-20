using System;
using System.Threading;

class Player
{//멤버변수는 무조건 프라이빗
    protected string Name = "플레이어";
    protected int AT = 20;
    protected int HP = 50;
    protected int MAXHP = 100;

    public int GetAttackStrength()
    {
        return AT;
    }

    public void Status()
    {
        Console.Write(Name);
        Console.WriteLine("의 능력치--------------------------------");
        Console.Write("공격력: ");
        Console.WriteLine(AT);


        Console.Write("체력: ");
        Console.Write(HP);
        Console.Write("/");
        Console.WriteLine(MAXHP);
        Console.WriteLine("----------------------------------------");
    }


    public void PrintHP()
    {
        Console.WriteLine("");
        Console.Write("치료되었습니다. 현재 플레이어의 HP는 ");
        Console.Write(HP);
        Console.WriteLine("입니다");

    }
    public void Heal(/*player this*/)
    {
        //함수는 작은게 많을 수록 좋다
        if (HP >= MAXHP)
        {
            Console.WriteLine("");//이거 귀찮으면 그냥 함수로 만들어도 됌
            Console.WriteLine("체력이 이미 최대입니다");
            Console.ReadKey();
        }
        else
        {//-------------이부분은 수정이 조금 필요하다
            Console.WriteLine("체력이 부족합니다 체력을 치료하시오");
            this.HP = MAXHP;
            PrintHP();
            Console.ReadKey();
        }
        return;

    }
    public void Upgrade()
    {
        if (AT >= 20)
        {
            AT += 10;
            Console.WriteLine("공격력이 " + AT + "이 되었습니다");
            Console.ReadKey();
        }
        if (AT >= 100)
        {
            AT -= 10;
            Console.WriteLine("공격력이 이미 최대치입니다");
            Console.ReadKey();
        }
        return;
    }
    public bool IsDeath()
    {
        return HP <= 0;
    }
    // 플레이어가 데미지를 받는 메서드
    public void Damage(int damage)
    {
        Console.Write(Name);
        Console.WriteLine("가 " + damage + "의 데미지를 입었습니다.");
        HP -= damage;
        if (HP < 0) HP = 0; // 체력이 음수가 되지 않도록 처리
    }
}


class Enemy
{//멤버변수는 무조건 프라이빗
    protected string Name = "적";
    protected int AT = 30;
    protected int HP = 100;
    protected int MAXHP = 100;

    public int getAttack()
    {
        return AT;
    }
    public void SetName(string name)
    {
        name = name.ToLower();
    }

    public void Status()
    {
        Console.Write(Name);
        Console.WriteLine("의 능력치--------------------------------");
        Console.Write("공격력: ");
        Console.WriteLine(AT);


        Console.Write("체력: ");
        Console.Write(HP);
        Console.Write("/");
        Console.WriteLine(MAXHP);
        Console.WriteLine("----------------------------------------");
    }

    public bool IsDeath()
    {
        return HP <= 0;
    }
    // 적이 데미지를 받는 메서드
    public void Damage(int damage)
    {
        Console.Write(Name);
        Console.WriteLine("이 " + damage + "의 데미지를 입었습니다.");
        HP -= damage;
        if (HP < 0) HP = 0; // 체력이 음수가 되지 않도록 처리
    }
}


class Monster
{
    protected string Name = "몬스터";
    protected int AT = 10;
    protected int HP = 150;
    protected int MAXHP = 150;

    public int getAttack()
    {
        return AT;
    }
    public bool IsDeath()
    {
        return HP <= 0;
    }
    public void SetName(string name)
    {
        name = name.ToLower();
    }
    public void Status()
    {
        Console.Write(Name);
        Console.WriteLine("의 능력치--------------------------------");
        Console.Write("공격력: ");
        Console.WriteLine(AT);


        Console.Write("체력: ");
        Console.Write(HP);
        Console.Write("/");
        Console.WriteLine(MAXHP);
        Console.WriteLine("----------------------------------------");
    }
    public void Damage(int damage)
    {
        Console.Write(Name);
        Console.WriteLine("가 " + damage + "의 데미지를 입었습니다.");
        HP -= damage;
        if (HP < 0) HP = 0; // 몬스터의 체력이 음수가 되지 않도록 처리
    }
}
//에러나 잘못된선택에 관한것도 만든다
enum SELECTION_TYPE
{
    TOWN,
    BATTLE,
    NONE_TYPE,
    EXIT
}

namespace TextRPG
{

    internal class Program
    {

        static SELECTION_TYPE StartSelect()
        {
            Console.Clear();//지워지는거 
            Console.WriteLine("1. 마을");
            Console.WriteLine("2. 전쟁터");
            Console.WriteLine("3. 게임종료");
            Console.WriteLine("어디로 이동하시겠습니까?");

            ConsoleKeyInfo ckl = Console.ReadKey();
            Console.WriteLine("");

            switch (ckl.Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("마을로 이동합니다!");
                    Console.ReadKey();
                    return SELECTION_TYPE.TOWN;
                case ConsoleKey.D2:
                    Console.WriteLine("전쟁터로 이동합니다!");
                    Console.ReadKey();//지우지 말고 값을 기다려
                    return SELECTION_TYPE.BATTLE;
                case ConsoleKey.D3:
                    Console.WriteLine("게임을 종료합니다");
                    Console.ReadKey();
                    Environment.Exit(0);
                    return SELECTION_TYPE.EXIT;
                default:
                    Console.WriteLine("잘못된 선택입니다....");
                    Console.ReadKey();
                    return SELECTION_TYPE.NONE_TYPE;
            }


        }
        static SELECTION_TYPE Town(Player player1)
        {
            while (true)
            {
                Console.Clear();
                player1.Status();
                Console.WriteLine("마을에서 무슨일을 하시겠습니까?");
                Console.WriteLine("1.체력을 회복한다");
                Console.WriteLine("2.무기를 강화한다");
                Console.WriteLine("3.마을을 나간다");

                //ConsoleKeyInfo ckl = Console.ReadKey(); 방식은 취향차이
                ConsoleKey ckl = Console.ReadKey().Key;
                switch (ckl)//Console.ReadKey().Key;
                {
                    case ConsoleKey.D1:
                        player1.Heal();
                        break;
                    case ConsoleKey.D2:
                        player1.Upgrade();
                        break;
                    case ConsoleKey.D3:
                        return SELECTION_TYPE.NONE_TYPE;
                    default:
                        break;
                }
            }
        }
        static SELECTION_TYPE FightMonster(Player player, Monster monster)
        {
            Random random = new Random();

            while (!monster.IsDeath() && !player.IsDeath())
            {
                Console.Clear();
                player.Status();
                monster.Status();

                

                if (!monster.IsDeath())
                {
                    // 플레이어가 몬스터를 랜덤한 데미지로 공격
                    int damageToMonster = random.Next(1, player.GetAttackStrength() + 1);
                    Console.WriteLine("플레이어가 몬스터에게 " + damageToMonster + "의 데미지를 줍니다.");
                    monster.Damage(damageToMonster);
                    Console.WriteLine("");
                    // 몬스터가 플레이어를 랜덤한 데미지로 공격
                    int damageToPlayer = random.Next(1, monster.getAttack() + 1);
                    Console.WriteLine("몬스터가 플레이어에게 " + damageToPlayer + "의 데미지를 줍니다.");
                    player.Damage(damageToPlayer);
                }

                if (player.IsDeath() || monster.IsDeath())
                {
                    Console.WriteLine("배틀이 종료 되었습니다");
                    if (monster.IsDeath())
                    {
                        Console.WriteLine("플레이어가 승리했습니다");
                    }
                    else
                    {
                        Console.WriteLine("몬스터가 승리했습니다");
                    }
                    Console.ReadKey();
                    return SELECTION_TYPE.TOWN;
                }
                Thread.Sleep(1000);
            }
            return SELECTION_TYPE.NONE_TYPE;
        }

        static SELECTION_TYPE FightEnemy(Player player, Enemy enemy)
        {
            Random random = new Random();

            while (!enemy.IsDeath() && !player.IsDeath())
            {
                Console.Clear();
                player.Status();
                enemy.Status();



                if (!enemy.IsDeath())
                {
                    // 플레이어가 몬스터를 랜덤한 데미지로 공격
                    int damageToenemy = random.Next(1, player.GetAttackStrength() + 1);
                    Console.WriteLine("플레이어가 적에게 " + damageToenemy + "의 데미지를 줍니다.");
                    enemy.Damage(damageToenemy);
                    Console.WriteLine("");
                    // 몬스터가 플레이어를 랜덤한 데미지로 공격
                    int damageToPlayer = random.Next(1, enemy.getAttack() + 1);
                    Console.WriteLine("적이 플레이어에게 " + damageToPlayer + "의 데미지를 줍니다.");
                    player.Damage(damageToPlayer);
                }

                if (player.IsDeath() || enemy.IsDeath())
                {
                    Console.WriteLine("배틀이 종료 되었습니다");
                    if (enemy.IsDeath())
                    {
                        Console.WriteLine("플레이어가 승리했습니다");
                    }
                    else
                    {
                        Console.WriteLine("적이 승리했습니다");
                    }
                    Console.ReadKey();
                    return SELECTION_TYPE.TOWN;
                }
                Thread.Sleep(1000);//속도 조절하는 매서드
            }
            return SELECTION_TYPE.NONE_TYPE;
        }

        static SELECTION_TYPE Battle(Player player2)
        {
            Monster Newmonster = new Monster();
            Enemy enemy = new Enemy();  
            while (false == Newmonster.IsDeath() && false == player2.IsDeath())
            {
                Console.Clear();
                player2.Status();


                Console.WriteLine("전쟁터에서 무슨일을 하시겠습니까?");
                Console.WriteLine("1.플레이어와 싸운다");
                Console.WriteLine("2.몬스터와 싸운다");
                Console.WriteLine("3.전쟁터를 떠난다");

                //ConsoleKeyInfo ckl = Console.ReadKey(); 방식은 취향차이
                ConsoleKey ckl = Console.ReadKey().Key;
                switch (ckl)//Console.ReadKey().Key;
                {
                    case ConsoleKey.D1:
                        FightEnemy(player2, enemy);
                        break;
                    case ConsoleKey.D2:
                        FightMonster(player2, Newmonster);
                        break;
                    case ConsoleKey.D3:
                        return SELECTION_TYPE.NONE_TYPE;
                    default:
                        break;
                }

            }
            if(!player2.IsDeath())
            {
                return SELECTION_TYPE.BATTLE;
            }if(player2.IsDeath())
            {
            return SELECTION_TYPE.TOWN;
            }
            return SELECTION_TYPE.NONE_TYPE;
        }



        static void Main(string[] args)
        {   //함수의 분기
            //함수의 통합

            //외부에서 쓰게할려면 1.static 2.인스턴스 값 지정
            Player Newplayer = new Player();
            SELECTION_TYPE seleckCheck = SELECTION_TYPE.NONE_TYPE;
            while (true)
            {

                switch (seleckCheck)
                {

                    case SELECTION_TYPE.TOWN:
                        seleckCheck = Town(Newplayer);
                        break;
                    case SELECTION_TYPE.BATTLE:
                        seleckCheck = Battle(Newplayer);
                        break;
                    case SELECTION_TYPE.NONE_TYPE:
                        seleckCheck = StartSelect();
                        break;
                    default:
                        break;
                }
            }

        }


    }

}
