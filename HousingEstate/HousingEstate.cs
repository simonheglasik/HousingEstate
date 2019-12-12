using System;
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
            Show();
            Console.WriteLine("Select person");
            string input = Console.ReadLine();
            foreach (var person in persons)
            {
                string name = $"{person.FirstName} {person.LastName}";
                if (input.Contains(person.FirstName) && input.Contains(person.LastName))
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

                    if (!ShowFlats(blck, ent, flr))
                        return;

                    if (!int.TryParse(Console.ReadLine(), out int flt))
                        return;
                    person.Move(blck, ent, flr, flt);
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
