using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodRecipe.Models
{
    public class Recipe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public String Id { get; set; }
        public String Name { get; set; }
        public String AuthorName { get; set; }
        public String? Description { get; set; }
        public String? Image { get; set; }
        public TimeSpan PrepTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public float Qty { get; set; }
        public virtual String? UserId { get; set; }
        public virtual String? QtyTypeId { get; set; }

        [ForeignKey("UserId")]
        public virtual IdentityUser? User { get; set; }
        [ForeignKey("QtyTypeId")]
        public virtual QtyType? qtyType { get; set; }
    }
}
