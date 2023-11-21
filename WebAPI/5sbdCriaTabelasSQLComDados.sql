USE [5sbd]
GO

BEGIN TRANSACTION

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE Pessoa(
  Id INT IDENTITY NOT NULL,
  Matricula varchar(25) NOT NULL,
  Nome varchar(150) NOT NULL,
  DataNascimento date NOT NULL,
  Sexo varchar(1) NOT NULL,
  Email varchar(200) NOT NULL,
  Endereco varchar(255) NULL,
  Tipo int NOT NULL,
  Senha varchar(255) NOT NULL,
  Ativo bit NOT NULL
) ON [PRIMARY];

CREATE TABLE Inscricao (
  Id INT IDENTITY NOT NULL,
  IdAluno [int] NOT NULL,
  IdTurma [int] NOT NULL,
  DataInicio date NOT NULL,
  DataFim date DEFAULT NULL,  
  NotaAV1 decimal(4,2) NULL,
  NotaAV2 decimal(4,2) NULL,
  NotaAVS decimal(4,2) NULL,
  NotaAVF decimal(4,2) NULL,
  Faltas INT
) ON [PRIMARY];

CREATE TABLE Disciplina (
  Id INT IDENTITY NOT NULL,
  Nome varchar(150) NOT NULL,
  Sigla varchar(15) NOT NULL,
  Periodo INT NOT NULL,
  Creditos [int] NOT NULL,
  DataInicio date NOT NULL,
  DataFim date DEFAULT NULL
) ON [PRIMARY];

CREATE TABLE Turma (
  Id INT IDENTITY NOT NULL,
  Sigla varchar(15) DEFAULT NULL,
  IdDisciplina [int] DEFAULT NULL,
  IdProfessor [int] NOT NULL,
  Horario varchar(50) NOT NULL,
  DataInicio date NOT NULL,
  DataFim date DEFAULT NULL,
  Turno [int] NOT NULL
) ON [PRIMARY];

GO

-- D A D O S --

--
-- Despejando dados para a tabela Pessoa
--
SET IDENTITY_INSERT Pessoa ON;  
GO  

INSERT INTO Pessoa (Id, Matricula, Nome, DataNascimento, Sexo, Email, Endereco, Tipo, Senha, Ativo) VALUES
(1, '6739-1', 'Andrea Silva', '1999-10-02', 'F', 'andreasilva@gmail.com', 'Rua das Rosas, 30 - Tijuca', 2, 'senha123',1),
(2, '5276-0', 'Carlos Vargas', '2002-05-03', 'M', 'carlosvargas@yahoo.com.br', 'Rua Conde de Baependi, 23 ap 1200 - Largo do Machado', 2, 'senha123',1),
(3, '7481-2', 'Ana Maria de Souza', '2000-10-25', 'F', 'anasilva@aol.com', 'Av das Pitangueiras, 54 -  Méier', 2, 'senha123',1),
(4, '4830-4', 'Renata Corte Real', '2003-04-11', 'F', 'renatacorte@hotmail.com', 'Travessa Laguna, 157 - Lagoa', 1, 'senha123',1),
(5, '2110478300032', 'Marcos da Silva Veras', '1998-08-28', 'M', 'verasm@gmail.com', 'Avenida Vieira Souto, 20 - Ipanema', 3,'senha123',1),
(6, '1810478300010', 'Janete de Almeida Cruz', '1984-02-01','F','jacruz@hotmail.com', 'Rua Visconde de Pirajá, 670 - Ipanema', 3,'senha123',1),
(7, '1920478300025', 'Walter Santos Conde', '1990-07-22','M', 'walcon@yahoo.com.br', 'Rua Ataulfo de Paiva, 23 - Leblon', 3,'senha123',1),
(8, '2210478300081', 'Paula Bastos Cardoso', '1998-12-22','F', 'paulacardoso@aol.com.br', 'Av Niemeyer, 45 - Leblon', 3,'senha123',1);

SET IDENTITY_INSERT Pessoa OFF;  
GO 
-- --------------------------------------------------------
--
-- Despejando dados para a tabela Inscricao
--
SET IDENTITY_INSERT Inscricao ON;  
GO 

INSERT INTO Inscricao (Id, IdAluno, DataInicio, DataFim, IdTurma, NotaAV1, NotaAV2, NotaAVS, NotaAVF, Faltas) VALUES
(1, 5,'2023-08-19', NULL, 3.5, 5.9, 7, NULL, NULL, 10),
(2, 5, '2023-08-21', NULL, 3.3, NULL, 7, NULL, 7, 2),
(3, 6, '2023-08-30', NULL,2.7, 3, 2.1, 5, NULL, 15),
(4, 7,'2023-08-25', NULL, 1, 9.5, 7, NULL, NULL, 0),
(5, 7,'2023-08-27', NULL, 2, 4.3, 2.5, NULL, 8.7, 4),
(6, 8, '2023-08-21', NULL,1, 9.7, 10, NULL, NULL, 0);

SET IDENTITY_INSERT Inscricao OFF;  
GO 

-- --------------------------------------------------------
--
-- Despejando dados para a tabela Disciplina
--
SET IDENTITY_INSERT Disciplina ON;  
GO 

INSERT INTO Disciplina (Id, Nome, Sigla, Periodo, Creditos, DataInicio, DataFim) VALUES
(1, 'Projeto de Banco de Dados', '5PBD', 5, 40, '2023-08-14', NULL),
(2, 'Desenvolvimento de Aplicações Web', '3DAW',3, 60, '2023-08-14', NULL),
(3, 'Projeto e Desenvolvimento Mobile', '5PDM', 5, 30, '2023-08-21', NULL),
(4, 'Tópicos Avançados', '5TAV', 5, 50, '2023-07-01', NULL);

SET IDENTITY_INSERT Disciplina OFF;  
GO 
-- --------------------------------------------------------
--
-- Despejando dados para a tabela Turma
--
SET IDENTITY_INSERT Turma ON;  
GO 

INSERT INTO Turma (Id, Sigla, IdDisciplina, Horario, IdProfessor, DataInicio, DataFim, Turno) VALUES
(1, 'N10', 2, '18h00-20h40', 1, '2023-08-01', NULL, 3),
(2, 'N20', 1, '20h40-22h10', 2, '2023-08-01', NULL, 3),
(3, 'N11', 4, '20h50-22h10 3ª e 5ª', 3, '2023-08-03', NULL, 3),
(4, 'N11', 4, '20h50-22h10 3ª e 5ª', 3, '2023-08-03', NULL, 3);

SET IDENTITY_INSERT Turma OFF;  
GO 


ALTER TABLE Pessoa
  ADD PRIMARY KEY (Id);

 ALTER TABLE Inscricao
  ADD PRIMARY KEY (Id);

ALTER TABLE Disciplina
  ADD PRIMARY KEY (Id);

ALTER TABLE Turma
  ADD PRIMARY KEY (Id);

ALTER TABLE Inscricao
  ADD CONSTRAINT idAluno_FK FOREIGN KEY (IdAluno) REFERENCES Pessoa(Id); 
ALTER TABLE Inscricao
  ADD CONSTRAINT idTurma_FK FOREIGN KEY (IdTurma) REFERENCES Turma(Id);

ALTER TABLE Turma
  ADD CONSTRAINT idDisciplinaTurma_FK FOREIGN KEY (IdDisciplina) REFERENCES Disciplina(Id);
ALTER TABLE Turma
  ADD CONSTRAINT idProfessor_FK FOREIGN KEY (IdProfessor) REFERENCES Pessoa(Id);

COMMIT
GO

SET ANSI_PADDING OFF
GO