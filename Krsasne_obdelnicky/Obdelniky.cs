using System;
using System.Collections.Generic;

namespace Krsasne_obdelnicky
{
    internal class Obdelniky
    {
        public int x;
        public int y;
        public char charakter;
        public ConsoleColor barva;


        

        public Obdelniky(int x, int y,char charakter, ConsoleColor barva)
        {
            this.x = x;
            this.y = y;
            this.charakter = charakter;
            this.barva = barva;
        }
    }

    
}
