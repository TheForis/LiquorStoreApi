using DomainModels.Enums;
using System.ComponentModel.DataAnnotations;

namespace DomainModels
{
    public class Beverage : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public BeverageTypeEnum Type { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
