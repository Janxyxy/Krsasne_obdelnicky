using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Krsasne_obdelnicky
{
    internal class Application
    {
        public List<Obdelniky> ObdelnikyList;

        public void Start()
        {
            ObdelnikyList = new List<Obdelniky>();
            while (true)
            {

                Console.WriteLine("Zadej cmd: add, showlast, showall, showallreversed, show(index)");
                string cmd = Console.ReadLine().ToLower();

                switch (cmd)
                {
                    case "add":
                        Pridej();
                        break;
                    case "showlast":
                        Showlast();
                        break;
                    case "show":
                        Show();
                        break;
                    case "showall":
                        Showall();
                        break;
                    case "showallreversed":
                        Showallreversed();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Neznám příkaz.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
        }

        public void Pridej()
        {
            int x;
            while (true)
            {
                Console.WriteLine("Zadej x (3 - 20): ");
                Console.ForegroundColor = ConsoleColor.White;
                if (int.TryParse(Console.ReadLine(), out x) && x >= 3 && x <= 20)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
            }

            int y;
            while (true)
            {

                Console.WriteLine("Zadej y (5 - 15): ");
                Console.ForegroundColor = ConsoleColor.White;
                if (int.TryParse(Console.ReadLine(), out y) && y >= 5 && y <= 15)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;

                }
            }
            Console.WriteLine("Zadej symbol: ");
            string charakterstring = (Console.ReadLine());
            char charakter = charakterstring[0];

            Zadejbarvu();

            int colorindex;
            while (true)
            {

                Console.WriteLine("Zadej index barvy (0-15): ");
                Console.ForegroundColor = ConsoleColor.White;
                if (int.TryParse(Console.ReadLine(), out colorindex) && colorindex >= 0 && colorindex <= 15)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;

                }
            }
            ConsoleColor barva = (ConsoleColor)colorindex;

            Obdelniky obdelnik = new Obdelniky(x, y, charakter, barva);
            this.ObdelnikyList.Add(obdelnik);
        }
        public void Zadejbarvu()
        {
            for (int i = 0; i < 16; i++)
            {
                if (i < 7)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.BackgroundColor = (ConsoleColor)i;


                Console.Write(((ConsoleColor)i).ToString());
                Console.Write(" " + i);
                Console.WriteLine();
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

        }
        public void Showall()
        {
            if (ObdelnikyList.Count > 0)
            {
                for (int index = 0; index < ObdelnikyList.Count; index++)
                {
                    Obdelniky obdelink = ObdelnikyList[index];

                    Vypsat(obdelink);

                }
            }
            else
            {
                Spatne();
            }

        }
        public void Showallreversed()
        {
            if (ObdelnikyList.Count > 0)
            {
                for (int index = ObdelnikyList.Count; index > 0; index--)
                {
                    Obdelniky obdelink = ObdelnikyList[index - 1];

                    Vypsat(obdelink);

                }
            }
            else
            {
                Spatne();
            }

        }
        public void Show()
        {
            if (ObdelnikyList.Count > 0)
            {
                for (int i = 0; i < ObdelnikyList.Count; i++)
                {
                    Obdelniky obdelinkvse = ObdelnikyList[i];
                    Console.ForegroundColor = obdelinkvse.barva;
                    Console.WriteLine("Index {0} Obdelnik: x={1}, y={2}, symbol={3}, barva={4}", i, obdelinkvse.x, obdelinkvse.y, obdelinkvse.charakter, obdelinkvse.barva);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                int index;
                while (true)
                {
                    Console.WriteLine("Zadej index obdelniku (0-{0}): ", ObdelnikyList.Count - 1);
                    Console.ForegroundColor = ConsoleColor.White;
                    if (int.TryParse(Console.ReadLine(), out index) && index >= 0 && index <= ObdelnikyList.Count - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                }
                Obdelniky obdelink = ObdelnikyList[index];
                Console.ForegroundColor = obdelink.barva;

                Vypsat(obdelink);

            }
            else
            {
                Spatne();
            }
        }
        public void Showlast()
        {
            if (ObdelnikyList.Count > 0)
            {
                Obdelniky obdelnik = ObdelnikyList[ObdelnikyList.Count - 1];
                Console.ForegroundColor = obdelnik.barva;

                Vypsat(obdelnik);
            }
            else
            {
                Spatne();
            }
        }
        public void Vypsat(Obdelniky obdelink)
        {
            Console.ForegroundColor = obdelink.barva;
            for (int j = 0; j < obdelink.x; j++)
            {
                Console.Write(obdelink.charakter);

            }
            for (int i = 0; i < obdelink.y - 2; i++)
            {
                Console.WriteLine();
                if (obdelink.y > 1)
                    Console.Write(obdelink.charakter);
                for (int j = 0; j < obdelink.x - 2; j++)
                {
                    Console.Write(" ");
                }
                Console.Write(obdelink.charakter);

            }
            Console.WriteLine();

            for (int i = 0; i < obdelink.x; i++)
            {
                Console.Write(obdelink.charakter);

            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void Spatne()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Ještě jsi nepřidal žádný obdelník!");
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}   