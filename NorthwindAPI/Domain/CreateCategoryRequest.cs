using System.ComponentModel.DataAnnotations;

namespace NorthwindAPI.Domain
{
    public class CreateCategoryRequest
    {
        [Required]//This attribute is used to validate the property value. It checks if the value is null or empty.
        public short CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }

        public string Description { get; set; }
    }
}
