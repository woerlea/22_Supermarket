using System;
using System.Collections.Generic;
using System.Text;

namespace _22_Supermarket
{
    class Control
    {
        public Shelf ShelfInventory { get; }
        public Freezer FreezerInventory { get; }
        public Fridge FridgeInventory { get; set; }
        public Product MyProduct { get; set; }
        public Supermarket Inge { get; }
        public Supermarket Supermarket { get; }

        #region Constructor
        public Control(Supermarket ingesSupermarket)
        {
            this.Supermarket = ingesSupermarket;
        }

        #endregion


        #region Methods

        // Starte Abfrage
        public void StartQuery()
        {
            Console.Clear(); // damit die eingelesenen Daten aus dem Bildschirm verschwinden
            Console.WriteLine("Drucken Sie <Enter>, um die Abfrage zu starten");
            string answer = Console.ReadLine();

            while (answer == "")
            {
                GetInfoNeeded();
            }
        }

        public void GetInfoNeeded()
        {
            Console.WriteLine("Welche Information möchten Sie bekommen?");
            Console.WriteLine("[1]- Auflistung aller Produkte; [2]- Auflistung aller Regale; [3]- Auflistung aller Produkte auf bestimmten Regalen");
            string answer = Console.ReadLine();

            switch (answer)
            {
                case "1":
                    Supermarket.GetAllFreezedProducts();
                    Supermarket.GetAllFridgeProducts();
                    Supermarket.GetAllShelfProducts();
                    break;
                case "2":
                    Supermarket.GetInventoryOfFreezers();
                    Supermarket.GetInventoryOfFridges();
                    Supermarket.GetInventoryOfShelfs();
                    break;
                case "3":
                    ChooseStorageType();
                    break;
                default:
                    break;                    

            }
            Console.ReadKey(); // damit die Console-Ausgabe bleibt
            Console.Clear(); // damit alle Console-Ausgaben verschwinden und die Abfrage neu auf dem "leeren" Console-Bild starten kann

        }

        // Wähle Regaltyp aus
        public void ChooseStorageType()
        {
            Console.WriteLine("Wählen Sie Regaltyp aus: [1]-Tiefkühlregal; [2]-Kühlregal; [3]-normales Regal");
            string answer = Console.ReadLine();
            switch (answer)
            {
                case "1":
                    Supermarket.GetInventoryOfFreezers(); // Druck zuerst die Anzahl der Regale
                    Console.WriteLine("Wählen Sie RegalNr.");
                    int nr = int.Parse(Console.ReadLine());
                    Supermarket.GetFreezedProductsPerFreezer(GetIndex(nr));
                    break;
                case "2":
                    Supermarket.GetInventoryOfFridges(); // Druck zuerst die Anzahl der Regale
                    Console.WriteLine("Wählen Sie RegalNr.");
                    int n = int.Parse(Console.ReadLine());
                    Supermarket.GetFridgeProductsPerFridge(GetIndex(n));
                    break;
                case "3":
                    Supermarket.GetInventoryOfShelfs(); // Druck zuerst die Anzahl der Regale
                    Console.WriteLine("Wählen Sie RegalNr.");
                    int x = int.Parse(Console.ReadLine());
                    Supermarket.GetShelfProductsPerShelf(GetIndex(x));
                    break;
                default:
                    break;
            }
        }

        // Damit das Regal nach Nr ausgesucht wird, muss Index für die Liste angepasst werden
        public int GetIndex(int nummer)
        {
            if (nummer > 0)
            {
                nummer -= 1;
            }
            else
            {
                Console.WriteLine("Falsche Regalnummer");
            }
            return nummer;
        }
        #endregion


    }
}
