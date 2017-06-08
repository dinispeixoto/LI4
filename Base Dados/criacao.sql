
-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------


DROP DATABASE [WhatsYummyDB];
GO

CREATE DATABASE [WhatsYummyDB];
GO

USE [WhatsYummyDB];
GO



-- -----------------------------------------------------
-- Table `mydb`.`Utilizador`
-- -----------------------------------------------------
CREATE TABLE [Utilizador] (
  [ID] INT IDENTITY(1,1) NOT NULL ,
  [Username] VARCHAR(64) NOT NULL,
  [Password] VARCHAR(64) NOT NULL,
  [Nome] VARCHAR(64) NOT NULL,
  [DataNascimento] DATE NULL,
  [Foto] VARCHAR(256) NULL,
  [Email] VARCHAR(64) NOT NULL,
  [Admin] INT NOT NULL,
  PRIMARY KEY ([ID]))
;
GO

-- -----------------------------------------------------
-- Table `mydb`.`Estabelecimento`
-- -----------------------------------------------------
CREATE TABLE [Estabelecimento] (
  [ID] INT IDENTITY(1,1) NOT NULL,
  [Nome] VARCHAR(64) NOT NULL,
  [CodigoPostal] VARCHAR(64) NOT NULL,
  [Localidade] VARCHAR(64) NOT NULL,
  [Rua] VARCHAR(64) NOT NULL,
  [Utilizador] INT NULL,
  [Estado] INT NOT NULL,
  PRIMARY KEY ([ID])
 ,
  CONSTRAINT [fk_Estabelecimento_Utilizador1]
    FOREIGN KEY ([Utilizador])
    REFERENCES [Utilizador] ([ID])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;
GO

CREATE INDEX [fk_Estabelecimento_Utilizador1_idx] ON [Estabelecimento] ([Utilizador] ASC);
GO

-- -----------------------------------------------------
-- Table `mydb`.`Produto`
-- -----------------------------------------------------
CREATE TABLE [Produto] (
  [ID] INT IDENTITY(1,1) NOT NULL,
  [EstabelecimentoId] INT NOT NULL,
  [Nome] VARCHAR(64) NOT NULL,
  [Descricao] VARCHAR(max) NOT NULL,
  [Preco] DECIMAL(5,2) NOT NULL,
  [Visitias] INT NOT NULL,
  [Foto] VARCHAR(256) NULL,
  PRIMARY KEY ([ID], [EstabelecimentoId])
 ,
  CONSTRAINT [fk_Produto_Estabelecimento1]
    FOREIGN KEY ([EstabelecimentoId])
    REFERENCES [Estabelecimento] ([ID])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;
GO

CREATE INDEX [fk_Produto_Estabelecimento1_idx] ON [Produto] ([EstabelecimentoId] ASC);
GO

-- -----------------------------------------------------
-- Table `mydb`.`Tag`
-- -----------------------------------------------------
CREATE TABLE [Tag] (
  [ID] INT IDENTITY(1,1) NOT NULL,
  [Tipo] VARCHAR(64) NOT NULL,
  [Nome] VARCHAR(64) NOT NULL,
  PRIMARY KEY ([ID]))
;
GO

-- -----------------------------------------------------
-- Table `mydb`.`Avaliacao`
-- -----------------------------------------------------
CREATE TABLE [Avaliacao] (
  [ID] INT IDENTITY(1,1) NOT NULL,
  [Classificaçao] FLOAT NOT NULL,
  [Comentario] VARCHAR(150) NULL,
  [Utilizador] INT NOT NULL,
  [Produto] INT NOT NULL,
  [Estabelecimento] INT NOT NULL,
  [Foto] VARCHAR(256) NULL,
  PRIMARY KEY ([ID])
 ,
  CONSTRAINT [fk_Avaliacao_Utilizador1]
    FOREIGN KEY ([Utilizador])
    REFERENCES [Utilizador] ([ID])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_Avaliacao_Produto1]
    FOREIGN KEY ([Produto] , [Estabelecimento])
    REFERENCES [Produto] ([ID] , [EstabelecimentoId])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;
GO

CREATE INDEX [fk_Avaliacao_Utilizador1_idx] ON [Avaliacao] ([Utilizador] ASC);
GO

CREATE INDEX [fk_Avaliacao_Produto1_idx] ON [Avaliacao] ([Produto] ASC, [Estabelecimento] ASC);
GO

-- -----------------------------------------------------
-- Table `mydb`.`UtilizadorProduto`
-- -----------------------------------------------------
CREATE TABLE [UtilizadorProduto] (
  [Utilizador] INT NOT NULL,
  [Produto] INT NOT NULL,
  [Estabelecimento] INT NOT NULL,
  [Favorito] INT NOT NULL
 ,
  PRIMARY KEY ([Utilizador], [Produto], [Estabelecimento])
 ,
  CONSTRAINT [fk_UtilizadorProduto_Utilizador]
    FOREIGN KEY ([Utilizador])
    REFERENCES [Utilizador] ([ID])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_UtilizadorProduto_Produto1]
    FOREIGN KEY ([Produto] , [Estabelecimento])
    REFERENCES [Produto] ([ID] , [EstabelecimentoId])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;
GO

CREATE INDEX [fk_UtilizadorProduto_Utilizador_idx] ON [UtilizadorProduto] ([Utilizador] ASC);
GO

CREATE INDEX [fk_UtilizadorProduto_Produto1_idx] ON [UtilizadorProduto] ([Produto] ASC, [Estabelecimento] ASC);
GO

-- -----------------------------------------------------
-- Table `mydb`.`ProdutoTag`
-- -----------------------------------------------------
CREATE TABLE [ProdutoTag] (
  [Tag] INT NOT NULL,
  [Produto] INT NOT NULL,
  [Estabelecimento] INT NOT NULL,
  PRIMARY KEY ([Tag], [Produto], [Estabelecimento])
 ,
  CONSTRAINT [fk_ProdutoTag_Tag1]
    FOREIGN KEY ([Tag])
    REFERENCES [Tag] ([ID])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_ProdutoTag_Produto1]
    FOREIGN KEY ([Produto] , [Estabelecimento])
    REFERENCES [Produto] ([ID] , [EstabelecimentoId])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;
GO

CREATE INDEX [fk_ProdutoTag_Tag1_idx] ON [ProdutoTag] ([Tag] ASC);
GO

CREATE INDEX [fk_ProdutoTag_Produto1_idx] ON [ProdutoTag] ([Produto] ASC, [Estabelecimento] ASC);
GO

-- -----------------------------------------------------
-- Table `mydb`.`Preferencia`
-- -----------------------------------------------------
CREATE TABLE [Preferencia] (
  [Utilizador] INT NOT NULL,
  [Tag] INT NOT NULL,
  PRIMARY KEY ([Utilizador], [Tag])
 ,
  CONSTRAINT [fk_UtilizadorTag_Utilizador1]
    FOREIGN KEY ([Utilizador])
    REFERENCES [Utilizador] ([ID])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_UtilizadorTag_Tag1]
    FOREIGN KEY ([Tag])
    REFERENCES [Tag] ([ID])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;
GO

CREATE INDEX [fk_UtilizadorTag_Tag1_idx] ON [Preferencia] ([Tag] ASC);
GO

-- -----------------------------------------------------
-- Table `mydb`.`Horario`
-- -----------------------------------------------------
CREATE TABLE [Horario] (
  [Dia] INT NOT NULL,
  [Estabelecimento] INT NOT NULL,
  [HoraAbertura] TIME(0) NOT NULL,
  [HoraFecho] TIME(0) NOT NULL,
  PRIMARY KEY ([Dia], [Estabelecimento]),
  CONSTRAINT [fk_Horario_Estabelecimento1]
    FOREIGN KEY ([Estabelecimento])
    REFERENCES [Estabelecimento] ([ID])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;
GO

-- -----------------------------------------------------
-- Table `mydb`.`Visita`
-- -----------------------------------------------------
CREATE TABLE [Visita] (
  [ID] INT NOT NULL,
  [Utlizador] INT NOT NULL,
  [Produto] INT NOT NULL,
  [Estabelecimento] INT NOT NULL,
  [Data] DATETIME2(0) NOT NULL,
  PRIMARY KEY ([ID], [Utlizador], [Produto], [Estabelecimento])
 ,
  CONSTRAINT [fk_Visita_UtilizadorProduto1]
    FOREIGN KEY ([Utlizador] , [Produto] , [Estabelecimento])
    REFERENCES [UtilizadorProduto] ([Utilizador] , [Produto] , [Estabelecimento])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;
GO

CREATE INDEX [fk_Visita_UtilizadorProduto1_idx] ON [Visita] ([Utlizador] ASC, [Produto] ASC, [Estabelecimento] ASC);
GO

/* SET SQL_MODE=@OLD_SQL_MODE; */
/* SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS; */
/* SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS; */

