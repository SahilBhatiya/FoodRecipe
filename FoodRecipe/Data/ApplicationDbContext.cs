using FoodRecipe.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodRecipe.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options )
            : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; } 
        public DbSet<BaseIngredients> BaseIngredients { get; set; }
        public DbSet<UsedIngredients> Ingredients { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<RequiredSteps> Steps { get; set; }
        public DbSet<QtyType> QtyTypes { get; set; }
    }
}