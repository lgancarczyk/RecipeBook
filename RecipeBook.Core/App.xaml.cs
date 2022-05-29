using Microsoft.EntityFrameworkCore;
using RecipeBook.Core.Database;
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
        protected override void OnStartup(StartupEventArgs e)
        {

            Db();
            base.OnStartup(e);
        }

        public void Db()
        {
            using var dbContext = new MyDbContext();

            dbContext.Database.EnsureCreated();
        }
    }
}
