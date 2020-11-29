using System;
using System.Collections.Generic;
using System.Text;

namespace _22_Supermarket
{
    public enum FoodType
    {
        SWEETS,
        FRUITS,
        VEGETABLES,
        ALCOHOL
    }
    public enum StorageType
    {
        FREEZER,
        FRIDGE,
        NORMAL
    }
    class Product
    {
        #region Properties
        public string Name { get; set; }
        public string Id { get; set; }
        public string UseBefore { get; set; }
        public string Costs { get; set; }
        public string ProdurctType { get; set; }
        public StorageType TypeOfStorage { get; set; }
        public FoodType FoodSort { get; set; }

        #endregion




    }
}
