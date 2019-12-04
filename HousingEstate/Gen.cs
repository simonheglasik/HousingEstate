using System;
using System.Collections.Generic;
using System.Text;

namespace HousingEstate
{
    class Gen
    {
        public Person CreatePerson(int blocks, int entrances, int floors, int flats)
        {
            var firstanames = new List<string> { "Simon", "Šimon", "Martin", "Peter", "Jozef", "Martin", "Matej", "Domink", "Juraj", "Lubomir", "Erik", "Milan", "Vladimir", "Roman", "Tomaš", "Marek", "Filip", "Marko", "Matuš", "Daniela", "Jana", "Fero", "Lucia", "Jan", "Silvia", "Ivan", "Zuzana", "Maroš", "Dominika" };
            var lastnames = new List<string> { "Nemec", "Mokry", "Rakusan", "Suchy", "American", "Rus", "Stary", "Cech", "Madar", "Ukrajinec", "Francuz", "Kniha", "Novy" };
            Random rnd = new Random();
            return new Person(firstanames[rnd.Next(0, firstanames.Count)], lastnames[rnd.Next(1, lastnames.Count)], rnd.Next(1, 100), rnd.Next(1, flats), rnd.Next(1, floors), rnd.Next(1, entrances), rnd.Next(1, blocks));
        }
    }
}
