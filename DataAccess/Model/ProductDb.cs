namespace DataAccess.Model
{
    public class ProductDb
    {
        public int Id { get; set; }
        public string ProductCod { get; set; }
        public string  ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string  ProductDetails { get; set; }
        public string ProductImageName { get; set; }

        public string ProductImagePath { get; set; }
        public int CategoryId { get; set; }
        public virtual ProductCategory Category { get; set; }
        public virtual ItemOrder ItemOrder { get; set; }
        public int ProductItemOrderId { get; set; }

    }
}
