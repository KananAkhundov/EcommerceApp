using Core.Entities;

namespace Entities.TableModels
{
    /// <summary>
    /// Category table model
    /// </summary>
    public class Category : BaseEntity, IEntity
    {
        public Category()
        {
            Products= new HashSet<Product>();
        }
        /// <summary>
        /// The name of the category
        /// </summary>
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
