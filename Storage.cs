using System;
using System.Collections.Generic;
using System.Text;

namespace _22_Supermarket
{
     abstract class Storage
    {
        #region Properties
        public int MaxProductsPerStorageType { get; set; }
        public int Number { get; set; }
        #endregion

        #region Constructor
        public Storage(int nr)
        {
            this.Number = nr;
        }
        #endregion

        #region Methods
        // Produkte zu Regalen hinzufügen
        public abstract void AddProduct(Product product);

        // Produkte ausgeben
        public abstract void GetProductRange();

        // Produkte auf einem Regal/in einem Kühlschrank/Tiefkühler zählen
        public abstract int GetAmountOfProductOnStorageType();

        //public abstract void Remove(int startIndex);

        #endregion
    }
}
