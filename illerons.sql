-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 16/05/2021 às 19:49
-- Versão do servidor: 10.4.18-MariaDB
-- Versão do PHP: 7.4.16

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `illerons`
--

-- --------------------------------------------------------

--
-- Estrutura para tabela `personalizados`
--

CREATE TABLE `personalizados` (
  `Id` int(4) NOT NULL,
  `Nome` varchar(80) DEFAULT NULL,
  `DataNascimento` datetime DEFAULT NULL,
  `Telefone` varchar(80) DEFAULT NULL,
  `Email` varchar(80) DEFAULT NULL,
  `Roupa` varchar(80) DEFAULT NULL,
  `Detalhes` varchar(400) DEFAULT NULL,
  `Usuario` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura para tabela `usuario`
--

CREATE TABLE `usuario` (
  `Id` int(4) NOT NULL,
  `Nome` varchar(80) DEFAULT NULL,
  `Login` varchar(80) DEFAULT NULL,
  `Senha` varchar(80) DEFAULT NULL,
  `DataNascimento` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Despejando dados para a tabela `usuario`
--

INSERT INTO `usuario` (`Id`, `Nome`, `Login`, `Senha`, `DataNascimento`) VALUES
(2, '123', '123', '123', '2021-05-14 00:00:00'),
(3, '122', '122', '122', '2021-05-27 00:00:00');

--
-- Índices para tabelas despejadas
--

--
-- Índices de tabela `personalizados`
--
ALTER TABLE `personalizados`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `Usuario` (`Usuario`);

--
-- Índices de tabela `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT para tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `personalizados`
--
ALTER TABLE `personalizados`
  MODIFY `Id` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de tabela `usuario`
--
ALTER TABLE `usuario`
  MODIFY `Id` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Restrições para tabelas despejadas
--

--
-- Restrições para tabelas `personalizados`
--
ALTER TABLE `personalizados`
  ADD CONSTRAINT `personalizados_ibfk_1` FOREIGN KEY (`Usuario`) REFERENCES `usuario` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
