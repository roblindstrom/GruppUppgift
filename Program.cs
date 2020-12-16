using Meny;
using System;

namespace FruktButik
{
    class Program
    {
        static void Main(string[] args)
        {
            //Vi skapar ett Objekt av klassen Meny som gör att vi kan köra igång menyn nedanför

            Menu MyMenu = new Menu();

            //Detta är endast lite text
            Console.WriteLine("Welcome to the Fruitshop!");
            Console.WriteLine();

            //Nu är det fixat så DisplayMenu() hanterar nästan allt med att köra menyn så vi behöver inte loopa den i main längre.
            MyMenu.DisplayMenu();


            //Detta är rätt version
        }

    }
}