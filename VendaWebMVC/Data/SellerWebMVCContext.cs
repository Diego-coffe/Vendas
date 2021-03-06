using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VendaWebMVC.Models;

namespace VendaWebMVC.Data
{
    public class SellerWebMVCContext : DbContext
    {
        public SellerWebMVCContext (DbContextOptions<SellerWebMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<RecordVendas> RecordVendas { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
    }
}
