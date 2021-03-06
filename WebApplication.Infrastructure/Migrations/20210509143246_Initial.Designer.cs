// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApplication.Infrastructure;

namespace WebApplication.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210509143246_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("WebApplication.Infrastructure.Models.PageView", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.HasKey("Name");

                    b.ToTable("PageViews");
                });
#pragma warning restore 612, 618
        }
    }
}
