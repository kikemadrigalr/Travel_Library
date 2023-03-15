using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Travel_Library.Models;

namespace Travel_Library.Data;

public partial class TravelLibraryContext : DbContext
{
    public TravelLibraryContext()
    {
    }

    public TravelLibraryContext(DbContextOptions<TravelLibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autor> Autors { get; set; }

    public virtual DbSet<AutorHasLibro> AutorHasLibros { get; set; }

    public virtual DbSet<Editorial> Editorials { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database=Travel_Library; User Id=desarrollo; Password=123456; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Autor__3214EC0774F8C109");

            entity.ToTable("Autor");

            entity.Property(e => e.Apellidos)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AutorHasLibro>(entity =>
        {
            entity.HasKey(e => new { e.AutorId, e.LibroIsbn }).HasName("PK__Autor_ha__AC34B544F66D825D");

            entity.ToTable("Autor_has_libro");

            entity.Property(e => e.AutorId).HasColumnName("Autor_Id");
            entity.Property(e => e.LibroIsbn).HasColumnName("Libro_ISBN");
        });

        modelBuilder.Entity<Editorial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Editoria__3214EC07BBCC8ABC");

            entity.ToTable("Editorial");

            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.Sede)
                .HasMaxLength(45)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.Isbn).HasName("PK__Libro__447D36EB5A901967");

            entity.ToTable("Libro");

            entity.Property(e => e.Isbn).HasColumnName("ISBN");
            entity.Property(e => e.EditorialId).HasColumnName("Editorial_Id");
            entity.Property(e => e.NPaginas)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("n_paginas");
            entity.Property(e => e.Sinopsis).HasColumnType("text");
            entity.Property(e => e.Titulo)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.HasOne(d => d.Editorial).WithMany(p => p.Libros)
                .HasForeignKey(d => d.EditorialId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Libro__Editorial__44FF419A");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC0714CD113E");

            entity.ToTable("Usuario");

            entity.Property(e => e.Contrasena)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
