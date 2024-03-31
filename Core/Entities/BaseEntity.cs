namespace Core.Entities
{
    /// <summary>
    /// Hər bir database modeli bu sinifdən miras almalıdır
    /// və bu sinifdə hər bir cədvəl üçün istifadə olunan sütunların prop-ları
    /// saxlanılacaqdır
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Sətirin identifikasiya nömrəsi
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Sətirin yaradılma tarixi
        /// </summary>

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Sətirin son redaktə tarixi
        /// </summary>
        public DateTime? LastUpdateDate { get; set; }

        /// <summary>
        /// Sətir fiziki olaraq silinmədiyindən silinmiş
        /// sətirin identifikasiya nömrəsi saxlanılır
        /// </summary>
        public int Deleted { get; set; }
    }
}
