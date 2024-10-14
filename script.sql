create table Cliente (
                         Id int primary  key identity(1,1) not null ,
                         Cpf nvarchar(15)  not null,
                         DataNascimento datetime not null,
                         UfNascimento nvarchar(2) not null ,
                         DataCadastro DATETIME not null
);

CREATE table Endereco (
                          Id  int primary key identity(1,1) not null,
                          ClienteId int not null ,
                          Logradouro nvarchar(500) not null,
                          Bairro nvarchar(500) not null,
                          Cidade nvarchar(500) not null,
                          Uf nvarchar(2) not null,
                          DataCadastro datetime not null
)
