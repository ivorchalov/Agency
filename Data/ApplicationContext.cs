using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StrAgent.Models;
using StrAgent.Models.Roles;
using Microsoft.EntityFrameworkCore;

namespace StrAgent.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public DbSet<Admin> Admins { get; set; } = null!;
        public DbSet<Agent> Agents { get; set; } = null!;
        public DbSet<Policyholder> Policyholders { get; set; } = null!;

        public DbSet<Dogovor> Dogovors { get; set; } = null!;
        public DbSet<StrSl> StrSls { get; set; } = null!;
        public DbSet<Tarif> Tarifs { get; set; } = null!;

        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

    }
}
