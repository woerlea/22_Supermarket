using System;
using System.Collections.Generic;
using System.Text;

namespace _22_Supermarket
{
    class Shelf : Storage
    {
        #region Properties
        public int ShelfNr { get; set; }
        List<Product> ShelfProducts = new List<Product>();

        public Shelf(int nr) : base(nr)
        {
            this.MaxProductsPerStorageType = 100;
        }
        #endregion

        #region Methods
        public override void AddProduct(Product product)
        {
            this.ShelfProducts.Add(product);
        }

        // Produkte auf den Regalen werden gedruckt
        public override void GetProductRange()
        {
            foreach (Product eachProduct in ShelfProducts)
            {
                Console.WriteLine("{0,-40} {1,10} --Art der Lagerung: {2,-20}", eachProduct.Name, eachProduct.Costs, eachProduct.TypeOfStorage);
                if (eachProduct==null)
                {
                    Console.WriteLine("leer");
                }
            }
        }

        //Produkte auf einer Regal/im Kühlschrank/Tiefkühltrue zählen
        public override int GetAmountOfProductOnStorageType()
        {
            return ShelfProducts.Count;
        }


        #endregion
    }
}
