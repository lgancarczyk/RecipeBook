using Microsoft.EntityFrameworkCore;
using RecipeBook.Core.Database.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Core.Database
{
    public class MyDbContext : DbContext
    {
        public  DbSet<RecipeDbModel> Recipes { get; set; }
        public  DbSet<TagDbModel> Tags { get; set; }
        public DbSet<RecipeTagDbModel> RecipeTagDbModels { get; set; }
        public  DbSet<IngredientDbModel> Ingredients { get; set; }

        public DbSet<RecipeIngredientDbModel> RecipeIngredientDbModels { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            //    optionsBuilder.UseSqlite(connectionString: "Data Source = recipeBook.db");
            //}

            optionsBuilder.UseSqlite(@"Data Source=db.sqlite");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeTagDbModel>()
                .HasKey(rt => new { rt.RecipeId, rt.TagId });
            modelBuilder.Entity<RecipeTagDbModel>()
                .HasOne(rt => rt.RecipeDbModel)
                .WithMany(r => r.RecipeTagDbModels)
                .HasForeignKey(rt => rt.RecipeId);
            modelBuilder.Entity<RecipeTagDbModel>()
                .HasOne(rt => rt.TagDbModel)
                .WithMany(t => t.RecipeTagDbModels)
                .HasForeignKey(rt => rt.TagId);

            modelBuilder.Entity<RecipeIngredientDbModel>()
                .HasKey(rt => new { rt.RecipeId, rt.IngredientId });
            modelBuilder.Entity<RecipeIngredientDbModel>()
                .HasOne(rt => rt.RecipeDbModel)
                .WithMany(r => r.RecipeIngredientDbModels)
                .HasForeignKey(rt => rt.RecipeId);
            modelBuilder.Entity<RecipeIngredientDbModel>()
                .HasOne(rt => rt.IngredientDbModel)
                .WithMany(t => t.RecipeIngredientDbModels)
                .HasForeignKey(rt => rt.IngredientId);

            base.OnModelCreating(modelBuilder);


        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // configures one-to-many relationship
        //    modelBuilder.Entity<RecipeDbModel>()
        //        .HasRequire<TagDbModel>(r => r.Tags)
        //        .WithMany(t => t.Recipes)
        //        .HasForeignKey<int>(s => s.TagsIds);
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<RecipeDbModel>().HasMany(i => i.feature).WithMany();

        //    //modelBuilder.Entity<RecipeDbModel>(entity =>
        //    //{
        //    //    entity.HasKey(e => e.Id);


        //    //    entity.HasRequired


        //    //    //entity.Property(e => e.Title)
        //    //    //    .IsRequired()
        //    //    //    .HasMaxLength(50)
        //    //    //    .HasColumnName("title");
        //    //});

        //}

    }
}
