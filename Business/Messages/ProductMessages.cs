namespace Business.Messages
{
    public static class ProductMessages
    {
        public static readonly string ProductNameMaximumLength = "Maximum length for product name is 200 symbols";
        public static readonly string ProductNameMinimumLength = "Minimum length for product name is 3 symbols";
        public static readonly string ProductNameCannotBeEmpty = "Name cannot be empty";

        public static readonly string ProductDescriptionMaximumLength = "Maximum length for product description is 5000 symbols";
        public static readonly string ProductDescriptionMinimumLength = "Minimum length for product description is 3 symbols";
        public static readonly string ProductDescriptionCannotBeEmpty = "Description cannot be empty";

        public static readonly string ProductPriceCannotBeEmpty = "Price cannot be empty";

        public static readonly string ProductPhotoUrlCannotBeEmpty = "Photo cannot be empty";

        public static readonly string ProductCategoryIdCannotBeEmpty = "Category cannot be empty";
    }
}
