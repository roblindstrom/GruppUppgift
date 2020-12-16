using System;

namespace Meny
{
    class Menu
    {
        Produkter produkter = new Produkter();
        Produkt produkt = new Produkt();
        Produkt[] StartArray;
        string[] MenuOptions = { "1. Browse all Products. ", "2. Admin Login.", "3. Checkout", "4. Search Product.", "5. Exit program." };
        string[] AdminOptions = { "6. Add Product", "7. Edit Product", "8. Remove Product " };
        private bool AdminStatus = false;
        string Choice;
        bool showMenu = true;


        // --------------- Used for Handle input ---------------------//
        string[] allFruitsPurchased = new string[100];
        int[] howManyOfEachFruit = new int[100];
        int[] priceOneFruitPurchase = new int[100];
        int fruitPurchasesCount = 0;
        int priceOneFruit = 0;
        int PriceOneFruitCount = 0;
        double totalPrice = 0;
        int eachFruitCount = 0;





        public Menu()
        {
            StartArray = produkter.CreateFirstTenProducts();
        }

        // Använd DisplayMenu() för att komma tillbaka till första menyn och börja "om"
        // Den kommer ihåg om du är admin eller inte
        //Login är admin - password. Alla små bokstäver

        public void DisplayMenu()
        {

            Console.WriteLine("Enter appropriate choice and press enter.");
            while (showMenu == true)
            {
                if (AdminStatus == false)
                {
                    for (int i = 0; i < MenuOptions.Length; i++)
                    {
                        Console.WriteLine(MenuOptions[i]);


                    }
                    Choice = Console.ReadLine();
                    HandleInput(Choice);
                }

                else if (AdminStatus == true)
                {
                    for (int i = 0; i < MenuOptions.Length; i++)
                    {
                        Console.WriteLine(MenuOptions[i]);

                    }
                    for (int j = 0; j < AdminOptions.Length; j++)
                    {
                        Console.WriteLine(AdminOptions[j]);
                    }
                    Choice = Console.ReadLine();
                    HandleInput(Choice);

                }
            }
        }



        //Här är alla Meny val. Här lägger vi till fler val i huvudmenyn om det behövs

        public void HandleInput(string Choice)
        {
            int x = 0, buyAmount = 0, checkoutOrMore = 0, purchBack = 0;

            string whichFruit = "";





            if (Choice == "1")
            {
                Console.Clear();

                produkter.GetFullArray(StartArray);

                Console.WriteLine("Which fruit you want to buy?");
                Console.WriteLine("Select using the numbers from the list");
                x = int.Parse(Console.ReadLine());

                if (x - 1 >= StartArray.Length)
                {
                    Console.WriteLine("Product id does not exist");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    HandleInput("1");
                    return;
                }

                whichFruit = produkt.GetProductName(StartArray, x - 1);
                allFruitsPurchased[fruitPurchasesCount] = whichFruit;
                fruitPurchasesCount = fruitPurchasesCount + 1;

                Console.WriteLine("How many fruits do you want to buy?");
                buyAmount = int.Parse(Console.ReadLine());
                priceOneFruit = buyAmount * produkt.GetProductPrice(StartArray, x - 1);
                totalPrice = totalPrice + buyAmount * produkt.GetProductPrice(StartArray, x - 1);

                Console.WriteLine($"\nTotal price is {totalPrice}kr.");
                howManyOfEachFruit[eachFruitCount] = buyAmount;
                eachFruitCount++;

                priceOneFruitPurchase[PriceOneFruitCount] = priceOneFruit;
                PriceOneFruitCount++;




                Console.WriteLine("1. Checkout.");
                Console.WriteLine("2. Return to Main Menu");
                Console.WriteLine("3. Show ShoppingCart");
                checkoutOrMore = int.Parse(Console.ReadLine());

                if (checkoutOrMore == 1) // Checkout
                {
                    Console.Clear();
                    checkout();


                }








                if (checkoutOrMore == 2) //Return to Main
                {
                    Console.Clear();
                    DisplayMenu();
                }


                if (checkoutOrMore == 3) // show shopping cart
                {
                    showMenu = false;
                    Console.Clear();
                    Console.WriteLine("\nYour shopping cart:");
                    printShoppingCart();
                }




                Console.WriteLine("\n1. Purchase products.");
                Console.WriteLine("2. Return to main menu.");


                purchBack = int.Parse(Console.ReadLine());
                
                int mainmenuExit = 0;


                if (purchBack == 1)
                {
                    Console.Clear();
                    Console.WriteLine("\n\nPurchased:");
                    printShoppingCart();
                    purchaseRecipt();
                    ResetItemsAfterPurchase();

                    Console.WriteLine($"\n 1. Return to Main Menu.");
                    Console.WriteLine(" 2. Exit");
                    
                    mainmenuExit = int.Parse(Console.ReadLine());
                    Console.Clear();



                }

                else if (purchBack == 2)
                {
                    Console.Clear();
                    showMenu = true;
                }









                if (mainmenuExit == 1) // return main menu
                {
                    Console.Clear();
                    showMenu = true;



                }
                else if (mainmenuExit == 2)
                {
                    Environment.Exit(0);
                }
            }

            else if (Choice == "2") //Login med admin password
            {
                CheckAdminName();
            }


            else if (Choice == "3") // Checkout
            {
                Console.Clear();
                checkout();
            }
            else if (Choice == "4") //Search funktionen
            {
                showMenu = false;
                produkter.SearchProductsByName(StartArray);

                Console.WriteLine("\n\n1. Search for another product: ");
                Console.WriteLine("2. Return to main menu. ");
                Console.WriteLine("3. Exit. ");
                Choice = Console.ReadLine();


                if (Choice == "1")
                {
                    Console.Clear();
                    produkter.SearchProductsByName(StartArray);

                }


                else if (Choice == "2")
                {
                    Console.Clear();
                    showMenu = true;
                }
                else if (Choice == "3")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input.");
                    Console.WriteLine("Returning to main menu.");

                    showMenu = true;
                }

            }

