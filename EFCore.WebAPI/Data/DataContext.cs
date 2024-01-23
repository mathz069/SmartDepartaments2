using System;
using Microsoft.EntityFrameworkCore;
using EFCore.WebAPI.Models;
using System.Collections.Generic;

namespace EFCore.WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

    }
}