using System;

class Player
{//멤버변수는 무조건 프라이빗
   protected string Name = "플레이어";
    protected int AT = 20;
    protected int HP = 50;
    protected int MAXHP = 100;


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
        {
            Console.WriteLine("체력이 부족합니다 체력을 치료하시오");
            this.HP = MAXHP;
            PrintHP();
            Console.ReadKey();
        }
        return;

    }
    public bool IsDeath()
    {
        return HP <= 0;
    }
}
class Monster
{
    protected string Name = "몬스터";
    protected int AT = 10;
    protected int HP = 50;
    protected int MAXHP = 150;

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
        static void Town(Player player1)
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
                        break;
                    case ConsoleKey.D3:
                        return;
                    default:
                        break;
                }
            }
        }
       

        static void Battle(Player player2)
        {
            Monster Newmonster = new Monster();
            while (Newmonster.IsDeath() || player2.IsDeath())
            {
                Console.Clear();
                player2.Status();
                Console.WriteLine("");
                Newmonster.Status();
                Console.ReadKey();

                Console.WriteLine("전쟁터에서 무슨일을 하시겠습니까?");
                Console.WriteLine("1.플레이어와 싸운다");
                Console.WriteLine("2.몬스터와 싸운다");
                Console.WriteLine("3.전쟁터를 떠난다");

                //ConsoleKeyInfo ckl = Console.ReadKey(); 방식은 취향차이
                ConsoleKey ckl = Console.ReadKey().Key;
                switch (ckl)//Console.ReadKey().Key;
                {
                    case ConsoleKey.D1:

                        break;
                    case ConsoleKey.D2:
                        break;
                    case ConsoleKey.D3:
                        return;
                    default:
                        break;
                }

            }
        }



        static void Main(string[] args)
        {   //함수의 분기
            //함수의 통합

            //외부에서 쓰게할려면 1.static 2.인스턴스 값 지정
            Player Newplayer = new Player();
            while (true)
            {
                SELECTION_TYPE seleckCheck = StartSelect();
                switch (seleckCheck)
                {
                    case SELECTION_TYPE.TOWN:
                        Town(Newplayer);
                        break;
                    case SELECTION_TYPE.BATTLE:
                        Battle(Newplayer);
                        break;
                    case SELECTION_TYPE.NONE_TYPE:
                        break;
                    default:
                        break;
                }
            }

        }


    }

}
