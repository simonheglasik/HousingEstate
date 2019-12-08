using System;
using System.Collections.Generic;
using System.Text;

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
                            for (int n = 0; n < 4; n++)
                            {
                                persons.Add(gen.CreatePerson(i + 1, (entrcs + 1) * 2, flrs + 1, flts + 1));
                            }
                        }
                    }
                }
            }
        }
        public void Show()
        {
            ShowBlocks();
            int blck = int.Parse(Console.ReadLine());
            ShowEntrances(blck);
            int ent = int.Parse(Console.ReadLine());
            ShowFloors(blck, ent);
            int flr = int.Parse(Console.ReadLine());
            ShowFlats(blck, ent, flr);
            int flt = int.Parse(Console.ReadLine());
            ShowPeople(blck, ent, flr, flt);
        }
        public void MovePerson()
        {
            Show();
            Console.WriteLine("Select person");
            string input = Console.ReadLine();
            foreach (var person in persons)
            {
                string name = $"{person.FirstName} {person.LastName}";
                if (input.Contains(person.FirstName) && input.Contains(person.LastName))
                {
                    int blck = int.Parse(Console.ReadLine());
                    ShowEntrances(blck);
                    int ent = int.Parse(Console.ReadLine());
                    ShowFloors(blck, ent);
                    int flr = int.Parse(Console.ReadLine());
                    ShowFlats(blck, ent, flr);
                    int flt = int.Parse(Console.ReadLine());
                    person.Move(blck, ent, flr, flt);
                }
            }
        }
        public void ShowBlocks()
        {
            foreach (var block in blocks)
            {
                Console.WriteLine($"{block.NumberOfblock}.Block");
            }
        }
        public void ShowEntrances(int blck)
        {
            List<int> ent = new List<int>();
            foreach (var entrance in entrances)
            {
                if (blck == entrance.Block)
                {
                    ent.Add(entrance.Number);
                    Console.WriteLine($"{entrance.Number}.Entrance");
                }
            }
            if (ent.Count == 0)
            {
                Console.WriteLine("This block does not exist");
            }
        }
        public void ShowFloors(int blck, int ent)
        {
            foreach (var floor in floors)
            {
                if (blck == floor.Block && ent == floor.Enter)
                {
                    Console.WriteLine($"{floor.Number}.Floor");
                }
            }
        }
        public void ShowFlats(int blck, int ent, int flr)
        {
            foreach (var flat in flats)
            {
                if (blck == flat.Block && ent == flat.Entrance && flr == flat.Floor)
                {
                    Console.WriteLine($"{flat.Number}.Flat");
                }
            }
        }
        public void ShowPeople(int blck, int ent, int flr, int flt)
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
