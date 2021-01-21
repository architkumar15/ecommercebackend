using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ecommerceApplication.DAL.TableModels;


namespace ecommerceApplication.DAL.Context
{
    public class homecontext:DbContext
    {
        public homecontext(DbContextOptions<homecontext> options) : base(options)
        {

        }
        public DbSet<superAdmin> superAdmin { get; set; }
        public DbSet<companyRegister> companyRegister { get; set; }
        public DbSet<category> category { get; set; }
        public DbSet<subCategory> subCategory { get; set; }
        public DbSet<subsubCategory> subsubCategory { get; set; }
    }

}
