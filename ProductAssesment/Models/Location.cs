namespace ProductAssesment.Models
{
    public class Location :BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public ICollection<StockAllocation> StockAllocations { get; set; }
    }
}
