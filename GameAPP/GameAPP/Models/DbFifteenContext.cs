using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GameAPP.Models;

namespace GameAPP.Models
{
    public class DbFifteenContext : DbContext
    {
        public DbFifteenContext() :
        base("GameDb")
        { }
        public DbSet<Player> Players { get; set; }

        public DbSet<Record> Records { get; set; }
    }

}