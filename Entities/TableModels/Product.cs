using Core.Entities;

namespace Entities.TableModels
{
    /// <summary>
    /// Product table model
    /// </summary>
    public class Product : BaseEntity, IEntity
    {
        /// <summary>
        /// The name of the product
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The description of the product
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// The price of the product
        /// </summary>
        public float Price { get; set; }
        /// <summary>
        /// The photo of the product
        /// </summary>
        public string PhotoUrl { get; set; }
        /// <summary>
        /// The categoryId of the product
        /// </summary>
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
