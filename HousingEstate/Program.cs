﻿using System;

namespace HousingEstate
{
    class Program
    {
        static void Main(string[] args)
        {
            var he = new HousingEstate();
            while (true)
            {
                he.MovePerson();
                while (true)
                {
                    he.Show();
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
