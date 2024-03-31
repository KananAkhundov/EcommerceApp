using Entities.TableModels;

namespace Entities.DataTransferObjects
{
    public class CategoryCreateOrUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static Category ToCategory(CategoryCreateOrUpdateDto dto)
        {
            Category category = new Category()
            {
                Id = dto.Id,
                Name = dto.Name,
            };
            return category;
        }
    }
}
