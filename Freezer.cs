using System;
using System.Collections.Generic;
using System.Text;

namespace _22_Supermarket
{
    class Freezer : Storage
    {
        #region Properties
        List<Product> FreezedProducts = new List<Product>();

        public Freezer(int nr) : base(nr)
        {
            this.MaxProductsPerStorageType = 100;
        }
        #endregion

        #region Methods
        // Produkte in das Kühlregal legen
        public override void AddProduct(Product product)
        {
            this.FreezedProducts.Add(product);
        }

        // Anzahl der Produkte im Kühlregal
        public override int GetAmountOfProductOnStorageType()
        {
            return FreezedProducts.Count;
        }

        // Produkte im Kühlregal ausgeben
        public override void GetProductRange()
        {
            foreach (Product prod in FreezedProducts)
            {              
                Console.WriteLine("{0,-40} {1,10} --Art der Lagerung: {2,-20}",prod.Name,prod.Costs,prod.TypeOfStorage);                
            }
        }      

        #endregion
    }
}
