using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TSJCommunication.Models;
using System.Configuration;

namespace TSJCommunication.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext() : base("PrimaryConnectionString")
        { }

        public DataContext(string connectionString)
        {
            
            Database.Connection.ConnectionString = connectionString;
        }

        public DbSet<Votes> Votes { get; set; }
        
        public DbSet<Polls> Polls { get; set; }

        public DbSet<Options> Options { get; set; }

        public DbSet<UserSuggestion> UserSuggestions { get; set; }
    }
}