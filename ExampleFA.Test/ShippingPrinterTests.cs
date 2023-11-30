using ExampleFA.Model;

namespace ExampleFA.Test
{
    [TestClass]
    public class ShippingPrinterTests
    {
        [TestMethod]
        public async Task ShippingPrinter_Print_Costs ()
        {
            var printer = new ShippingCostPrinter();
            var parcels = new Parcel[]
            {
                new Parcel
                {
                    Id = "id-1",
                    ShippingCost = 3.0m,
                },
                new Parcel
                {
                    Id = "id-2",
                    ShippingCost = 8.0m,
                },
                new Parcel
                {
                    Id = "id-3",
                    ShippingCost = 15.0m,
                }
            };

            var expectedOutput = new ShippingCostLayout
            {
                Items =  new Dictionary<string,decimal?>
                {
                    {"id-1", 3.0m },
                    {"id-2", 8.0m },
                    {"id-3", 15.0m },
                }
            };

            var actualOutput = await printer.PrintShippingCost(parcels);

            Assert.AreEqual(expectedOutput.Total, actualOutput.Total);
            CollectionAssert.AreEquivalent(actualOutput.Items, expectedOutput.Items);
        }
    }
}
