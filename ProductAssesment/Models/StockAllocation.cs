namespace ProductAssesment.Models
{
    public class StockAllocation : BaseEntity
    {
        public decimal AllocatedQty { get; set; }
        public DateTime AllocatedDate { get; set; }

        // Foreign key properties
        public long ProductId { get; set; }
        public long LocationId { get; set; }

        // Navigation properties
        public Product Product { get; set; }
        public Location Location { get; set; }
    }
}
