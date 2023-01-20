using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektKoncowy
{
    internal class Fight
    {
        public static void Taunting(Boxers.Boxer fighter1, Boxers.Boxer fighter2, int playerPoints, int aIPoints)
        {
            string taunt = Boxers.RandomString(StringLists.taunts);
            if (playerPoints > aIPoints)
            {
                Console.WriteLine($"\n{fighter1.name} {taunt}\n");
            }
            else if (aIPoints > playerPoints)
            {
                Console.WriteLine($"\n{fighter2.name} {taunt}\n");
            }
            else
            {
                string draw = Boxers.RandomString(StringLists.draw);
                Console.WriteLine($"\n{draw}\n");
            }

        }
        public static void Duel(Boxers.Boxer fighter1, Boxers.Boxer fighter2, ref int skillPoints, int level, ref int winstreak)
        {
            double fighter1Oxygen = fighter1.condition * 100;
            double fighter1Life = fighter1.condition * 100;
            double fighter2Oxygen = fighter2.condition * 100;
            double fighter2Life = fighter2.condition * 100;
            int playerPoints = 0;
            int aIPoints = 0;
            int rounds = 0;
            // WALKA
            while (fighter1Life > 0 && fighter2Life > 0 && rounds < 12) {
                rounds++;
                Console.WriteLine($"RUNDA {rounds}");
                Taunting(fighter1, fighter2, playerPoints, aIPoints);
                // RUNDA
                int action = 0;
                while (fighter1Life > 0 && fighter2Life > 0 && action < 20)
                {
                    //gracz ma inicjatywę
                    if ((fighter1.speed * fighter1Oxygen) > (fighter2.speed * fighter2Oxygen))
                    {
                        //gracz ma wystarczająco tlenu by zaatakować
                        if (fighter1Oxygen - ((0.1) * fighter1.strenght) > 0)
                        {
                            string beginning = Boxers.RandomString(StringLists.beginning);
                            string moves = Boxers.RandomString(StringLists.moves);
                            string targets = Boxers.RandomString(StringLists.targets);
                            Console.WriteLine($"{fighter1.name} {beginning} {moves} {targets}");

                            //tlenowy koszt ataku
                            fighter1Oxygen -= (((fighter1.strenght) * 1.5) * rounds);
                            //udany atak i trafienie zadanie obrażeń przeciwnikowi
                            if (fighter1.attack >= fighter2.defense)
                            {
                                fighter2Life -= fighter1.strenght;
                                action++;
                                playerPoints += 2;
                                fighter1Oxygen += (fighter1.condition * 0.75);
                                fighter2Oxygen += (fighter2.condition * 0.75);
                                if (fighter2Life > 0)
                                {
                                    string beingInjured = Boxers.RandomString(StringLists.beingInjured);
                                    string continuingTheFight = Boxers.RandomString(StringLists.continuingTheFight);
                                    Console.WriteLine($"{fighter2.name} {beingInjured} {continuingTheFight}\n");
                                }
                                else
                                {
                                    Console.WriteLine($"{fighter2.name} pada na deski, koniec walki\n");
                                }
                            }
                            else
                            {
                                //nieudany atak i poprawna kontra przeciwnika
                                if ((((fighter1.speed * fighter1Oxygen) + fighter1.attack) <= ((fighter2.speed * fighter2Oxygen) + fighter2.defense)) && fighter2Oxygen > 0)
                                {
                                    //jeśli ma tlen
                                    if (fighter2Oxygen - (fighter2.strenght * (1.5)) > 0)
                                    {
                                        string avoids = Boxers.RandomString(StringLists.avoids);
                                        moves = Boxers.RandomString(StringLists.moves);

                                        Console.WriteLine($"Ale {fighter2.name} {avoids} i wykonał {moves}");
                                        fighter2Oxygen -= (((fighter2.strenght) * 1.5) * rounds);
                                        fighter1Life -= fighter2.strenght;
                                        action++;
                                        aIPoints += 2;
                                        fighter1Oxygen += (fighter1.condition * 0.75);
                                        fighter2Oxygen += (fighter2.condition * 0.75);
                                        if (fighter1Life > 0)
                                        {
                                            string beingInjured = Boxers.RandomString(StringLists.beingInjured);
                                            string continuingTheFight = Boxers.RandomString(StringLists.continuingTheFight);
                                            Console.WriteLine($"{fighter1.name} {beingInjured} {continuingTheFight}\n");
                                        }
                                        else
                                        {
                                            string fatality = Boxers.RandomString(StringLists.fatality);
                                            Console.WriteLine($"{fighter1.name} {fatality}, koniec walki\n");
                                        }
                                    }
                                    //brak tlenu na kontrę
                                    else
                                    {
                                        string retreat = Boxers.RandomString(StringLists.retreat);
                                        Console.WriteLine($"{fighter2.name} {retreat}\n");
                                        fighter1Oxygen += (fighter2.strenght * 2);
                                        fighter1Oxygen += (fighter1.condition * 0.75);
                                        fighter2Oxygen += (fighter2.condition * 0.75);
                                        action++;
                                    }
                                }//nieudany atak, bez kontry przeciwnika
                                else
                                {
                                    string avoids = Boxers.RandomString(StringLists.avoids);
                                    Console.WriteLine($"Ale {fighter2.name} {avoids}\n");
                                    playerPoints++;
                                    aIPoints++;
                                    fighter2Oxygen -= ((fighter2.strenght) * 1);
                                    fighter1Oxygen += (fighter1.condition * 0.75);
                                    fighter2Oxygen += (fighter2.condition * 0.75);
                                    action++;
                                }
                            }
                        }
                        //brak tlenu na atak gracza
                        else
                        {
                            //przeciwnik wykorzystuje brak tlenu gracza
                            if ((fighter1Oxygen < fighter2Oxygen))
                            {
                                string lackOfOxygen = Boxers.RandomString(StringLists.lackOfOxygen);
                                string beginning = Boxers.RandomString(StringLists.beginning);
                                string moves = Boxers.RandomString(StringLists.moves);
                                string targets = Boxers.RandomString(StringLists.targets);
                                Console.WriteLine($"{fighter1.name} {lackOfOxygen}");
                                Console.WriteLine($"{fighter2.name} {beginning} {moves} {targets}");
                                fighter2Oxygen -= (((fighter2.strenght) * 1.5) * rounds);
                                fighter1Life -= fighter2.strenght;
                                action++;
                                aIPoints += 2;
                                fighter1Oxygen += (fighter1.condition * 0.75);
                                fighter2Oxygen += (fighter2.condition * 0.75);
                                if (fighter1Life > 0)
                                {
                                    string beingInjured = Boxers.RandomString(StringLists.beingInjured);
                                    string continuingTheFight = Boxers.RandomString(StringLists.continuingTheFight);
                                    Console.WriteLine($"{fighter1.name} {beingInjured} {continuingTheFight}\n");
                                }
                                else
                                {
                                    string fatality = Boxers.RandomString(StringLists.fatality);
                                    Console.WriteLine($"{fighter1.name} {fatality}, koniec walki\n");
                                }
                            }
                            else
                            {
                                //przeciwnik nie jest w stanie wykorzystać braku tlenu gracza
                                string retreat = Boxers.RandomString(StringLists.retreat);
                                Console.WriteLine($"{fighter1.name} {retreat}\n");
                                fighter1Oxygen += (fighter1.strenght * 2);
                                fighter1Oxygen += (fighter1.condition * 0.75);
                                fighter2Oxygen += (fighter2.condition * 0.75);
                                action++;
                            }
                        }
                    }

                    //przeciwnik ma inicjatywę
                    else if ((fighter2.speed * fighter2Oxygen) > (fighter1.speed * fighter1Oxygen))
                    {
                        //jeśli ma tlen
                        if (fighter2Oxygen - (fighter2.strenght * 1.5) > 0)
                        {
                            string beginning = Boxers.RandomString(StringLists.beginning);
                            string moves = Boxers.RandomString(StringLists.moves);
                            string targets = Boxers.RandomString(StringLists.targets);
                            Console.WriteLine($"{fighter2.name} {beginning} {moves} {targets}");

                            //tlenowy koszt ataku
                            fighter2Oxygen -= (((fighter2.strenght) * 1.5) * rounds);

                            //udany atak przeciwnika
                            if (fighter2.attack > fighter1.defense)
                            {
                                fighter1Life -= fighter2.strenght;
                                action++;
                                aIPoints += 2;
                                fighter1Oxygen += (fighter1.condition * 0.75);
                                fighter2Oxygen += (fighter2.condition * 0.75);
                                if (fighter1Life > 0)
                                {
                                    string beingInjured = Boxers.RandomString(StringLists.beingInjured);
                                    string continuingTheFight = Boxers.RandomString(StringLists.continuingTheFight);
                                    Console.WriteLine($"{fighter1.name} {beingInjured} {continuingTheFight}\n");
                                }
                                else
                                {
                                    Console.WriteLine($"{fighter1.name} pada na deski koniec walki\n");
                                }
                            }
                            else
                            {
                                //nieudany atak przeciwnika i poprawna kontra gracza
                                if (((fighter2.speed * fighter2Oxygen) + fighter2.attack) <= ((fighter1.speed * fighter1Oxygen) + fighter1.defense))
                                {
                                    if (fighter1Oxygen - (fighter1.strenght * 1.5) > 0)
                                    {
                                        string avoids = Boxers.RandomString(StringLists.avoids);
                                        moves = Boxers.RandomString(StringLists.moves);
                                        Console.WriteLine($"Ale {fighter1.name} {avoids} i wykonał {moves}");
                                        fighter1Oxygen -= (((fighter1.strenght) * 1.5) * rounds);
                                        fighter2Life -= fighter1.strenght;
                                        action++;
                                        playerPoints += 2;
                                        fighter1Oxygen += (fighter1.condition * 0.75);
                                        fighter2Oxygen += (fighter2.condition * 0.75);
                                        if (fighter2Life > 0)
                                        {
                                            string beingInjured = Boxers.RandomString(StringLists.beingInjured);
                                            string continuingTheFight = Boxers.RandomString(StringLists.continuingTheFight);
                                            Console.WriteLine($"{fighter2.name} {beingInjured} {continuingTheFight}\n");
                                        }
                                        else
                                        {
                                            Console.WriteLine($"{fighter2.name} pada na deski koniec walki\n");
                                        }
                                    }
                                    //za mało tlenu na kontre
                                    else
                                    {
                                        Console.WriteLine($"{fighter1.name} dystansuje się\n");
                                        fighter1Oxygen += (fighter1.strenght * 2);
                                        fighter1Oxygen += (fighter1.condition * 0.75);
                                        fighter2Oxygen += (fighter2.condition * 0.75);
                                        action++;
                                    }
                                }
                                //nieudany atak, bez kontry gracza
                                else
                                {
                                    string avoids = Boxers.RandomString(StringLists.avoids);
                                    Console.WriteLine($"Ale {fighter1.name} {avoids}\n");
                                    fighter1Oxygen -= ((fighter1.strenght) * 1);
                                    fighter1Oxygen += (fighter1.condition * 0.75);
                                    fighter2Oxygen += (fighter2.condition * 0.75);
                                    action++;
                                    playerPoints++;
                                    aIPoints++;
                                }
                            }
                        }
                        //przeciwnik nie ma tlenu
                        else
                        {
                            //gracz wykorzystuje brak tlenu u przeciwnika
                            if ((fighter2Oxygen < fighter1Oxygen))
                            {
                                string lackOfOxygen = Boxers.RandomString(StringLists.lackOfOxygen);
                                string beginning = Boxers.RandomString(StringLists.beginning);
                                string moves = Boxers.RandomString(StringLists.moves);
                                string targets = Boxers.RandomString(StringLists.targets);
                                Console.WriteLine($"{fighter2.name} {lackOfOxygen}");
                                Console.WriteLine($"{fighter1.name} {beginning} {moves} {targets}");
                                fighter1Oxygen -= (((fighter1.strenght) * 1.5) * rounds);
                                fighter2Life -= fighter1.strenght;
                                action++;
                                playerPoints += 2;
                                fighter1Oxygen += (fighter1.condition * 0.75);
                                fighter2Oxygen += (fighter2.condition * 0.75);
                                if (fighter2Life > 0)
                                {
                                    string beingInjured = Boxers.RandomString(StringLists.beingInjured);
                                    string continuingTheFight = Boxers.RandomString(StringLists.continuingTheFight);
                                    Console.WriteLine($"{fighter2.name} {beingInjured} {continuingTheFight}\n");
                                }
                                else
                                {
                                    string fatality = Boxers.RandomString(StringLists.fatality);
                                    Console.WriteLine($"{fighter2.name} {fatality}, koniec walki\n");
                                }
                            }
                            // gracz nie jest w stanie wykorzystać braku tlenu przeciwnika
                            else
                            {
                                //przeciwnik nie jest w stanie wykorzystać braku tlenu gracza
                                string retreat = Boxers.RandomString(StringLists.retreat);
                                Console.WriteLine($"{fighter2.name} {retreat}\n");
                                fighter1Oxygen += (fighter2.strenght * 2);
                                fighter1Oxygen += (fighter2.condition * 0.75);
                                fighter2Oxygen += (fighter1.condition * 0.75);
                                action++;
                            }
                        }
                    }

                    //gracz i przeciwnik zaatakowali w tym samym momencie
                    else
                    {
                        Console.WriteLine($"{fighter1.name} i {fighter2.name} trafiają w tym samym momencie\n");
                        fighter1Life -= fighter2.strenght;
                        fighter2Life -= fighter1.strenght;
                        fighter1Oxygen -= (fighter1.strenght * 1.5);
                        fighter2Oxygen -= (fighter2.strenght * 1.5);
                        action+=2;
                        playerPoints++;
                        aIPoints++;
                    }

                }
                fighter1Oxygen += (fighter1.condition * 25);
                fighter2Oxygen += (fighter2.condition * 25);
            }
            //możliwe wyniki starcia
            Console.WriteLine("WYNIK");

            //wygrana przez KO
            if (fighter1Life > 0 && fighter2Life <=0 && rounds <= 12)
            {
                Console.WriteLine($"Przez KO walkę w {rounds} rundzie wygrywa {fighter1.name}");
                skillPoints += (3 * level);
                winstreak++;
            }
            //wygrana na punkty
            else if (fighter1Life > 0 && fighter2Life > 0 && playerPoints > aIPoints)
            {
                Console.WriteLine($"Walkę na punkty wygrywa {fighter1.name} z wynikiem {playerPoints} do {aIPoints}");
                skillPoints += (1 * level);
                winstreak++;
            }
            //przegrana przez KO
            else if (fighter2Life > 0  && fighter1Life <= 0 && rounds <= 12)
            {
                Console.WriteLine($"Przez KO walkę w {rounds} rundzie wygrywa {fighter2.name}");
            }
            //przegrana na punkty
            else if (fighter1Life > 0 && fighter2Life > 0 && aIPoints > playerPoints)
            {
                Console.WriteLine($"Walkę na punkty wygrywa {fighter2.name} z wynikiem {aIPoints} do {playerPoints}");
            }
            //remis
            else
            {
                Console.WriteLine("REMIS");
            }
        }
    }
}
