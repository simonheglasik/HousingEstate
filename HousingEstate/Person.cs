﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HousingEstate
{
    class Person
    {
        public int Age { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public int Flat { get; set; }
        public int Floor { get; set; }
        public int Entrance { get; set; }
        public int Block { get; set; }
        public Person( string firstname , string lastname , int age , int flat , int floor,int entrance ,int block)
        {
            FirstName = firstname;
            LastName = lastname;
            Age = age;
            Flat = flat;
            Floor = floor;
            Entrance = entrance;
            Block = block;
        }
        public void Move(string blocks , string entrances , string floors , string flats)
        {
            Console.WriteLine(blocks);
            Block = int.Parse(Console.ReadLine());
            Console.WriteLine(entrances);
            Entrance = int.Parse(Console.ReadLine());
            Console.WriteLine(floors);
            Floor = int.Parse(Console.ReadLine());
            Console.WriteLine(flats);
            Flat = int.Parse(Console.ReadLine());
        }
    }
}

