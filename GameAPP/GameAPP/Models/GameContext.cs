using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GameAPP.Models;

namespace GameAPP.Models
{
    public class GameContext : DbContext
    {
        public DbSet<Player> Players { get; set; }

        public DbSet<Record> Records { get; set; }
    }

    public class DbGameInitializer : DropCreateDatabaseAlways<GameContext>
    {
        protected override void Seed(GameContext db)
        {
            db.Players.Add(new Player { Login = "", Password = "" });
            //db.Records.Add(new Record { Login = "", Lvl = 1, StepCount = 0 });
            base.Seed(db);
            //db.SaveChanges();
        }
    }
}