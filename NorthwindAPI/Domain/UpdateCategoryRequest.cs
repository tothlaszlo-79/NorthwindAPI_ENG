using System.ComponentModel.DataAnnotations;

namespace NorthwindAPI.Domain
{
    public class UpdateCategoryRequest
    {
        [Required]
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
