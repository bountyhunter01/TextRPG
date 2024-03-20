using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

partial class Player // partiald 따로 있어도 합치게 만들어줌
{
    string Name = "EHCO";
    int HP =100;
    int AT = 10;
    public Player(string Name, int HP, int AT)
    {   
        this.Name=Name;
        this.HP = HP;
        this.AT = AT;
    }
    public void DamageIS(int damage)//기본 데미지
    {
       HP -= damage;
        Console.WriteLine("플레이어가데미지 입음 "+ HP+"남았다");
    }
    //오버로깅
    public void DamageIS(int damage , int type)//타입에 따라 들어가는 데미지가 다름
    {
        HP -= (damage + type);
        Console.WriteLine("플레이어가"+damage+"랑"+type+"데미지를 더받았다 남은"+HP+"이다");
    }
    public void ATT(Player player)
    {

        Console.WriteLine(Name+"이 "+player.AT+"만큼 공격을 받았다");
        HP-= player.AT;
    }
    interface Quest
    {
        void Talk(Quest otherQuest);
        
    }

    class NPC :Player
    {
        public NPC(string Name, int HP, int AT)
        {
            this.AT= AT;
            this.Name = Name;
            this.HP = HP;
        }
    }
} 