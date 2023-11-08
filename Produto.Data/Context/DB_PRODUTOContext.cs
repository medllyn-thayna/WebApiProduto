using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Produto.Domain.Entities;

namespace Produto.Data.Context;

public partial class DB_PRODUTOContext : DbContext
{
    public DB_PRODUTOContext()
    {
    }

    public DB_PRODUTOContext(DbContextOptions<DB_PRODUTOContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TB_PRODUTOS> TB_PRODUTOS { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=DB_PRODUTO;persist security info=True;Integrated Security=SSPI;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TB_PRODUTOS>(entity =>
        {
            entity.HasKey(e => e.ID_PRODUTO).HasName("PK_TB_PRODUTO");

            entity.Property(e => e.NOME_PRODUTO)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.STATUS_PRODUTO)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
