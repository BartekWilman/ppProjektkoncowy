using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektKoncowy
{
    internal class StringLists
    {
        //imiona łatwych bokserów
        public static string[] easyBoxersNames = { "Marcin Najman", "Dawid Haras", "Bonus Bgc", "Chorąży Torpeda", "Wrzód z Gothica", "Skarnsik" };
        //imiona średnich bokserów
        public static string[] mediumBoxersName = { "Samuraj Jack", "Kung Fu Panda", "Hulk Hogan", "Kapitan Bomba", "Rock Lee", "Marshal Law", "Felix Jeager" };
        //imiona trudnych bokserów
        public static string[] hardBoxersNames = { "George St. Pierre", "Son Goku", "Muhammad Ali", "Cassius Clay", "One Punch Man", "Evander Holyfield", "Gotrek Gurnisson" };
        //rozpoczęcie akcji
        public static string[] beginning = { "rozpoczął ofensywę wytaczająć swój", "zaczął akcję od", "idzie do przodu", "wyprowadza atak, mocny" };

        //możliwe ataki
        public static string[] moves = { "Prawy prosty", "Lewy prosty", "Prawy sierpowy", "Lewy sierpowy", "Prawy podbródkowy", "Lewy podbródkowy" };

        //cel ataku
        public static string[] targets = { "na głowę przeciwnika", "na wątrobę", "w splot słoneczny", "na żebra" };

        //możliwe obrony
        public static string[] avoids = { "uchylił się", "wykonał unik rotacyjny", "zablokował", "zbił uderzenie", "przyjął na gardę" };

        //przyjęcia obrażeń
        public static string[] beingInjured = { "przyjął cios ale", "dał się zaskoczyć, a mimo to", "odsłonił się i dał wykorzystać szansę przeciwnikowi, jednak", "na pewno odczuł ten cios, chociaż", "uśmiechnął się, ale na pewno odczuł uderzenie, a mimo to", "dostał, a i tak" };

        //kontynuowanie walki
        public static string[] continuingTheFight = { "dalej walczy", "nie chce oddać pola", "walczy dalej", "pokazuje że wszystko OK i może kontynuować" };

        //koniec przez KO
        public static string[] fatality = { "zatoczył się i już nie wstaje", "leży nieprzytomny", "po tym uderzeniu nie jest w stanie się podnieść", "upadł jak długi i przegrywa przez nokaut", "pada na deski" };

        //drwiny
        public static string[] taunts = { "macha do przeciwnika, wyśmiewa go, wie że ma przewagę i chce sprowokować przeciwnika", "jest w pełni skupiony, dobrze wie że wygrywa. Musi teraz utrzymać swoją przewagę", "pokazuje swoją pewność siebie, zachęca rywala by bardziej się postarał. Jak ten zareaguje na ten atak psychologiczny?" };

        //remis
        public static string[] draw = {"Zawodnicy mierzą się wzrokiem, żaden nie chce ustąpić", "Walka jest bardzo wyrównana, obaj wiedzą jak reagować na swoje akcje", "Nie zazdroszczę sędziom punktowym, mają ciężki orzech do zgryzienia przy tak wyrównanym pojedynku"};
    }
}
