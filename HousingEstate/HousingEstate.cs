﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace HousingEstate
{
    class HousingEstate
    {
        public List<Entrance> entrances;
        public List<Floor> floors;
        public List<Flat> flats;
        public List<Person> persons;
        public List<BlockOfFlats> blocks;
        public HousingEstate()
        {
            var gen = new Gen();
            entrances = new List<Entrance>();
            floors = new List<Floor>();
            flats = new List<Flat>();
            persons = new List<Person>();
            blocks = new List<BlockOfFlats>
            {
                new BlockOfFlats(1),
                new BlockOfFlats(2)
            };
            for (int i = 1; i <= blocks.Count; i++)
            {
                for (int entrcs = 1; entrcs <= 12; entrcs++)
                {
                    entrances.Add(new Entrance(entrcs * 2, i));
                    for (int flrs = 1; flrs <= 7; flrs++)
                    {
                        floors.Add(new Floor(flrs, entrcs * 2, i));
                        for (int flts = 1; flts <= 4; flts++)
                        {
                            flats.Add(new Flat(flts, flrs, entrcs * 2, i));
                            for (int n = 0; n < 2; n++)
                            {
                                persons.Add(gen.CreatePerson(i + 1, (entrcs + 1) * 2, flrs + 1, flts + 1));
                            }
                        }
                    }
                }
            }
            foreach(var flat in flats)
            {
                foreach (var person in persons)
                {
                    if (IsFlatFull(flat,person) == true)
                    {
                        person.Flat = 0;
                    }
                }
            }
        }   
        public bool IsFlatFull(Flat flat , Person person)
        {
            int a = 0;
                    if(person.Flat == flat.Number && person.Floor == flat.Floor && person.Entrance == flat.Entrance && person.Block == flat.Block)
                    {
                        a++;
                        if (a > 4)
                        {
                            return true;
                        }
                    }
            return false;
        }
        
        public void Show()
        {
            ShowBlocks();

            if (!int.TryParse(Console.ReadLine(), out int blck))
                return;

            if (!ShowEntrances(blck))
                return;

            if (!int.TryParse(Console.ReadLine(), out int ent))
                return;

            if (!ShowFloors(blck, ent))
                return;

            if(!int.TryParse(Console.ReadLine(), out int flr))
                return;

            if (!ShowFlats(blck, ent, flr))
                return;

            if (!int.TryParse(Console.ReadLine(), out int flt))
                return;
            ShowPeople(blck, ent, flr, flt);
        }


        public void MovePerson()
        {
            int a = 1;
            string input = "";
            int block = 0;
            int entrance = 0;
            int floor = 0;
            int flat = 0;
            for (int i = 0; i < a; i++)
            {
                ShowBlocks();
                if (!int.TryParse(Console.ReadLine(), out int blck))
                    return;

                if (!ShowEntrances(blck))
                    return;

                if (!int.TryParse(Console.ReadLine(), out int ent))
                    return;

                if (!ShowFloors(blck, ent))
                    return;

                if (!int.TryParse(Console.ReadLine(), out int flr))
                    return;
                if(a == 1)
                {
                    if (!NoShowFullFlats(blck, ent, flr))
                        return;
                }
                else
                    if (!ShowFlats(blck, ent, flr))
                        return;

                if (!int.TryParse(Console.ReadLine(), out int flt))
                    return;
                ShowPeople(blck, ent, flr, flt);
                if (a == 1)
                {
                    Console.WriteLine("Select person");
                    input = Console.ReadLine();
                    block = blck;
                    entrance = ent;
                    floor = flr;
                    flat = flt;
                }
                foreach (var person in persons)
                {
                    if (input.ToLower().Contains(person.FirstName.ToLower()) && input.ToLower().Contains(person.LastName.ToLower()) && block == person.Block && entrance == person.Entrance && floor == person.Floor && flat == person.Flat)
                    {
                        
                        if (a == 2)
                            person.Move(blck, ent, flr, flt);
                        a++;
                    }
                }
                if (a == 1)
                {
                    Console.WriteLine("This person doesn't exist.");
                    i--;
                }
            }
        }
        private void ShowBlocks()
        {
            foreach (var block in blocks)
            {
                Console.WriteLine($"{block.NumberOfblock}.Block");
            }
        }
        private bool ShowEntrances(int blck)
        {
            var validEntrances = entrances.Where(en => en.Block == blck);

            foreach (var entrance in validEntrances)
                Console.WriteLine($"{entrance.Number}.Entrance");
            
            return validEntrances.Any();
        }
        private bool ShowFloors(int blck, int ent)
        {
            var validFloors = floors.Where(fl => blck == fl.Block && ent == fl.Enter);

            foreach (var floor in validFloors)
                Console.WriteLine($"{floor.Number}.Floor");

            return validFloors.Any();
        }
        private bool ShowFlats(int blck , int ent, int flr)
        {
            var validFlats = flats.Where(ft => blck == ft.Block && ent == ft.Entrance && flr == ft.Floor);

            foreach (var flat in validFlats)
                Console.WriteLine($"{flat.Number}.Flat");

            return validFlats.Any();
        }
        private bool NoShowFullFlats(int blck, int ent, int flr)
        {
            var validFlats = flats.Where(ft => blck == ft.Block && ent == ft.Entrance && flr == ft.Floor);
            foreach (var flat in validFlats)
                foreach (var person in persons)
                    if (IsFlatFull(flat, person) == false)
                    {
                        Console.WriteLine($"{flat.Number}.Flat");
                    }
            return validFlats.Any();
        }
        private void ShowPeople(int blck, int ent, int flr, int flt)
        {
            foreach (var person in persons)
            {
                if (blck == person.Block && ent == person.Entrance && flr == person.Floor && flt == person.Flat)
                {
                    Console.WriteLine($" {person.FirstName} {person.LastName} age:{person.Age}");
                }
            }
        }
    }
}
