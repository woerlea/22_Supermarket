using System;
using System.Text;
using System.Collections.Generic;

namespace _22_Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            // Die Datei einlesen
            string URL = @"C:\Users\DCV\Documents\DigitalCampusAufgaben\OOP\OOP\22_Supermarket\MOCK_DATA.txt";
            string text = System.IO.File.ReadAllText(URL);
            Console.OutputEncoding = Encoding.UTF8; // damit Euro-Zeichen gedruckt wird
            Console.WriteLine(text);

            // Produkte anhand der .txt initializieren
            List<Product> allProducts = new List<Product>();
            Supermarket ingeMarket = new Supermarket();            

            try
            {
                //Textzeilen
                string[] lines = System.IO.File.ReadAllLines(URL);

                for (var i = 1; i < lines.Length - 1; i++)
                {
                    var splittedValues = lines[i].Split(';');

                    var product = new Product();
                    {
                        product.Id = splittedValues[0]; // gemäss Property
                        product.Costs = splittedValues[1]; // gemäss Property
                        product.Name = splittedValues[2];   // gemäss Property 
                        product.UseBefore = splittedValues[3];
                        product.FoodSort = (FoodType)Enum.Parse(typeof(FoodType), splittedValues[4].ToUpper());
                        product.TypeOfStorage = (StorageType)Enum.Parse(typeof(StorageType), splittedValues[5].ToUpper());
                    }
                    // Produkte werden in der Liste gespeichert
                    allProducts.Add(product);
                   // ingeMarket.AddToProductList(product);
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine("===============================");

            // Angenommen, der Laden hat 5 Regale für normal lagernde Ware => erstelle 5 Obj Regal
            Shelf shelf = new Shelf(1);
            Shelf shelf2 = new Shelf(2);
            Shelf shelf3 = new Shelf(3);
            Shelf shelf4 = new Shelf(4);

            // Angenommen, der Laden hat 3 Kühlregale => erstelle 3 Objekte Kühlregal
            Freezer freezer = new Freezer(1); // erstelle ein Obj Tiefkühltrue
            Freezer freezer2 = new Freezer(2); // erstelle ein Obj Tiefkühltrue
            Freezer freezer3 = new Freezer(3); // erstelle ein Obj Tiefkühltrue

            // Angenommen, der Laden hat Tiefkühltruhen => erstelle 2 TK-Truhen
            Fridge fridge = new Fridge(1); // erstelle ein Obj Kühlregal
            Fridge fridge2 = new Fridge(2); // erstelle ein Obj Kühlregal
            Fridge fridge3 = new Fridge(3); // erstelle ein Obj Kühlregal
            Fridge fridge4 = new Fridge(4); // erstelle ein Obj Kühlregal



            // Ordne die Produkte jeweiligen Regalen zu
            foreach (Product prod in allProducts)
            {
                switch (prod.TypeOfStorage)
                {
                    // Wenn das Produkt auf das Regal gehört: 
                    case StorageType.NORMAL:

                        //Wenn das Regal noch Platz hat(< 100)                
                        if (shelf.GetAmountOfProductOnStorageType() < shelf.MaxProductsPerStorageType) 
                        {
                            // befülle Regal nr.!
                            shelf.AddProduct(prod);
                        }
                        // wenn das Regal 2 Platz hat (<100)
                        else if (shelf2.GetAmountOfProductOnStorageType() < shelf.MaxProductsPerStorageType)
                        {
                            //befülle Regal 2
                            shelf2.AddProduct(prod);
                        }                         
                        else if (shelf3.GetAmountOfProductOnStorageType() < shelf.MaxProductsPerStorageType)
                        {
                            shelf3.AddProduct(prod);
                        }
                        else if (shelf4.GetAmountOfProductOnStorageType() < shelf.MaxProductsPerStorageType)
                        {
                            shelf4.AddProduct(prod);
                        }
                        else
                        {
                           // Console.WriteLine("Alle Regale sind voll");
                        }                    
                            break;

                    //Wenn das Produkt in die Tiefkühltrue gehört:
                    case StorageType.FREEZER:
                         // wenn die TK-Truhe 1 Platz hat (<100)
                        if (freezer.GetAmountOfProductOnStorageType() < freezer.MaxProductsPerStorageType)
                        {
                            //befülle TK-Truhe1
                            freezer.AddProduct(prod);
                        }
                        else if (freezer2.GetAmountOfProductOnStorageType() < freezer2.MaxProductsPerStorageType)
                        {
                            freezer.AddProduct(prod);
                        }
                        else if (freezer3.GetAmountOfProductOnStorageType() < freezer3.MaxProductsPerStorageType)
                        {
                            freezer3.AddProduct(prod);
                        }
                        break;                        

                    // Wenn das Produkt in den Kühlschrank gehört: 
                    case StorageType.FRIDGE:
                        //wenn das Kühlregal Nr1 Platz hat,
                        if (fridge.GetAmountOfProductOnStorageType() < fridge.MaxProductsPerStorageType)
                        {
                            //befülle das Kühlregal 1
                            fridge.AddProduct(prod);
                        }
                        else if (fridge2.GetAmountOfProductOnStorageType() < fridge2.MaxProductsPerStorageType)
                        {
                            fridge2.AddProduct(prod);
                        }
                        else if (fridge3.GetAmountOfProductOnStorageType() < fridge3.MaxProductsPerStorageType)
                        {
                            fridge3.AddProduct(prod);
                        }
                        else if (fridge4.GetAmountOfProductOnStorageType() < fridge4.MaxProductsPerStorageType)
                        {
                            fridge4.AddProduct(prod);
                        }
                        break;
                    default:
                        Console.WriteLine("Achtung! Ein Produkt ist nicht versorgt");
                        break;
                }
            }

            // Supermarket hat TK-Truhen (trage in die Liste ein)
            ingeMarket.AddFreezerToList(freezer);
            ingeMarket.AddFreezerToList(freezer2);
            ingeMarket.AddFreezerToList(freezer3);

            // Supermarket hat Kühlregale (trage in die Liste ein)
            ingeMarket.AddFridgesToList(fridge);
            ingeMarket.AddFridgesToList(fridge2);
            ingeMarket.AddFridgesToList(fridge3);
            ingeMarket.AddFridgesToList(fridge4);

            //Supermarket hat Regale (trage normale Regale in die Liste ein)
            ingeMarket.AddShelfsToList(shelf);
            ingeMarket.AddShelfsToList(shelf2);
            ingeMarket.AddShelfsToList(shelf3);
            ingeMarket.AddShelfsToList(shelf4);

            Console.WriteLine("===========================");

            // Erstelle Obj myConsole, um die Abfragen zu starten
            Control myConsole = new Control(ingeMarket);
            myConsole.StartQuery();


            

        }
    }     
    
}
