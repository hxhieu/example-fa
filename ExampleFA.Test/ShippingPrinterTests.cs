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
                    ShippingCost = 3.0f,
                },
                new Parcel
                {
                    Id = "id-1",
                    ShippingCost = 8.0f,
                },
                new Parcel
                {
                    Id = "id-1",
                    ShippingCost = 15.0f,
                }
            };

            var expectedOutput = new Dictionary<string,float>
            {
                {"id-1", 3.0f },
                {"id-2", 8.0f },
                {"id-3", 15.0f },
            };

            var actualOutput = await printer.PrintShippingCost(parcels);

            CollectionAssert.AreEquivalent(actualOutput, expectedOutput);
        }
    }
}
