namespace SmallCrm.Model
{
    public class Product
    {
        /// <summary>
        /// The id of the product
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the product
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Price of the product
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// If has a Discount
        /// </summary>
        public decimal? Discount { get; set; }

        /// <summary>
        /// Description of a product
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The type of the product
        /// </summary>
        public ProductCategory Type { get; set; }
    }
}