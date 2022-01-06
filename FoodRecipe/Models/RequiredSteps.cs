using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodRecipe.Models
{
    public class RequiredSteps
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public String Id { get; set; }
        public String Image { get; set; }
        public int SerialNumber { get; set; }
        public String HeadingName { get; set; }
        public String Description { get; set; }
        public TimeSpan RTLower { get; set; }
        public TimeSpan RTUpper { get; set; }
        public virtual String RecipeId { get; set; }

        [ForeignKey("RecipeId")]
        public virtual Recipe Recipe { get; set; }
    }
}
