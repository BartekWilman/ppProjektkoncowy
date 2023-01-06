using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektKoncowy
{
    internal class Boxers
    {
        public static Random rand = new Random();
        

        //losowy string
        public static string RandomString(string[] tab)
        {
            int i = rand.Next(0, tab.Length);
            return tab[i];
        }

        //struktura boksera
        public struct Boxer
        {
            //Konstruktor
            public Boxer(string name, float strenght, float condition, float speed, float attack, float defense)
            {
                this.name = name;
                this.strenght = strenght;
                this.condition = condition;
                this.speed = speed;
                this.attack = attack;
                this.defense = defense;
            }
            public string name;
            public float strenght;
            public float condition;
            public float speed;
            public float attack;
            public float defense;
            
        }
        //do stestów
        public static void ShowMe(Boxer i)
        {
            Console.WriteLine($"{i.name} siła {i.strenght} szybkość {i.speed} kondycja {i.condition} atak {i.attack} obrona {i.defense}");
        }
        //nowy bokser
        public static Boxer Newboxer(string[] tab, int min, int max)
        {
            string name = RandomString(tab);
            float strenght = rand.Next(min, max);
            float condition = rand.Next(min, max);
            float speed = rand.Next(min, max);
            float attack = rand.Next(min, max);
            float defense = rand.Next(min, max);

            Boxer enemy = new Boxer(name, strenght, condition, speed, attack, defense);
            return enemy;
        }
        //trening
        public static void Training(ref Boxer i, ref int skillPoints)
        {
            Console.WriteLine("Co chcesz trenować?");
            bool end = false;
            Console.WriteLine("1 - szybkość\n2 - siłę\n3 - wytrzymałość\n4 - atak\n5 - obronę\n0 - nic");
            while (skillPoints > 0 && end == false)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("Zwiększono szybkość");
                    i.speed += 1;
                    skillPoints -= 1;
                        break;
                case ConsoleKey.D2:
                
                    Console.WriteLine("Zwiększono siłę");
                    i.strenght += 1;
                    skillPoints -= 1;
                        break;

                    case ConsoleKey.D3:
                    Console.WriteLine("Zwiększono wytrzymałość");
                    i.condition += 1;
                    skillPoints -= 1;
                        break;
                        case ConsoleKey.D4:
                        Console.WriteLine("Zwiększono atak");
                        i.attack+= 1;
                        skillPoints -= 1;
                        break;
                        case ConsoleKey.D5:
                        Console.WriteLine("Zwiększono obronę");
                        i.defense+= 1;
                        skillPoints -= 1;
                        break;
                        case ConsoleKey.D0:
                        Console.WriteLine("Koniec sesji treningowej");
                        end = true;
                        break;
                }
                

            }
            if (skillPoints == 0)
            {
                Console.WriteLine("Brakuje Ci punktów umiejętności, wygraj więcej walk by je zdobyć");
                Console.WriteLine("Zakończono trening");
            }
            else
            {
                Console.WriteLine("Zakończono trening");
            }
        }
    }
}
