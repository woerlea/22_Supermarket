using System;
using System.Collections.Generic;
using System.Text;

namespace _22_Supermarket
{
    class Fridge : Storage
    {
        #region Properties
        List<Product> FridgeProducts = new List<Product>();

        public Fridge(int nr) : base(nr)
        {
            this.MaxProductsPerStorageType = 150;
        }
        #endregion

        #region Methods
        // Produkte in das Kühlregal legen
        public override void AddProduct(Product product)
        {
            this.FridgeProducts.Add(product);
        }

        // Anzahl der Produkte im Kühlregal
        public override int GetAmountOfProductOnStorageType()
        {
           return FridgeProducts.Count;
        }

        // Produkte im Kühlregal ausgeben
        public override void GetProductRange()
        {
            foreach (Product prod in FridgeProducts)
            {
                Console.WriteLine("{0,-40} {1,10} --Art der Lagerung: {2,-20}", prod.Name, prod.Costs, prod.TypeOfStorage);
            }           
        }

        #endregion
    }
}
