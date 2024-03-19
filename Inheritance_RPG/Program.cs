using System;

class FightUnit
{   //c#에서는 상속이란 오직 하나만 가능
    //클래스상속이 여러개인 언어 있지만 c#은 아님 

    protected int AT = 10;//자식 까지만
    protected int HP = 100;
   
    public void Damage(FightUnit dmg)
    {

    }
}

class Playrer : FightUnit
{
    int LV = 1;
    void Heal()
    {
        HP = 100;
    }

}
class Monster : FightUnit
{

}

namespace Inheritance_RPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Playrer playrer = new Playrer();
            Monster monster = new Monster();
            playrer.Damage(monster);
            Console.ReadKey();
        }
    }
}
