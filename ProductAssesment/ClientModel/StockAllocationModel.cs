namespace ProductAssesment.ClientModel
{
    public class StockAllocationModel
    {
        public long Id { get; set; }
        public decimal AllocatedQty { get; set; }
        public DateTime AllocatedDate { get; set; }
        public long ProductId { get; set; }
        public long LocationId { get; set; }
        public LocationModel LocationModel { get; set; }
        public ProductModel ProductModel { get; set; }
    }
}
