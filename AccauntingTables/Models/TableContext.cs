using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AccauntingTables.Models
{
    public class TableContext : DbContext
    {
        public DbSet<Table> Table { get; set; }
        public DbSet<Owner> Owner { get; set; }

        public TableContext(DbContextOptions<TableContext> options) : base(options) { }
    }
}
