// <auto-generated />
using DesApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DesApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220408014408_Removed Auto Identity")]
    partial class RemovedAutoIdentity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("DesApi.Domain.DiffEntry", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Left")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Right")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DiffEntry");
                });
#pragma warning restore 612, 618
        }
    }
}
