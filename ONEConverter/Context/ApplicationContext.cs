using Microsoft.EntityFrameworkCore;
using ONEConverter.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ONEConverter.Context
{
    public class ApplicationContext: DbContext
    {
        public DbSet<SysColorSchemeIndexed> SysColorSchemeIndexeds { get; set; }
        public DbSet<SysColorSchemeColored> SysColorSchemeColoreds { get; set; }
        public DbSet<SysColorSchemeIndexedDetail> SysColorSchemeIndexedDetails { get; set; }
        public DbSet<SysColorSchemeDetail> SysColorSchemeDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=CAT-PROD-04\\SQLEXPRESS;Database=ExtractorDatabase_Debug;MultipleActiveResultSets=True;Integrated Security=True;");
        }

    }
}
