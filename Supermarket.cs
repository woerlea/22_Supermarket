using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _22_Supermarket
{
    class Supermarket
    {
        #region Properties
        public string Name { get; set; } // Name des Supermarktes
        List<Freezer> IngesFreezers = new List<Freezer>(); // Liste aller TK-Truhen
        List<Shelf> IngesShelfs = new List<Shelf>(); // Liste aller Regalen
        List<Fridge> IngesFridges = new List<Fridge>(); // Liste aller Kühlregalen


        List<Product> ProductList = new List<Product>();
        
        #endregion

        #region Constructor
        public Supermarket()
        {
            this.Name = "Inge";
        }
        #endregion

        #region Methods
        // Erfasse alle TK-Truhen
        public void AddFreezerToList(Freezer newFreezer)
        {
            IngesFreezers.Add(newFreezer);
        }

        // Erfasse alle normale Regale
        public void AddShelfsToList(Shelf newShelf)
        {
            IngesShelfs.Add(newShelf);
        }

        // Erfasse alle Kühlregale
        public void AddFridgesToList(Fridge newFridge)
        {
            IngesFridges.Add(newFridge);
        }               

        // Zähle und gib alle TK-Truhen im Laden aus
        public void GetInventoryOfFreezers()
        {
            Console.WriteLine($"Supermarkt '{Name}' hat {IngesFreezers.Count} Tiefkühltruhen mit insges. {GetSumOfFreezedProducts()} tiefgekühlten Produkten");
        }

        // Zähle und gib alle Kühlregale im Laden aus
        public void GetInventoryOfFridges()
        {
            Console.WriteLine($"Supermarkt '{Name}' hat {IngesFridges.Count} Kühlregale mit insges. {GetSumOfFridgeProducts()} gekühlten Produkten");
        }

        // Zähle und gib alle normale Regale im Laden aus
        public void GetInventoryOfShelfs()
        {
            Console.WriteLine($"Supermarkt '{Name}' hat {IngesShelfs.Count} Regale mit {GetSumOfShelfProducts()} Produkten (Zimmmertemperaturlagerung)");
        }

        // Anzahl aller TK-Produkten in allen TK-Truhen
        public int GetSumOfFreezedProducts()
        {
            int sum = 0;
            foreach (Freezer item in IngesFreezers)
            {
               sum+= item.GetAmountOfProductOnStorageType();
            }
            return sum;
        }

        // Anzahl aller kühl gelagerten Produkten in allen Kühlregalen
        public int GetSumOfFridgeProducts()
        {
            int sum = 0;
            foreach (Fridge item in IngesFridges)
            {
                sum += item.GetAmountOfProductOnStorageType();
            }
            return sum;
        }

        // Anzahl aller Produkten in normalen Regalen
        public int GetSumOfShelfProducts()
        {
            int sum = 0;
            foreach (Shelf item in IngesShelfs)
            {
                sum += item.GetAmountOfProductOnStorageType();
            }
            return sum;
        }

        // Ausgabe aller Produkten in normalen Regalen
        public void GetAllShelfProducts()
        {
            foreach (Shelf item in IngesShelfs)
            {
                item.GetProductRange();
            }
        }

        // Ausgabe aller TK-Produkten
        public void GetAllFreezedProducts()
        {
            foreach (Freezer item in IngesFreezers)
            {
                item.GetProductRange();
            }
        }

        // Ausgabe aller Kühlregalprodukten
        public void GetAllFridgeProducts()
        {
            foreach (Fridge item in IngesFridges)
            {
                item.GetProductRange();
            }
        }

        // Produkte im bestimmten Regal (nach Regalnummer) ausgeben)
        public void GetFreezedProductsPerFreezer(int index)        
        {
            if (IngesFridges[index].GetAmountOfProductOnStorageType() > 0) // wenn TK-Truhe befüllt is
            {
                IngesShelfs[index].GetProductRange(); // gib die Produkte aus
            }
            else
            {
                Console.WriteLine("Diese Tiefkühltrue ist leer");
            }

        }

        // Produkte im bestimmten Regal (nach Regalnummer) ausgeben)
        public void GetFridgeProductsPerFridge(int index)
        {
            if (IngesFridges[index].GetAmountOfProductOnStorageType() > 0) // wenn Regal befüllt ist
            {
                IngesFridges[index].GetProductRange(); // gib die Produkte aus
            }
            else
            {
                Console.WriteLine("Dieses Kühlregal ist leer");
            }


        }

        // Produkte im bestimmten Regal (nach Regalnummer) ausgeben)
        public void GetShelfProductsPerShelf(int index)
        {
            if (IngesShelfs[index].GetAmountOfProductOnStorageType() > 0) // wenn Regal befüllt ist
            {
                IngesShelfs[index].GetProductRange(); // gib die Produkte aus
            }
            else
            {
                Console.WriteLine("Dieses Regal ist leer");
            }
            
        }
        #endregion
    }
}
