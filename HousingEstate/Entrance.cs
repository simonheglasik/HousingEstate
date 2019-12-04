using System;
using System.Collections.Generic;
using System.Text;

namespace HousingEstate
{
    class Entrance
    {
        public int NumberOfEntrance { get; }
        public Entrance(int numberOfEntrance , int block)
        {
            Block = block;
            Number = numberOfEntrance;
        }
        public int Block { get; }
        public int Number { get; }
    }
}
