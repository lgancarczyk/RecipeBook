using Microsoft.EntityFrameworkCore;
using RecipeBook.Core.DBContext;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RecipeBook.Core
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string connectionString = "Data Source = recipeBook.db";

        protected override void OnStartup(StartupEventArgs e)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(connectionString).Options;
            RecipeBookDbContext dbContext = new RecipeBookDbContext(options);
            dbContext.Database.Migrate();
            base.OnStartup(e);
        }
    }
}
