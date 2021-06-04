using CRM.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Context
{
   public class CompanyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=ec2-63-34-97-163.eu-west-1.compute.amazonaws.com;Database=daiunk0tl6larq;UID=ecmgnxpbwbsmyi;PWD=29a54c4cd0d29a6e32285a20d4719436a50d893bfee3929c85b7ebb05b462d2c;SSL Mode= Require;TrustServerCertificate=True");
        }

        DbSet<Employee> Employees { get; set; }
        DbSet<Customer> Customers { get; set; }

    }
}
