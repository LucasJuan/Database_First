using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Database_First.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Estagiario> Estagiarios { get; set; } = null!;
        public virtual DbSet<Fornecedore> Fornecedores { get; set; } = null!;
        public virtual DbSet<Funcionario> Funcionarios { get; set; } = null!;
        public virtual DbSet<ItensPedido> ItensPedidos { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Pessoa> Pessoas { get; set; } = null!;
        public virtual DbSet<Produto> Produtos { get; set; } = null!;
        public virtual DbSet<Requisico> Requisicoes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=VendasManha;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("categorias");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("clientes");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Credito)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("credito");

                entity.Property(e => e.Renda)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("renda");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Cliente)
                    .HasForeignKey<Cliente>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__clientes__id__2C3393D0");
            });

            modelBuilder.Entity<Estagiario>(entity =>
            {
                entity.ToTable("estagiarios");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Bolsa)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("bolsa");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Estagiario)
                    .HasForeignKey<Estagiario>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__estagiarios__id__32E0915F");
            });

            modelBuilder.Entity<Fornecedore>(entity =>
            {
                entity.ToTable("fornecedores");

                entity.HasIndex(e => e.Cnpj, "UQ__forneced__35BD3E48C991F86C")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Cnpj)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("cnpj");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Fornecedore)
                    .HasForeignKey<Fornecedore>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__fornecedores__id__36B12243");
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.ToTable("funcionarios");

                entity.HasIndex(e => e.Cpf, "UQ__funciona__D836E71F91887EB4")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("cpf");

                entity.Property(e => e.Salario)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("salario");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Funcionario)
                    .HasForeignKey<Funcionario>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__funcionarios__id__300424B4");
            });

            modelBuilder.Entity<ItensPedido>(entity =>
            {
                entity.HasKey(e => new { e.PedidoId, e.ProdutoId })
                    .HasName("PK__itens_pe__5DA3E6AB07900DA7");

                entity.ToTable("itens_pedidos");

                entity.Property(e => e.PedidoId).HasColumnName("pedido_id");

                entity.Property(e => e.ProdutoId).HasColumnName("produto_id");

                entity.Property(e => e.PrecoVendido)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("preco_vendido");

                entity.Property(e => e.QtdVendida).HasColumnName("qtd_vendida");

                entity.HasOne(d => d.Pedido)
                    .WithMany(p => p.ItensPedidos)
                    .HasForeignKey(d => d.PedidoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__itens_ped__pedid__3F466844");

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.ItensPedidos)
                    .HasForeignKey(d => d.ProdutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__itens_ped__produ__403A8C7D");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.ToTable("pedidos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClienteId).HasColumnName("cliente_id");

                entity.Property(e => e.Data)
                    .HasColumnType("datetime")
                    .HasColumnName("data");

                entity.Property(e => e.EstagiarioId).HasColumnName("estagiario_id");

                entity.Property(e => e.FunRecId).HasColumnName("fun_rec_id");

                entity.Property(e => e.FunRegId).HasColumnName("fun_reg_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("total");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__pedidos__cliente__398D8EEE");

                entity.HasOne(d => d.Estagiario)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.EstagiarioId)
                    .HasConstraintName("FK__pedidos__estagia__3C69FB99");

                entity.HasOne(d => d.FunRec)
                    .WithMany(p => p.PedidoFunRecs)
                    .HasForeignKey(d => d.FunRecId)
                    .HasConstraintName("FK__pedidos__fun_rec__3B75D760");

                entity.HasOne(d => d.FunReg)
                    .WithMany(p => p.PedidoFunRegs)
                    .HasForeignKey(d => d.FunRegId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__pedidos__fun_reg__3A81B327");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.ToTable("pessoas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("produtos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.Estoque).HasColumnName("estoque");

                entity.Property(e => e.Preco)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("preco");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__produtos__catego__29572725");
            });

            modelBuilder.Entity<Requisico>(entity =>
            {
                entity.ToTable("requisicoes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Data)
                    .HasColumnType("datetime")
                    .HasColumnName("data");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
