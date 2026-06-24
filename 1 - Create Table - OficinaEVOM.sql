create table tblEstado (
    id              bigint primary key identity,
    uf				varchar(2)
)
 
create table tblTipoTelefone (
    id              bigint primary key identity,
    tipoTelefone    varchar(20)
)
 
create table tblCargoFuncao (
    id              bigint primary key identity,
    cargo           varchar(50)
)
 
create table tblEspecialidade (
    id              bigint primary key identity,
    especialidade   varchar(80)
)
 
create table tblStatusOS (
    id              bigint primary key identity,
    status          varchar(30)
)
 
create table tblTipoServico (
    id              bigint primary key identity,
    tipoServico     varchar(50)
)
 
create table tblCategoriaProduto (
    id              bigint primary key identity,
    categoria       varchar(50)
)
  
create table tblMarca (
    id              bigint primary key identity,
    marca           varchar(50)
)
 
create table tblCombustivel (
    id              bigint primary key identity,
    combustivel     varchar(20)
)

create table tblUsuario (
	id				bigint primary key identity,
	nome			varchar(100) NULL,
	login			varchar(100) unique,
	senhaHash		varchar(255) NULL,
	perfil			varchar(50) NULL,
	ativo			bit NULL
)

create table tblCidade (
    id              bigint primary key identity,
    cidade          varchar(100),
    idEstado        bigint foreign key references tblEstado(id)
)

create table tblModelo (
	id			bigint primary key identity,
	modelo		varchar(200),
	idMarca		bigint foreign key references tblMarca(id)
)
create table tblCliente (
    id              bigint primary key identity,
    nomeCompleto    varchar(100),
    cpf             varchar(14) unique,
    dataNascimento  date,
    email           varchar(100)
)
 
create table tblFuncionario (
    id              bigint primary key identity,
    nomeCompleto    varchar(100),
    cpf             varchar(14) unique,
    dataAdmissao    date,
    idCargo         bigint foreign key references tblCargoFuncao(id),
    idEspecialidade bigint foreign key references tblEspecialidade(id)
)
 
create table tblFornecedor (
    id              bigint primary key identity,
    nome            varchar(100),
    cnpj            varchar(18) unique,
	email			varchar(200),
    idCidade		bigint foreign key references tblCidade(id)
)
 
create table tblProduto (
    id              bigint primary key identity,
    nome            varchar(100),
    descricao       varchar(200),
    preco           money,
    precoCusto      money,
	quantidade		int,
    idCategoria     bigint foreign key references tblCategoriaProduto(id),
	idFornecedor	bigint foreign key references tblFornecedor(id)
) 
 
create table tblTelefone (
    id              bigint primary key identity,
    numero          varchar(15),
    idTipoTelefone  bigint foreign key references tblTipoTelefone(id),
    idCliente       bigint foreign key references tblCliente(id),
	idFornecedor	bigint foreign key references tblFornecedor(id)
) 
 
create table tblVeiculo (
    id              bigint primary key identity,
    placa           varchar(8) unique,
    ano             int,
    idModelo		bigint foreign key references tblModelo(id),
    idCombustivel   bigint foreign key references tblCombustivel(id),
    idCliente       bigint foreign key references tblCliente(id)
) 
 
create table tblOrdemServico (
    id              bigint primary key identity,
    totalGeral      decimal(10,2),
    observacoes     varchar(200),
    dataAbertura    date,
    dataConclusao   date,
    idCliente       bigint foreign key references tblCliente(id),
    idVeiculo       bigint foreign key references tblVeiculo(id),
    idFuncionario   bigint foreign key references tblFuncionario(id),
    idStatus        bigint foreign key references tblStatusOS(id),
	idTipoServico	bigint foreign key references tblTipoServico(id)
) 

create table tblOsProduto (
    id              bigint primary key identity,
    quantidade      int,
    valorUnitario   money,
    idOs            bigint foreign key references tblOrdemServico(id),
    idProduto       bigint foreign key references tblProduto(id)
) 