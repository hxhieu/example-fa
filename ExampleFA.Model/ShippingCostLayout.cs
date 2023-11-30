namespace ExampleFA.Model
{
    public class ShippingCostLayout
    {
        public decimal? Total
        {
            get
            {
                var total = 0.0m;
                foreach (var item in Items)
                {
                    // If an items not been calculated then the whole Total is not calculated as well
                    if (item.Value == null)
                    {
                        return null;
                    }
                    total += (decimal)item.Value;
                }
                return total;
            }
        }
        public Dictionary<string, decimal?> Items { get; set; } = new Dictionary<string, decimal?>();
    }
}
