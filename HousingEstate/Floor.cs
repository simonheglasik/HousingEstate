using System;
using System.Collections.Generic;
using System.Text;

namespace HousingEstate
{
    class Floor
    {
        public Floor(int number , int entrance,int block)
        {
            Enter = entrance;
            Number = number;
            Block = block;
        }
        public int Enter { get; }
        public int Number { get; }
        public int Block { get; }
    }
}
