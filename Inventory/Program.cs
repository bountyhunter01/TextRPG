using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

partial class Item
{
    string mName;
    int mGold;

    public string Name
    {
        get
        {
            return mName;
        }
        set
        {
            mName = value;
        }
    }
    public int Gold
    {
        get
        {
            return mGold;
        }
        set
        {
            mGold = value;
        }
    }
    public Item(string Name2 ,int Gold2 )
    {
        Name = Name2;
        Gold = Gold2;
    }

}

//아이템을 담아두는 인벤토리
partial class Inven
{
    int SelectIndex=0;
    
    Item[] ArrItem;
    int ItemX;
    //인벤토리를 new하려면
    //int x와int y를 넣어주는 방법밖에없다
    public Inven(int x, int y)
    {   //초보 프로그래머가장주의할것
        //방어코드는 선택 아닌 필수
        //잘못쓰기도 힘들게 만들어라
        if (1 > x)
        {
            x = 1;
        }
        if (1 > y)
        {
            y = 1;
            //인벤이 1보다 작으면 안되니까
        }
        ItemX = x;
        ArrItem = new Item[(x * y)];
        
    }
    //인벤은 아이템이 필요함
    public void ItemIn(Item _item)
    {
       // int Index = 0;
        for (int i = 0; i <ArrItem.Length; i++)
        {
            if (null == ArrItem[i])
            {
                ArrItem[i] = _item;
                return;
            }

        }

    }
    public void ohterItemIn(Item _item , int Order)
    {
        if (null != ArrItem[Order])
        {
            return;
        }
        
        ArrItem[Order] = _item;

    }
    public void MoveSelection(ConsoleKey key)
    {
        switch (key) 
        {
            case ConsoleKey.A:
                if (SelectIndex % ItemX != 0) SelectIndex--; // Move left
                break;
            case ConsoleKey.D:
                if (SelectIndex % ItemX != ItemX - 1) SelectIndex++; // Move right
                break;
            case ConsoleKey.W:
                if (SelectIndex - ItemX >= 0) SelectIndex -= ItemX; // Move up
                break;
            case ConsoleKey.S:
                if (SelectIndex + ItemX < ArrItem.Length) SelectIndex += ItemX; // Move down
                break;
        }
    }
    public void Print()
    {
        for (int i = 0; i < ArrItem.Length; i++)
        {
            //15개의 아이템을 가질수 있는인벤
            if (SelectIndex ==i)//0번째
            {
                    Console.Write("★");   
            }
           
            else if (null == ArrItem[i])
            {
               // 비어 있는 슬롯을 나타냄
                Console.Write("□");//윈도우 이모티콘이 안먹힘
            }
            else
            { // 아이템이 있는 슬롯을 나타냄
                Console.Write("■");
            }
            // ItemX (가로 크기)에 도달했을 때 줄바꿈
            if (0 == (i + 1) % ItemX)
            {
                Console.WriteLine();
            }
        }
        Console.WriteLine("");
        //아이템 버리기 아이템 선택 만들기
        Console.WriteLine("현재 선택한 아이템");
        if (ArrItem[SelectIndex] != null)
        {
        Console.WriteLine("이름: " + ArrItem[SelectIndex].Name);
        Console.WriteLine("가격: " + ArrItem[SelectIndex].Gold+"골드");

        }
        else
        {
            Console.WriteLine("아이템이 없습니다");
        }
     
        
    }
    public void DiscardItem()
    {
        if (ArrItem[SelectIndex] != null)
        {
            Console.WriteLine(ArrItem[SelectIndex].Name + " 아이템을 버렸습니다.");
            ArrItem[SelectIndex] = null;
        }
        else
        {
            Console.WriteLine("버릴 아이템이 없습니다.");
        }
    }
    static void Main(string[] args)
    {   //*****
        //*****
        //*****
        //Inven Newinven2 = null;
        //Newinven2.ohterItemIn(null, 10);
        Inven NewINven = new Inven(5, 3);
       // Item MyItem = ; new Item("녹슨검", 100)
        NewINven.ItemIn(new Item("녹슨검", 100));
        NewINven.ItemIn(new Item("녹슨갑옷", 50));

        
        NewINven.ohterItemIn(new Item("포션", 10),4);
        while (true)
        {
            Console.Clear();
            NewINven.Print();
            Console.WriteLine("\nAWSD로 이동 , E로 아이템버리기");
            var key= Console.ReadKey().Key;
            if (key == ConsoleKey.E)
            {
                NewINven.DiscardItem();
                Console.ReadKey();
            }
            else
            {
                NewINven.MoveSelection(key);
            }
          
        }

    }
}




