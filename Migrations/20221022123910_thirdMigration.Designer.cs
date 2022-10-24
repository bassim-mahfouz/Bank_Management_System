﻿// <auto-generated />
using Bank_Management_System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bank_Management_System.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221022123910_thirdMigration")]
    partial class thirdMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bank_Management_System.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<string>("CreationDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("AccountId");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Bank_Management_System.Models.Admin", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Name");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Bank_Management_System.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Bank_Management_System.Models.Deposite", b =>
                {
                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("amount")
                        .HasColumnType("real");

                    b.HasKey("AccountId", "Date");

                    b.ToTable("Deposites");
                });

            modelBuilder.Entity("Bank_Management_System.Models.Employee", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Name");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Bank_Management_System.Models.Loan", b =>
                {
                    b.Property<int>("LoanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("LastPaidInstallment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoanDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoanDeadline")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("amount")
                        .HasColumnType("real");

                    b.HasKey("LoanId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("Bank_Management_System.Models.PaidInstallment", b =>
                {
                    b.Property<int>("LoanId")
                        .HasColumnType("int");

                    b.Property<string>("PaymentDate")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("amount")
                        .HasColumnType("real");

                    b.HasKey("LoanId", "PaymentDate");

                    b.ToTable("PaidInstallment");
                });

            modelBuilder.Entity("Bank_Management_System.Models.Withdraw", b =>
                {
                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("amount")
                        .HasColumnType("real");

                    b.HasKey("AccountId", "Date");

                    b.ToTable("Withdraws");
                });

            modelBuilder.Entity("Bank_Management_System.Models.Account", b =>
                {
                    b.HasOne("Bank_Management_System.Models.Customer", "Customer")
                        .WithOne("PersonalAccount")
                        .HasForeignKey("Bank_Management_System.Models.Account", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Bank_Management_System.Models.Deposite", b =>
                {
                    b.HasOne("Bank_Management_System.Models.Account", "Account")
                        .WithMany("Deposites")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Bank_Management_System.Models.Loan", b =>
                {
                    b.HasOne("Bank_Management_System.Models.Customer", "Customer")
                        .WithMany("Loans")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Bank_Management_System.Models.PaidInstallment", b =>
                {
                    b.HasOne("Bank_Management_System.Models.Loan", "Loan")
                        .WithMany("PaidInstallments")
                        .HasForeignKey("LoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Loan");
                });

            modelBuilder.Entity("Bank_Management_System.Models.Withdraw", b =>
                {
                    b.HasOne("Bank_Management_System.Models.Account", "Account")
                        .WithMany("Withdraws")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Bank_Management_System.Models.Account", b =>
                {
                    b.Navigation("Deposites");

                    b.Navigation("Withdraws");
                });

            modelBuilder.Entity("Bank_Management_System.Models.Customer", b =>
                {
                    b.Navigation("Loans");

                    b.Navigation("PersonalAccount");
                });

            modelBuilder.Entity("Bank_Management_System.Models.Loan", b =>
                {
                    b.Navigation("PaidInstallments");
                });
#pragma warning restore 612, 618
        }
    }
}
