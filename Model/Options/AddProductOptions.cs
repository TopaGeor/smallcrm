namespace SmallCrm.Model.Options
{
    public class AddProductOptions
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
        /// The price of the product
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The category of the product
        /// </summary>
        public ProductCategory Category { get; set; }
    }
}
