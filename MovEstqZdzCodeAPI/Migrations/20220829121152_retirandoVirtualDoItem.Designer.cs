﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovEstqZdzCodeAPI.Models.Context;

#nullable disable

namespace MovEstqZdzCodeAPI.Migrations
{
    [DbContext(typeof(MySqlContext))]
    [Migration("20220829121152_retirandoVirtualDoItem")]
    partial class retirandoVirtualDoItem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MovEstqZdzCodeAPI.Models.EmpPes", b =>
                {
                    b.Property<int>("EmpPesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClienteFornecedor")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("CnpjCpf")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("FisicoJuridico")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)");

                    b.Property<string>("NomeEmpPes")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("EmpPesID");

                    b.ToTable("EmpPes");
                });

            modelBuilder.Entity("MovEstqZdzCodeAPI.Models.ItemMovEstoque", b =>
                {
                    b.Property<int>("ItemMovEstoqueID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MovEstoqueID")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoID")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("Quantidade");

                    b.Property<int>("Sequencia")
                        .HasColumnType("int")
                        .HasColumnName("Sequencia");

                    b.Property<decimal>("ValorUnitario")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("ValorUnitario");

                    b.HasKey("ItemMovEstoqueID");

                    b.ToTable("ItemMovEstoque");
                });

            modelBuilder.Entity("MovEstqZdzCodeAPI.Models.MovEstoque", b =>
                {
                    b.Property<int>("MovEstqID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EmpPesID")
                        .HasColumnType("int");

                    b.Property<string>("EntradaSaida")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("varchar(7)")
                        .HasColumnName("EntradaSaida");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("ValorTotal");

                    b.HasKey("MovEstqID");

                    b.HasIndex("EmpPesID");

                    b.ToTable("MovEstoque");
                });

            modelBuilder.Entity("MovEstqZdzCodeAPI.Models.Produto", b =>
                {
                    b.Property<int>("ProdutoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DescricaoProduto")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("DescricaoProduto");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("Quantidade");

                    b.Property<decimal>("ValorProduto")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("ValorProduto");

                    b.HasKey("ProdutoID");

                    b.ToTable("produto");
                });

            modelBuilder.Entity("MovEstqZdzCodeAPI.Models.MovEstoque", b =>
                {
                    b.HasOne("MovEstqZdzCodeAPI.Models.EmpPes", "EmpPes")
                        .WithMany()
                        .HasForeignKey("EmpPesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmpPes");
                });
#pragma warning restore 612, 618
        }
    }
}
