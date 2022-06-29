using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2dn
{
    public class Product
    {
        public string _ProductID { get; set; }
        public string _ProductName { get; set; }
        public string _ManufacturerName { get; set; }
        public double _ProductWeightPack { get; set; }
        public double _ProductPrice { get; set; }
        public List<ProductArrivalDates> _productArrivalDates = new List<ProductArrivalDates>();
        public void ArrivalDate(Storage storage, DateTime date, int amount)
        {
            if (amount * this._ProductWeightPack < storage._MaxWeight - storage._CurrentWeight)
            {
                _productArrivalDates.Add(new ProductArrivalDates
                {
                    _ProductStorage = storage,
                    _Date = date,
                    _AmountOfProductPacks = amount
                });
                storage._CurrentWeight += amount * this._ProductWeightPack;
            }
            else
            {
                Console.WriteLine("Sorry, storage {0} is full. Choose another one.", storage._StorageID);
            }
        }
    }
}
