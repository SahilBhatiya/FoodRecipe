using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodRecipe.Models
{
    public class UsedIngredients
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public String Id { get; set; }
        public float Qty { get; set; }
        public virtual String? BaseIndredientsId { get; set; }
        public virtual String? RecipeId { get; set; }
        public virtual String? QtyTypeId { get; set; }

        [ForeignKey("RecipeId")]
        public virtual Recipe Recipe { get; set; }

        [ForeignKey("QtyTypeId")]
        public virtual QtyType? qtyType { get; set; }

        [ForeignKey("BaseIndredientsId")]
        public virtual BaseIngredients? baseIngredients { get; set; }
    }
}
