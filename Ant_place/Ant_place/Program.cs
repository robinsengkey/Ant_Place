using System;
using System.Collections.Generic;

namespace Ant_Place
{
    class Program
    {
        List<Ant> ants = new List<Ant>();

        static void Main()
        {
            Program p = new Program();
            p.Commands();
        }

        private void Commands()
        {
            while (true)
            {
                Console.WriteLine("\nWelcome to a Ant Place\nEnter command\nif in need of help, type help");
                string input = Console.ReadLine().ToLower();
                if (input == "help")
                    Help();
                else if (input == "add")
                    AddAnt();
                else if (input == "quit")
                    Quit();
                else if (input == "exit")
                    Quit();
                else if (input == "list")
                    ListAnts();
                else if (input == "count")
                    CountAnts();
                else if (input == "remove")
                    Remove();
                else if (input == "search")
                    Search();
                else
                    Console.WriteLine("\nInvalid command, type help for commands");
            }
        }

        private void AddAnt()
        {
            Console.WriteLine("\nEnter the name of your ant:");
            string name = Console.ReadLine().ToLower();
            foreach (Ant ant in ants)
            {
                if (ant.Name == name)
                {
                    Console.WriteLine("An ant with this name already exist's, name your ant with" +
                        " a name which no ant already has been given");
                    return;
                }
            }
            if (name.Contains(" "))
            {
                Console.WriteLine("Your ant's name cant consist of space");
                return;
            }
            Console.WriteLine("Your ant's name is " + name + ", kinda boring...");
            Console.WriteLine("Enter the amount of legs your ant possess:");
            while (true)
            {
                try
                {
                    int legs = int.Parse(Console.ReadLine());
                    if (legs <= 0 || legs > 6)
                    {
                        Console.WriteLine("Legs can only be between 1 to 6 legs, try again");
                        return;
                    }
                    Console.WriteLine("Your ant possess a amount of " + legs + " legs, cool.");
                    Ant newAnt = new Ant(name, legs);
                    ants.Add(newAnt);
                    return;
                }
                catch
                {
                    Console.WriteLine("Wrong symbols used, only numbers are valid, try again");
                }
            }
        }

        private void Help()
        {
            Console.WriteLine("List of commands:\nhelp - list of commands\nadd - add a ant\nquit (or) exit - exit the program\nlist - lists all ants created" +
                "\nsearch - searches for ants based on their names\nremove - removes ants based on names\ncount - counts quantity of ants existing");
        }

        private void Quit()
        {
            Console.WriteLine("\n-Omea Wa mou, shinduru!\n-NANI??!?");
            Environment.Exit(0);
        }

        private void ListAnts()
        {
            //kollar först om listan innehåller något
            if (ants.Count > 0)
            {
                foreach (Ant ant in ants)
                {
                    Console.WriteLine("\n" + ant.Name + " with " + ant.Legs + " legs!");
                }
            }
            else if (ants.Count <= 0)
            {
                Console.WriteLine("There are no ants to list!");
            }
        }

        private void CountAnts()
        {
            Console.WriteLine("There are " + ants.Count + " ants in this place");
        }

        private void Remove()
        {
            //söker efter namnet som användaren söker i listan, om namnet finns tas den myran med namnet bort från listan
            Console.WriteLine("Which ant do you wish to annihilate?");
            string name = Console.ReadLine().ToLower();
            foreach (Ant ant in ants)
            {
                if (ant.Name.ToLower() == name)
                {
                    Console.WriteLine("Erasing information of ant " + ant.Name + " from ever existing");
                    ants.Remove(ant);
                    Console.WriteLine("\nUser: *SNAP*\n\n" + ant.Name + ": Mister ant Stark, I'm not feeling so good...");
                    return;
                }
            }
            Console.WriteLine("Could not annihilate " + name + ".\nAnt " + name + " already doesn't exist");
        }

        /*
         * Robin:
         * Hade funderat på att dela upp metoden i 2 olika, en för att hitta en myra efter
         * namn och en efter antal ben. Det hade kanske gjort det lite lättare att läsa.
         */
        private void Search()
        {
            //frågar först användaren hur myran ska sökas upp (ben eller namn), sedan letar efter en myra med likadant input av ben eller namn
            Console.WriteLine("Do you want to search by legs or name?");
            string searchmethod = Console.ReadLine().ToLower();
            if (searchmethod == "name")
            {
                Console.WriteLine("Which ant do you wish to detain? Type in their name");
                string wantedAnt = Console.ReadLine().ToLower();
                foreach (Ant ant in ants)
                {
                    if (ant.Name.ToLower() == wantedAnt)
                    {
                        Console.WriteLine("Ant " + ant.Name + " does exist");
                        return;
                    }
                }
                Console.WriteLine("Ant " + wantedAnt + " does not exist");
            }
            else if (searchmethod == "legs")
            {
                Console.WriteLine("How many legs do your wanted ant possess?");
                {
                    try
                    {
                        int wantedAntlegs;
                        wantedAntlegs = int.Parse(Console.ReadLine());
                        foreach (Ant ant in ants)
                        {
                            if (ant.Legs == wantedAntlegs)
                            {
                                Console.WriteLine("Ant with " + wantedAntlegs + " amount of legs does exist");
                                return;
                            }
                        }
                        Console.WriteLine("Ant with that amount of legs does not exist");
                    }
                    catch
                    {
                        Console.WriteLine("Wrong Symbols used!");
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("Unknown Input, type either Legs or Name");
            }
        }

        /*
         * Robin:
         * Riktigt snygg klass!
         */
        class Ant
        {
            public string Name
            {
                get; private set;
            }

            public int Legs
            {
                get; private set;
            }

            public Ant(string name, int legs)
            {
                Name = name;
                Legs = legs;
            }

        }
    }
}

/*
 * Robin:
 * Snyggt jobbat! Du har skrivit koden med en tydlig och konsekvent stil,
 * med bra användande av beskrivande namngivning.
 * 
 * Programmet verkar robust, och jag kan inte hitta några uppenbara fel
 * som skulle krascha programmet. 
 * 
 * Det är synd att du inte fick med att myrornas namn skrivs ut med 
 * inledande versal. Annars så fick du med allt på ett snyggt sätt!
 * 
 * Det har varit kul att se dig arbeta på lektionerna, speciellt senaste 
 * veckorna! Det är jättebra att du tar hjälp av dina klasskamrater och
 * mig när du undrar något, och tar ansvar för ditt eget lärande. Titta
 * gärna igenom koden en gång till så att du verkligen förstår allt,
 * och öva gärna på att skriva mindre program i liknande stil så det
 * sätter sig!
 * 
 * Fortsätt så här, så kommer du blir grym! 
 */