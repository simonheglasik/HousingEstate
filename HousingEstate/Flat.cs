using System;
using System.Collections.Generic;
using System.Text;

namespace HousingEstate
{
    class Flat
    {
        public Flat(int number, int floor , int entrance , int block)
        {
            Floor = floor;
            Number = number;
            Entrance = entrance;
            Block = block;
        }
        public int Floor { get; }
        public int Number { get; }
        public int Entrance { get; }
        public int Block { get; }
    }
}