            else if (Choice == "5")
            {
                // Environment.Exit(0) avslutar programmet
                Environment.Exit(0);
            }
            else if (Choice == "6" && AdminStatus == true)
            {
                //string input = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Enter a name for new product");
                string prodname = Console.ReadLine();
                Console.WriteLine("Enter Description of your new product");
                string des = Console.ReadLine();
                Console.WriteLine("Enter Price");
                int price = Convert.ToInt32(Console.ReadLine());

                StartArray = produkter.AddNewItem(StartArray, prodname, des, price);
                produkter.GetFullArray(StartArray);
            }
            else if (Choice == "7" && AdminStatus == true)
            {
                //Detta är Edit Product 

                Console.Clear();

                produkter.GetFullArrayWithoutDescription(StartArray);

                Console.WriteLine("Which product do you want to edit?");
                var pos = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("What do you want to edit?");
                Console.WriteLine("\n1. Product ID \n2. Product Name \n3. Description \n4. Price \n5. Go Back to Main Menu");

                Choice = Console.ReadLine();
                {
                    if (Choice == "1")
                    {
                        Console.WriteLine("What do you want the new Product ID to be?");
                        int newValue = Convert.ToInt32(Console.ReadLine());

                        produkt.SetProductId(StartArray, pos - 1, newValue);

                        Console.WriteLine("The new Product ID is now: " + produkt.GetProductId(StartArray, pos - 1));
                    }

                    else if (Choice == "2")
                    {
                        Console.WriteLine("What do you want the new Product Name to be?");
                        string newName = Console.ReadLine();
                        produkt.SetProductName(StartArray, pos - 1, newName);
                        Console.WriteLine("The new Product Name is now: " + produkt.GetProductName(StartArray, pos - 1));
                    }

                    else if (Choice == "3")
                    {
                        Console.WriteLine("What do you want to change the Description to?");
                        string newDescription = Console.ReadLine();
                        produkt.SetDescription(StartArray, pos - 1, newDescription);
                        Console.WriteLine("The new Description is now: " + produkt.GetProductDescription(StartArray, pos - 1));
                    }

                    else if (Choice == "4")
                    {
                        Console.WriteLine("What do you want to change the Price to?");
                        int newPrice = Convert.ToInt32(Console.ReadLine());
                        produkt.SetPrice(StartArray, pos - 1, newPrice);
                        Console.WriteLine("The new Price is now: " + produkt.GetProductDescription(StartArray, pos - 1));
                    }










                }







            }


