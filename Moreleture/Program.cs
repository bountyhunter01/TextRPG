using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//namespace Morepartial //별명, 경로에 있는 파일이름


internal class Program
    {
        static void Main(string[] args)
        {
        Player player = new Player("밤양갱",100,10);
        player.DamageIS(5);
        player.DamageIS(5,3);
        player.ATT(player);
        Console.ReadKey();
        }
    }

