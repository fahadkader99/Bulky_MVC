using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data

    // This is a DB configuration class | any DB related things comes here
{
    public class ApplicationDbContext : DbContext                   // DbContext is root class for using Entity framework.
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)         // This is how we pass the configuration options to the base class
        {
                /* This class is implementing default DbContext > which is Root class coming from Entity framework core, 
                 * which is needed to use Entity framework.
                 * 
                 * Many other class might be exting this class.
                 * 
                 * Also we are passing the options obj to the base class, this is how we pass in C#
                 * 
                 * This is Entity framework core config file, now Entity framework core ready to be consumed by this project
                 * 
                 * Console: update-database             // to create DB from the console. 
                 * 
                 */
        }

        public DbSet<Category> Categories { get; set; }
        /*
         * A new table with name: Categories will be created from the above line (power of Entity)
         * 
         * nuget console: 1. add-migration migrationName
         *                2. update-database (to finish up migration & create the table)
         * 
         * ex: add-migration AddCategoryTableToDb
         */


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(  // creating new obj for entity / records for table
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Sci-fi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Horror", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Funny", DisplayOrder = 4 },
                new Category { Id = 5, Name = "Adventure", DisplayOrder = 5 }

                );
        }
        /*
         * using this modelbuilder we can see data
         * we can use this modebuilder to feed entity to the bd
         * this is a default setup from Entity framework to seed data, nothing to learn here
         */


    }
}