            else if (Choice == "8" && AdminStatus == true)
            {
                Console.Clear();

                produkter.GetFullArrayWithoutDescription(StartArray);

                Console.WriteLine("Which product would you like to delete");
                Console.WriteLine("Enter ProductID: ");
                int input = Convert.ToInt32(Console.ReadLine());

                //Anropar en arraymetod som heter DeleteItem som tar bort ett ID. 
                StartArray = produkter.DeleteItem(StartArray, input);

                //Skriver ut det nya arrayvärdet
                produkter.GetFullArray(StartArray);

            }
            else if (Convert.ToInt32(Choice) > MenuOptions.Length && AdminStatus == false)
            {
                Console.WriteLine($"You have to choose a number between 1 and {MenuOptions.Length}.");
            }
            else if (Convert.ToInt32(Choice) > MenuOptions.Length + AdminOptions.Length && AdminStatus == true)
            {
                Console.WriteLine($"You have to choose a number between 1 and {MenuOptions.Length + AdminOptions.Length}.");
            }
            else
            {
                Console.WriteLine("Wrong input - Try again");
            }

            // Detta är metoden som kräver admin inlogg för att sedan spara det tills programmet stängs av.
            //Login är "admin" och "password". Alla små bokstäver
        }
        private bool CheckAdminName()
        {
            Console.Clear();
            Console.WriteLine("Enter admin login:");
            string LoginName = Console.ReadLine();

            Console.WriteLine("Enter Password:");
            string Password = Console.ReadLine();
            Console.Clear();
            while (AdminStatus == false)
            {
                if (Password == "password" && LoginName == "admin")
                {
                    AdminStatus = true;
                    Console.WriteLine("You are now logged in!");
                    Console.WriteLine("Admin access granted\n");
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong login information");
                    Console.WriteLine("Enter admin login:");
                    LoginName = Console.ReadLine();

                    Console.WriteLine("Enter Password:");
                    Password = Console.ReadLine();
                    Console.Clear();
                }
            }
            return AdminStatus;
        }

        //Skriver ut allt i Varukorgen
        public void printShoppingCart()
        {

            for (int i = 0; i < fruitPurchasesCount; i++)
            {
                if (priceOneFruitPurchase[i] > 0)
                {
                    if (howManyOfEachFruit[i] > 1)
                    {
                        Console.WriteLine(+howManyOfEachFruit[i] + " " + allFruitsPurchased[i] + "s");
                        Console.WriteLine("Price: " + priceOneFruitPurchase[i] + " kr.");
                    }
                    else
                    {
                        Console.WriteLine(+howManyOfEachFruit[i] + " " + allFruitsPurchased[i]);
                        Console.WriteLine("Price: " + priceOneFruitPurchase[i] + " kr.");
                    }
                }
            }
        }



        // Metod för Kvitto
        public void purchaseRecipt()
        {
            Console.WriteLine($"\nRecipt: Total price is {totalPrice}kr.");
            Console.WriteLine("\nThank you for shopping at fruktbutik.se");

        }


        //Metod för varukorgen
        public void ResetItemsAfterPurchase()
        {

            for (int i = 0; i < fruitPurchasesCount; i++)
            {
                allFruitsPurchased[i] = null;
                howManyOfEachFruit[i] = 0;
                priceOneFruitPurchase[i] = 0;
                totalPrice = 0;
            }
        }


        //Checkout Metoden
        public void checkout()
        {

            Console.Clear();
            Console.WriteLine("Checkout started! \n\n");
            Console.WriteLine("Please enter full name: ");
            string FullName = Console.ReadLine();

            Console.WriteLine("Please enter Adress: ");
            string Adress = Console.ReadLine();

            Console.Clear();

            Console.WriteLine($"Thank you for your purchase, {FullName}! \n");
            for (int i = 0; i < fruitPurchasesCount; i++)
            {
                if (priceOneFruitPurchase[i] > 0)
                {

                    Console.WriteLine("\nYou bought " + howManyOfEachFruit[i] + " of " + allFruitsPurchased[i] + " for the price of: "
                 + priceOneFruitPurchase[i] + "kr.\n");



                }
            }
            Console.WriteLine($"It will be delivered to {Adress}.");

            purchaseRecipt();
            ResetItemsAfterPurchase();





            Console.WriteLine($"\n 1. Go back to Main Menu. ");
            Console.WriteLine($" 2. Exit ");
            int mainMenuExit = int.Parse(Console.ReadLine());

            if (mainMenuExit == 1) // main menu
            {
                DisplayMenu();
            }

            else if (mainMenuExit == 2)
            {
                Environment.Exit(0);
            }
        }

    }
}