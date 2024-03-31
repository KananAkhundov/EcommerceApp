using Entities.TableModels;

namespace Entities.DataTransferObjects
{
    public class ProductCreateOrUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string PhotoUrl { get; set; }
        public int CategoryId { get; set; }

        public static Product ToProduct(ProductCreateOrUpdateDto dto)
        {
            Product product = new Product()
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                PhotoUrl = dto.PhotoUrl,
                CategoryId = dto.CategoryId
            };
            return product;
        }
    }
}
