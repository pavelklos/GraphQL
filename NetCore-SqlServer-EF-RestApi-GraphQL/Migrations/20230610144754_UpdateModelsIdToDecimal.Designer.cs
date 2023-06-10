﻿// <auto-generated />
using System;
using GPL.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GPL.Migrations
{
    [DbContext(typeof(ProductDataContext))]
    [Migration("20230610144754_UpdateModelsIdToDecimal")]
    partial class UpdateModelsIdToDecimal
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GPL.DBModels.TblCategory", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(18, 0)")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"));

                    b.Property<string>("CategoryName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Tbl_Category", (string)null);
                });

            modelBuilder.Entity("GPL.DBModels.TblProduct", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(18, 0)")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"));

                    b.Property<decimal?>("Categoryid")
                        .HasColumnType("numeric(18, 0)");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductCode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ProductName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double?>("StkQty")
                        .HasColumnType("float");

                    b.Property<decimal?>("VendorId")
                        .HasColumnType("numeric(18, 0)")
                        .HasColumnName("VendorID");

                    b.HasKey("Id");

                    b.HasIndex("Categoryid");

                    b.HasIndex("VendorId");

                    b.ToTable("Tbl_Product", (string)null);
                });

            modelBuilder.Entity("GPL.DBModels.TblVendor", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(18, 0)")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"));

                    b.Property<string>("VendorCode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("VendorEmail")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("VendorName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("VendorPhone")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Tbl_Vendor", (string)null);
                });

            modelBuilder.Entity("GPL.DBModels.TblProduct", b =>
                {
                    b.HasOne("GPL.DBModels.TblCategory", "Category")
                        .WithMany("TblProducts")
                        .HasForeignKey("Categoryid")
                        .HasConstraintName("FK_Tbl_Product_Tbl_Category");

                    b.HasOne("GPL.DBModels.TblVendor", "Vendor")
                        .WithMany("TblProducts")
                        .HasForeignKey("VendorId")
                        .HasConstraintName("FK_Tbl_Product_Tbl_Vendor");

                    b.Navigation("Category");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("GPL.DBModels.TblCategory", b =>
                {
                    b.Navigation("TblProducts");
                });

            modelBuilder.Entity("GPL.DBModels.TblVendor", b =>
                {
                    b.Navigation("TblProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
