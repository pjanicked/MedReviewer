using MedReviewer.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedReviewer.Core.DatabaseContext
{
    public class DataContext : DbContext
    {
        public DataContext() : base("MedReviewerContext")
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;             
        }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
