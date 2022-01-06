using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodRecipe.Models
{
    public class BaseIngredients
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public String Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
    }
}
