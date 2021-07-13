﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NbaWebApp.Repository;

#nullable disable

namespace NbaWebApp.Repository.DataBase
{
    public partial class nba_DB : DbContext
    {
        public nba_DB()
        {
        }

        public nba_DB(DbContextOptions<nba_DB> options)
            : base(options)
        {
        }

        public virtual DbSet<Players> Players { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS_KS_WS");

            modelBuilder.Entity<Players>(entity =>
            {
                entity.ToTable("players");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Team).HasMaxLength(255);
            });

            modelBuilder.Entity<Teams>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}