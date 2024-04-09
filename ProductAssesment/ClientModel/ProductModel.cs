namespace ProductAssesment.ClientModel
{
    public class ProductModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal StockAvailable { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
