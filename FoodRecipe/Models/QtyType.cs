using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodRecipe.Models
{
    public class QtyType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public String Id { get; set; }
        public String Name { get; set; }
        public String ShortForm { get; set; }
    }
}
