// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Persistence.Migrations
{
  [DbContext(typeof(DataContext))]
  [Migration("20210221121218_AddVideoPropToBook")]
  partial class AddVideoPropToBook
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

      modelBuilder.Entity("Domain.Book", b =>
          {
            b.Property<Guid>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("uuid");

            b.Property<string>("Title")
                      .HasColumnType("text");

            b.Property<string>("Video")
                      .HasColumnType("text");

            b.HasKey("Id");

            b.ToTable("Books");
          });
#pragma warning restore 612, 618
    }
  }
}
