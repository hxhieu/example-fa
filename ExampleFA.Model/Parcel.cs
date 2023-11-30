using System.Numerics;

namespace ExampleFA.Model
{
    public class Parcel
    {
        /// <summary>
        /// Unique ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// In centimetres
        /// </summary>
        public Vector3 Dimension { get; set; }

        public float? ShippingCost { get; set; }
    }
}