namespace SmallCrm.Model.Options
{
    public class UpdateProductOptions
    {
        /// <summary>
        /// If we want to change the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// If we want to change the price
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// If we want to change the Discount
        /// </summary>
        public decimal? Discount { get; set; }

        /// <summary>
        /// Changes in Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// If we change the category
        /// </summary>
        public ProductCategory Category { get; set; }
    }
}
