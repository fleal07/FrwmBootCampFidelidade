﻿using FrwkBootCampFidelidade.Dominio.Base.Interfaces;
using FrwkBootCampFidelidade.Dominio.BonificationContext.Entities;
using FrwkBootCampFidelidade.Dominio.OrderContext.Entities;
using FrwkBootCampFidelidade.Infraestrutura.BonificationContext.Mapping;
using FrwkBootCampFidelidade.Infraestrutura.OrderItemContext.Mapping;
using Microsoft.EntityFrameworkCore;

namespace FrwkBootCampFidelidade.Infraestrutura.Context
{
    public class DBContext : DbContext, IDBContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public virtual DbSet<Bonification> Bonifications { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BonificationMap());
            builder.ApplyConfiguration(new OrderMap());
            builder.ApplyConfiguration(new OrderItemMap());
        }
    }
}
