using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Auh_angular_netcore.Entities;
using Auh_angular_netcore.ir.Entities;
using Microsoft.EntityFrameworkCore;


namespace Auh_angular_netcore.DataLayer.Context
{
    public class OghabContext : DbContext
    {
        public OghabContext(DbContextOptions<OghabContext> options) : base(options)
        {

        }

        #region User
        public DbSet<User> Users { get; set; }

        #endregion
        #region Course
        public DbSet<Course> Course { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;



        }
    }
}
