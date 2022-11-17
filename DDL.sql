create database VendasManha
go
use VendasManha
go
----------------------------------------
create table pessoas
(
   id     int		     not null primary key identity,
   nome   varchar(50)    not null,
   email  varchar(max)       null,
   status int                null,
   check (status in (1,2,3,4))
) 
go
-----------------------------------------------------
create table categorias
(
   id		 int		 not null primary key identity,
   descricao varchar(50) not null,
   status    int
)
go
--------------------------------------------
create table produtos
(
   id		    int		      not null primary key identity,
   descricao    varchar(50)   not null,
   preco        decimal(10,2)     null,
   estoque      int               null,
   categoria_id int           not null,
   foreign key(categoria_id) references categorias(id)
)
go
--------------------------------------------------
create table clientes
(
   id      int			  not null primary key, -- não tem identity
   renda   decimal(10,2)  not null,
   credito decimal(10,2),
   foreign key(id) references pessoas(id)
)
go
-------------------------------------------------
create table funcionarios
(
   id      int			  not null primary key, -- não tem identity
   salario decimal(10,2)  not null,
   cpf     varchar(12)    not null unique,
   foreign key(id) references pessoas(id)
)
go

--------------------------------------------
create table estagiarios
(
   id      int			  not null primary key, -- não tem identity
   bolsa   decimal(10,2)  not null,   
   status  int,
   foreign key(id) references pessoas(id)
)
go
-----------------------------------------------

create table fornecedores
(
   id      int			  not null primary key, -- não tem identity   
   cnpj     varchar(14)    not null unique,
   foreign key(id) references pessoas(id)
)
go
----------------------------------------------

create table pedidos
(
   id             int       not null primary key identity,
   data           datetime  not null,
   total		  decimal(10,2),
   status         int,
   cliente_id     int       not null,
   fun_reg_id     int       not null,
   fun_rec_id     int,
   estagiario_id  int,
   foreign key(cliente_id   ) references clientes    (id),
   foreign key(fun_reg_id   ) references funcionarios(id),
   foreign key(fun_rec_id   ) references funcionarios(id),
   foreign key(estagiario_id) references estagiarios (id)
)
go
------------------------------------
create table itens_pedidos
(
   pedido_id     int		   not null,
   produto_id    int		   not null,
   qtd_vendida   int		   not null,
   preco_vendido decimal(10,2) not null,
   primary key(pedido_id, produto_id),
   foreign key(pedido_id) references pedidos(id),
   foreign key(produto_id) references produtos(id)
)
go
----------------------------------------------------
create table requisicoes
(
id int not null primary key identity,
data datetime not null
status
)
-----------------------------------------------------

-- inserts --

-- Categorias --
insert into categorias values ('Lápis',1)
insert into categorias values ('Caneta',1)
insert into categorias values ('Caderno',1)
select * from categorias

-- Produtos --


insert into produtos values 
('Lápis de Cor - Faber Castell',1.5,100,1)

insert into produtos values 
('Caneta Bic Azul',1.0,100,2)

insert into produtos values 
('Caderno Capa Dura Ben Dez',7.5,100,3)
select * from produtos

-- Clientes -- 
insert into pessoas 
values ('Jefferson', 'jeff@jeff.com.br',1)

insert into clientes 
values (1,5000,1000)

select * from pessoas
select * from clientes

-- Funcionarios --

select * from pessoas
select * from funcionarios

insert into pessoas
values ('Talita','tata@ta.com.br',1)

insert into funcionarios 
values (2, 10000,'1010') 


