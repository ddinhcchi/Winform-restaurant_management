using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHDTO
{
    public class TotalBill
    {
        private float totalPrice;
        private float price;
        private int count;
        private string foodName;
        private string idFood;

        public string FoodName { get => foodName; set => foodName = value; }
        public int Count { get => count; set => count = value; }
        public float Price { get => price; set => price = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
        public string IdFood { get => idFood; set => idFood = value; }
    }
}
