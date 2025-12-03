using System;

namespace MauiApp2.Models
{
    public class ListProduct
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        
        [ForeignKey(typeof(ShopList))]
        public int ShopListID { get; set; }
        
        [ForeignKey(typeof(Product))]
        public int ProductID { get; set; }
    }
}