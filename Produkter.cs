class Produkter
{
    
    Produkt produkt = new Produkt();
    //Här skapar vi vår första Array som är grunden för affären

    public Produkt[] CreateFirstTenProducts()
    {
        Produkt[] TempArray = new Produkt[10];

        Produkt Banana = new Produkt(1, "Banana", "A yellow fruit, botanically a berry.", 5);
        Produkt Watermelon = new Produkt(2, "Watermelon", "A plant species in the family Cucurbitaceae.", 20);
        Produkt Orange = new Produkt(3, "Orange", "A fruit of various citrus species.", 4);
        Produkt Apple = new Produkt(4, "Apple", "A fruit produced by an apple tree, originated in Central Asia.", 2);
        Produkt Grapes = new Produkt(5, "Grapes", "Grapes is botanically a berry, comes in various colors and sizes.", 25);
        Produkt Zucchini = new Produkt(6, "Zucchini", "Zucchini can reach nearly 1 metre (40 inches) in length, but is usually harvested when still immature at about 15 to 25 cm.", 15);
        Produkt Cucumber = new Produkt(7, "Cucumber", "Consists of 95% water. The cucumber originates from South Asia, but now grows on most continents.", 12);
        Produkt Tomato = new Produkt(8, "Tomato", "Red edible berry originated in western South America and Central America.", 3);
        Produkt RedOnion = new Produkt(9, "Red Onion", "Red onions are cultivars of the onion (Allium cepa) with purplish-red skin and white flesh tinged with red. They are most commonly used in the culinary arts, but the skin of the red onion has also been used as a dye.", 2);
        Produkt Mushroom = new Produkt(10, "Mushroom", "Two color states while immature - white and brown - both of which have various names, with additional names for the mature state.", 3);

        TempArray[0] = Banana;
        TempArray[1] = Watermelon;
        TempArray[2] = Orange;
        TempArray[3] = Apple;
        TempArray[4] = Grapes;
        TempArray[5] = Zucchini;
        TempArray[6] = Cucumber;
        TempArray[7] = Tomato;
        TempArray[8] = RedOnion;
        TempArray[9] = Mushroom;

        return TempArray;
    }

    //Här lägger vi till ytterligare ett objekt rakt in i vår Array

    public Produkt[] AddNewItem(Produkt[] AvailableProduct, string ProName, string Des, int Price)
    {
        Produkt NewItem = new Produkt(AvailableProduct.Length + 1, ProName, Des, Price);
        Produkt[] NewProductItems = new Produkt[AvailableProduct.Length + 1];

        for (int i = 0; i < AvailableProduct.Length; i++)
        {
            NewProductItems[i] = AvailableProduct[i];
        }
        NewProductItems[NewProductItems.Length - 1] = NewItem;
        return NewProductItems;
    }

    //Skriver ut hela Arrayn som läggs innanför (ArrayName)

    public void GetFullArray(Produkt[] Array)
    {
        WriteArray(Array);

        void WriteArray(Produkt[] array)
        {
            foreach (Produkt element in array)
            {
                if (element != null)
                {
                    System.Console.WriteLine(element.GetProductId() + ") " + element.GetProductName() + " " + "\n Description: " + element.GetProductDescription() + "\n Price: " + element.GetProductPrice() + "kr/st \n ");
                }
            }
        }
    }

    public void GetFullArrayWithoutDescription(Produkt[] Array)
    {
        WriteArray(Array);

        void WriteArray(Produkt[] array)
        {
            foreach (Produkt element in array)
            {
                if (element != null)
                {
                    System.Console.WriteLine(element.GetProductId() + ") " + element.GetProductName() + " " +  "\n Price: " + element.GetProductPrice() + "kr/st \n ");
                }
            }
        }
    }
    public Produkt[] DeleteItem(Produkt[] DeleteSpecificItem, int ProductId)
    {

        //Skapa en ny array med samma längd som DeleteSpecificItem
        Produkt[] NewProductItems = new Produkt[DeleteSpecificItem.Length];

        //Gå igenom DeleteSpecificItem och kopiera inte över det angivna produktIdt
        for (int i = 0; i < DeleteSpecificItem.Length; i++)
        {
            if (ProductId != DeleteSpecificItem[i].GetProductId())
            {
                //Kopiera över DeleteSpecifikItem arrayn till NewProductItems arrayn
                NewProductItems[i] = DeleteSpecificItem[i];
            }

        }
        //Returnera den nya arrayn, utan den borttagna ID:t
        return NewProductItems;
    }
    public void SearchProductsByName(Produkt[] ProduktArray)
    {
        Meny.Menu MyMenu = new Meny.Menu();
        Produkt pd = null;
        System.Console.WriteLine("Skriv namnet på produkten");
        string pname = System.Console.ReadLine();
        foreach (Produkt rs in ProduktArray)
        {
            if (pname == rs.GetProductName())
            {
                pd = rs;
                System.Console.WriteLine($"{rs.GetProductId()}. {rs.GetProductName()} \nPrice: {rs.GetProductPrice()} kr/st");
                if (pd != null)
                {
                    System.Console.WriteLine("The product is found");
                }
            }
        }
        if (pd == null)
        {

            System.Console.WriteLine("The product is not found \n\n");
            MyMenu.DisplayMenu();
        }


    }
}