﻿// <auto-generated />
using B1_Task.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace B1_Task.Migrations
{
    [DbContext(typeof(B1Context))]
    partial class B1ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("B1_Task.Entity.BankEntities.TblOpeningBalance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("ActiveBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PassiveBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TblSheetClassId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TblSheetClassId");

                    b.ToTable("TblOpeningBalances");
                });

            modelBuilder.Entity("B1_Task.Entity.BankEntityes.TblAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TblSheetClassId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TblSheetClassId");

                    b.ToTable("TblAccounts");
                });

            modelBuilder.Entity("B1_Task.Entity.BankEntityes.TblBank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TblBanks");
                });

            modelBuilder.Entity("B1_Task.Entity.BankEntityes.TblClosedBalance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("ActiveBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PassiveBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TblSheetClassId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TblSheetClassId");

                    b.ToTable("TblClosedBalances");
                });

            modelBuilder.Entity("B1_Task.Entity.BankEntityes.TblSheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EndDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TblBankId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalSumCloseActiveBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalSumClosePassiveBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalSumOpenActiveBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalSumOpenPassiveBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalSumTurnoversCredit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalSumTurnoversDebit")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("TblBankId");

                    b.ToTable("TblSheets");
                });

            modelBuilder.Entity("B1_Task.Entity.BankEntityes.TblSheetClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SumCloseActiveBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SumClosePassiveBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SumOpenActiveBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SumOpenPassiveBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SumTurnoversCredit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SumTurnoversDebit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TblSheetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TblSheetId");

                    b.ToTable("TblSheetClasses");
                });

            modelBuilder.Entity("B1_Task.Entity.BankEntityes.TblTurnover", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Credit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Debit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TblSheetClassId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TblSheetClassId");

                    b.ToTable("TblTurnovers");
                });

            modelBuilder.Entity("B1_Task.Entity.TblContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FolatNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PositiveNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StringEU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StringRU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TblDocumentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TblDocumentId");

                    b.ToTable("TblContents");
                });

            modelBuilder.Entity("B1_Task.Entity.TblDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TblDocuments");
                });

            modelBuilder.Entity("B1_Task.Entity.TblProcedureResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("MedianValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("TotalSumPositive")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("TblProcedureResults");
                });

            modelBuilder.Entity("B1_Task.Entity.BankEntities.TblOpeningBalance", b =>
                {
                    b.HasOne("B1_Task.Entity.BankEntityes.TblSheetClass", "TblSheetClass")
                        .WithMany("OpeningBalances")
                        .HasForeignKey("TblSheetClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TblSheetClass");
                });

            modelBuilder.Entity("B1_Task.Entity.BankEntityes.TblAccount", b =>
                {
                    b.HasOne("B1_Task.Entity.BankEntityes.TblSheetClass", "TblSheetClass")
                        .WithMany("Account")
                        .HasForeignKey("TblSheetClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TblSheetClass");
                });

            modelBuilder.Entity("B1_Task.Entity.BankEntityes.TblClosedBalance", b =>
                {
                    b.HasOne("B1_Task.Entity.BankEntityes.TblSheetClass", "TblSheetClass")
                        .WithMany("ClosedBalances")
                        .HasForeignKey("TblSheetClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TblSheetClass");
                });

            modelBuilder.Entity("B1_Task.Entity.BankEntityes.TblSheet", b =>
                {
                    b.HasOne("B1_Task.Entity.BankEntityes.TblBank", "Bank")
                        .WithMany("Sheets")
                        .HasForeignKey("TblBankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");
                });

            modelBuilder.Entity("B1_Task.Entity.BankEntityes.TblSheetClass", b =>
                {
                    b.HasOne("B1_Task.Entity.BankEntityes.TblSheet", "TblSheet")
                        .WithMany("SheetClasses")
                        .HasForeignKey("TblSheetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TblSheet");
                });

            modelBuilder.Entity("B1_Task.Entity.BankEntityes.TblTurnover", b =>
                {
                    b.HasOne("B1_Task.Entity.BankEntityes.TblSheetClass", "TblSheetClass")
                        .WithMany("Turnovers")
                        .HasForeignKey("TblSheetClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TblSheetClass");
                });

            modelBuilder.Entity("B1_Task.Entity.TblContent", b =>
                {
                    b.HasOne("B1_Task.Entity.TblDocument", "Document")
                        .WithMany("Contents")
                        .HasForeignKey("TblDocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");
                });

            modelBuilder.Entity("B1_Task.Entity.BankEntityes.TblBank", b =>
                {
                    b.Navigation("Sheets");
                });

            modelBuilder.Entity("B1_Task.Entity.BankEntityes.TblSheet", b =>
                {
                    b.Navigation("SheetClasses");
                });

            modelBuilder.Entity("B1_Task.Entity.BankEntityes.TblSheetClass", b =>
                {
                    b.Navigation("Account");

                    b.Navigation("ClosedBalances");

                    b.Navigation("OpeningBalances");

                    b.Navigation("Turnovers");
                });

            modelBuilder.Entity("B1_Task.Entity.TblDocument", b =>
                {
                    b.Navigation("Contents");
                });
#pragma warning restore 612, 618
        }
    }
}
