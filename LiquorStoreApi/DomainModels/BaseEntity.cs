using System.ComponentModel.DataAnnotations;

namespace DomainModels
{
    public abstract class BaseEntity
    {
        [Required]
        public int Id { get; set; }

    }
}
