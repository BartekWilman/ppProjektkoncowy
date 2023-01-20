using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektKoncowy
{
    
    internal class Program
    {
        public static string Plik = "save.csv";
        static StreamWriter sw;
        static StreamReader sr;
        public static Boxers.Boxer Buster = new Boxers.Boxer();
        public static Boxers.Boxer Mike = new Boxers.Boxer("Mike Tyson", 180, 480, 270, 390, 430);
        //punkty umiejętności
        public static int skillPoints = 0;
        //wygrane
        public static int wins = 0;

        public static bool fightWithTyson = false;
        public static string GenerateLine(Boxers.Boxer i, int skillPoints, int wins)
        {
            return $"{i.name};{i.strenght};{i.condition};{i.speed};{i.attack};{i.defense};{skillPoints};{wins}";
        }
        //gracz
        //static Boxers.Boxer Buster = new Boxers.Boxer("Buster Douglas", 3, 4, 4, 4, 3);
        // nowa walka
        public static void NewFight(Boxers.Boxer i)
        {
            bool end = false;
            while(end == false)
            {
                Console.WriteLine("Wybierz poziom trudności");
                Console.WriteLine("1 - łatwy\n2 - średni\n3 - trudny\n4 - legendarny\n5 - wróć");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        Boxers.Boxer EasyBoxer = new Boxers.Boxer();
                        EasyBoxer = Boxers.Newboxer(StringLists.easyBoxersNames, 4, 7);
                        Fight.Duel(i, EasyBoxer, ref skillPoints, 1, ref wins);
                        end = true;
                        break;
                    case ConsoleKey.D2:
                        Boxers.Boxer MediumBoxer = new Boxers.Boxer();
                        MediumBoxer = Boxers.Newboxer(StringLists.mediumBoxersName, 8, 19);
                        Fight.Duel(i, MediumBoxer, ref skillPoints, 2, ref wins);
                        end = true;
                        break;
                    case ConsoleKey.D3:
                        Boxers.Boxer HardBoxer = new Boxers.Boxer();
                        HardBoxer = Boxers.Newboxer(StringLists.hardBoxersNames, 20, 40);
                        Fight.Duel(i, HardBoxer, ref skillPoints, 3, ref wins);
                        end = true;
                        break;
                    case ConsoleKey.D4:
                        Boxers.Boxer LegendBoxer= new Boxers.Boxer();
                        LegendBoxer = Boxers.Newboxer(StringLists.legendBoxersNames, 40, 80);
                        Fight.Duel(i, LegendBoxer, ref skillPoints, 4, ref wins);
                        end = true;
                        break;
                    case ConsoleKey.D5:
                        end = true;
                        break;
                }
            }
            if (wins == 50)
            {
                Console.WriteLine(StringLists.after50Wins);
            }
            else if (wins == 100)
            {
                Console.WriteLine(StringLists.after100Wins);
            }
            else if (wins == 150)
            {
                Console.WriteLine(StringLists.after150Wins);
            }
        }
        //zapisanie stanu
        public static void SaveGame(Boxers.Boxer i, int skillPoints, int wins)
        {
                string text = GenerateLine(i, skillPoints, wins);
                sw = new StreamWriter(Plik, true);
                sw.WriteLine(text);
                sw.Close();
        }
        //wczytanie gry
        public static void LoadGame(ref Boxers.Boxer i, ref int skillPoints, ref int wins)
        {
            sr = new StreamReader(Plik);
            var line = sr.ReadLine();
            var table = line.Split(';');
            string name = table[0];
            float strenght = float.Parse(table[1]);
            float condition = float.Parse(table[2]);
            float speed = float.Parse(table[3]);
            float attack = float.Parse(table[4]);
            float defense = float.Parse(table[5]);
            skillPoints = int.Parse(table[6]);
            wins = int.Parse(table[7]);
            i.name= name;
            i.strenght= strenght;
            i.condition= condition;
            i.speed= speed;
            i.attack= attack;
            i.defense= defense;
            sr.Close();
        }
        //rozgrywka
        public static void Game(Boxers.Boxer i)
        {
            bool end = false;
            while(end == false)
            {
                Console.WriteLine($"Wygrałeś {wins} walk. Przed następną walką możesz zrobić {skillPoints} jednostek treningowych, co chcesz zrobić?");
                Console.WriteLine("1 - Walcz\n2 - Trenuj\n3 - Zapisz i wyjdź");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        if(wins == 200 && fightWithTyson == false)
                        {
                            Console.WriteLine("Walczysz z mistrzem Mikiem Tysonem?\n1 - Tak\n2 - Nie");
                            switch(Console.ReadKey(true).Key)
                            {
                                case ConsoleKey.D1:
                                    Console.WriteLine(StringLists.beforFightWithTyson);
                                    Fight.Duel(i, Mike, ref skillPoints, 10, ref wins);
                                    if(wins == 201)
                                    {
                                        Console.WriteLine(StringLists.winWithTyson);
                                        fightWithTyson = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine(StringLists.defeatWithTyson);
                                        fightWithTyson = true;
                                    }
                                    break;
                                    case ConsoleKey.D2:
                                    Console.WriteLine(StringLists.rejectionOfTheFight);
                                    fightWithTyson = true;
                                    break;
                            }
                        }
                        else
                        {
                            NewFight(i);
                        }
                        break;

                    case ConsoleKey.D2:
                        Boxers.TurboTraining(ref i, ref skillPoints);
                        break;
                    case ConsoleKey.D3:
                        
                        
                        if (File.Exists(Plik))
                        {
                            File.Delete(Plik);
                        }
                        SaveGame(i, skillPoints, wins);
                        Console.WriteLine("Żegnam");
                        end = true;
                        
                        break;
                }
            }
        }
        //1
        public static void NewGame()
        {
            File.Delete(Plik);
            Console.WriteLine("Nazywasz się Buster Douglas i jesteś bokserem wagi ciężkiej.\nTwoim zadaniem jest zdetronizowanie obecnego mistrze Mika Tysona.");
            Console.WriteLine("Zdobądź mistrzostwo pokonując to coraz silniejszych rywali a w pewnym momencie mistrz sam się o Ciebie upomni");
            Buster = new Boxers.Boxer("Buster Douglas", 3, 4, 4, 4, 3);
            Game(Buster);
        }
        //2
        public static void ContinueGame()
        {
            LoadGame(ref Buster, ref skillPoints, ref wins);
            Game(Buster);
        }
        public static void Meat()
        {
            Console.WriteLine("BUSTER DOUGLAS SIMULATOR");
            bool end = true;
            while(end == true)
            {
                Console.WriteLine("1 - nowa gra\n2 - kontynuuj grę\n3 - autorzy\n4 - wyjdź z programu");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        if (File.Exists(Plik))
                        {
                            Console.WriteLine("Wybranie tej opcji usunie aktualny stan gry. Czy jesteś pewien?\n1 - Tak\n2 - Nie");
                            switch(Console.ReadKey(true).Key)
                            {
                                case ConsoleKey.D1:
                                    NewGame();
                                    break;
                                case ConsoleKey.D2:
                                    break;
                            }
                        }
                        else
                        {
                            NewGame();
                        }
                        break;
                        case ConsoleKey.D2:
                        ContinueGame();
                        break;
                        case ConsoleKey.D3:
                        Console.WriteLine(StringLists.authors);
                        break;
                        case ConsoleKey.D4:
                        Console.WriteLine("Jesteś pewien?\n1 - Tak   2 - Nie");
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.D1:
                            end= false;
                                Console.WriteLine("Żegnam");
                                Console.ReadLine();
                            break;
                            case ConsoleKey.D2:
                            break;
                        }
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            Meat();
        }
    }
}
