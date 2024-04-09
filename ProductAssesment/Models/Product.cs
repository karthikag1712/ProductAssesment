namespace ProductAssesment.Models
{
    public class Product: BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal StockAvailable { get; set; }
        public decimal UnitPrice { get; set; }
        public ICollection<StockAllocation> StockAllocations { get; set; }
    }
}
