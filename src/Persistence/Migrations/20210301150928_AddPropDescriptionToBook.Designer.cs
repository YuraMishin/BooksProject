// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Persistence.Migrations
{
  [DbContext(typeof(DataContext))]
  [Migration("20210301150928_AddPropDescriptionToBook")]
  partial class AddPropDescriptionToBook
  {
    /// <summary>
    /// Method builds target model
    /// </summary>
    /// <param name="modelBuilder">modelBuilder</param>
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
      modelBuilder
          .HasAnnotation("Relational:MaxIdentifierLength", 63)
          .HasAnnotation("ProductVersion", "5.0.3")
          .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

      modelBuilder.Entity("BookCategory", b =>
          {
            b.Property<Guid>("BooksId")
                      .HasColumnType("uuid");

            b.Property<Guid>("CategoriesId")
                      .HasColumnType("uuid");

            b.HasKey("BooksId", "CategoriesId");

            b.HasIndex("CategoriesId");

            b.ToTable("BookCategory");
          });

      modelBuilder.Entity("Domain.Book", b =>
          {
            b.Property<Guid>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("uuid");

            b.Property<string>("Description")
                      .HasColumnType("text");

            b.Property<Guid>("DifficultyId")
                      .HasColumnType("uuid");

            b.Property<string>("Title")
                      .HasColumnType("text");

            b.HasKey("Id");

            b.HasIndex("DifficultyId");

            b.ToTable("Books");
          });

      modelBuilder.Entity("Domain.BookRelationship", b =>
          {
            b.Property<Guid>("PrerequisiteId")
                      .HasColumnType("uuid");

            b.Property<Guid>("ProgressionId")
                      .HasColumnType("uuid");

            b.HasKey("PrerequisiteId", "ProgressionId");

            b.HasIndex("ProgressionId");

            b.ToTable("BookRelationships");
          });

      modelBuilder.Entity("Domain.Category", b =>
          {
            b.Property<Guid>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("uuid");

            b.Property<string>("Description")
                      .HasColumnType("text");

            b.Property<string>("Name")
                      .HasColumnType("text");

            b.HasKey("Id");

            b.ToTable("Categories");
          });

      modelBuilder.Entity("Domain.Difficulty", b =>
          {
            b.Property<Guid>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("uuid");

            b.Property<string>("Description")
                      .HasColumnType("text");

            b.Property<string>("Name")
                      .HasColumnType("text");

            b.HasKey("Id");

            b.ToTable("Difficulties");
          });

      modelBuilder.Entity("Domain.Submission", b =>
          {
            b.Property<Guid>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("uuid");

            b.Property<Guid>("BookId")
                      .HasColumnType("uuid");

            b.Property<string>("Description")
                      .HasColumnType("text");

            b.Property<string>("Video")
                      .HasColumnType("text");

            b.HasKey("Id");

            b.ToTable("Submissions");
          });

      modelBuilder.Entity("BookCategory", b =>
          {
            b.HasOne("Domain.Book", null)
                      .WithMany()
                      .HasForeignKey("BooksId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            b.HasOne("Domain.Category", null)
                      .WithMany()
                      .HasForeignKey("CategoriesId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();
          });

      modelBuilder.Entity("Domain.Book", b =>
          {
            b.HasOne("Domain.Difficulty", "Difficulty")
                      .WithMany("Books")
                      .HasForeignKey("DifficultyId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            b.Navigation("Difficulty");
          });

      modelBuilder.Entity("Domain.BookRelationship", b =>
          {
            b.HasOne("Domain.Book", "Prerequisite")
                      .WithMany("Progressions")
                      .HasForeignKey("PrerequisiteId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            b.HasOne("Domain.Book", "Progression")
                      .WithMany("Prerequisites")
                      .HasForeignKey("ProgressionId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            b.Navigation("Prerequisite");

            b.Navigation("Progression");
          });

      modelBuilder.Entity("Domain.Book", b =>
          {
            b.Navigation("Prerequisites");

            b.Navigation("Progressions");
          });

      modelBuilder.Entity("Domain.Difficulty", b =>
          {
            b.Navigation("Books");
          });
#pragma warning restore 612, 618
    }
  }
}
