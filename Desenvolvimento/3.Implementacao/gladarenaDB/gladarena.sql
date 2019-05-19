-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 05-Dez-2018 às 22:07
-- Versão do servidor: 10.1.37-MariaDB
-- versão do PHP: 7.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `gladarena`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `dano`
--

CREATE TABLE `dano` (
  `idDano` int(11) NOT NULL,
  `quantidade` int(11) DEFAULT NULL,
  `tipo` varchar(45) DEFAULT NULL,
  `estatistica_idestatistica` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `dano`
--

INSERT INTO `dano` (`idDano`, `quantidade`, `tipo`, `estatistica_idestatistica`) VALUES
(1, 44, 'gladiador', 4),
(2, 13, 'leoes', 4),
(3, 26, 'gladiador', 5),
(4, 30, 'leoes', 5),
(5, 27, 'gladiador', 6),
(6, 8, 'leoes', 6),
(7, 41, 'gladiador', 7),
(8, 14, 'leoes', 7),
(9, 5, 'gladiador', 8),
(10, 9, 'leoes', 8),
(11, 0, 'gladiador', 9),
(12, 0, 'leoes', 9),
(13, 28, 'gladiador', 10),
(14, 12, 'leoes', 10);

-- --------------------------------------------------------

--
-- Estrutura da tabela `estatistica`
--

CREATE TABLE `estatistica` (
  `idEstatistica` int(11) NOT NULL,
  `danoCausado` int(11) DEFAULT NULL,
  `danoRecebido` int(11) DEFAULT NULL,
  `vitorias` int(11) DEFAULT NULL,
  `derrotas` int(11) DEFAULT NULL,
  `jogador_idjogador` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `estatistica`
--

INSERT INTO `estatistica` (`idEstatistica`, `danoCausado`, `danoRecebido`, `vitorias`, `derrotas`, `jogador_idjogador`) VALUES
(4, 0, 57, 2, 2, 14),
(5, 0, 56, 1, 3, 15),
(6, 0, 35, 0, 2, 16),
(7, 0, 55, 0, 3, 17),
(8, 0, 14, 1, 0, 18),
(9, 0, 0, 0, 0, 19),
(10, 0, 40, 0, 2, 20);

-- --------------------------------------------------------

--
-- Estrutura da tabela `fluxograma`
--

CREATE TABLE `fluxograma` (
  `idFluxograma` int(11) NOT NULL,
  `aCadaTempo` varchar(20) DEFAULT NULL,
  `alcanceAdversario` varchar(20) DEFAULT NULL,
  `aoAtacar` varchar(20) DEFAULT NULL,
  `aoSofrerDano` varchar(20) DEFAULT NULL,
  `aoDefender` varchar(20) DEFAULT NULL,
  `aoMudarDirecao` varchar(20) DEFAULT NULL,
  `aoColidir` varchar(20) DEFAULT NULL,
  `jogador_idjogador` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `fluxograma`
--

INSERT INTO `fluxograma` (`idFluxograma`, `aCadaTempo`, `alcanceAdversario`, `aoAtacar`, `aoSofrerDano`, `aoDefender`, `aoMudarDirecao`, `aoColidir`, `jogador_idjogador`) VALUES
(7, 'rotacionar90', 'rotacionar180', 'defender', 'rotacionar180', 'rotacionar180', 'atacar', 'rotacionar180', 14),
(8, 'rotacionar90', 'atacar', 'defender', 'atacar', 'atacar', 'Vazio', 'rotacionar270', 15),
(9, 'Vazio', 'atacar', 'Vazio', 'Vazio', 'Vazio', 'defender', 'rotacionar180', 16),
(10, 'atacar', 'Vazio', 'Vazio', 'defender', 'Vazio', 'Vazio', 'rotacionar270', 17),
(11, 'defender', 'Vazio', 'Vazio', 'Vazio', 'Vazio', 'atacar', 'rotacionar90', 18),
(12, 'rotacionar90', 'atacar', 'defender', 'defender', 'atacar', 'rotacionar270', 'atacar', 19),
(13, 'Vazio', 'Vazio', 'Vazio', 'Vazio', 'Vazio', 'Vazio', 'Vazio', 20);

-- --------------------------------------------------------

--
-- Estrutura da tabela `jogador`
--

CREATE TABLE `jogador` (
  `idJogador` int(11) NOT NULL,
  `nickname` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `senha` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `jogador`
--

INSERT INTO `jogador` (`idJogador`, `nickname`, `email`, `senha`) VALUES
(14, 'judgeJudy', 'dener@email', 'teste123'),
(15, 'Dca98', 'superdc@email', 'teste123'),
(16, 'SaintSilvio', 'denerCM@email', 'teste123'),
(17, 'Pelegolas', 'pela@email', 'teste123'),
(18, 'Relampago_Marquinhos', 'outroDener@email', 'teste123'),
(19, 'Gordo', 'email@email', 'gordo123'),
(20, 'gordo', 'gordo@email', 'gordo123');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `dano`
--
ALTER TABLE `dano`
  ADD PRIMARY KEY (`idDano`,`estatistica_idestatistica`),
  ADD KEY `fk_dano_estatistica1_idx` (`estatistica_idestatistica`);

--
-- Indexes for table `estatistica`
--
ALTER TABLE `estatistica`
  ADD PRIMARY KEY (`idEstatistica`,`jogador_idjogador`),
  ADD KEY `fk_estatistica_jogador1_idx` (`jogador_idjogador`);

--
-- Indexes for table `fluxograma`
--
ALTER TABLE `fluxograma`
  ADD PRIMARY KEY (`idFluxograma`,`jogador_idjogador`),
  ADD KEY `fk_fluxograma_jogador_idx` (`jogador_idjogador`);

--
-- Indexes for table `jogador`
--
ALTER TABLE `jogador`
  ADD PRIMARY KEY (`idJogador`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `dano`
--
ALTER TABLE `dano`
  MODIFY `idDano` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `estatistica`
--
ALTER TABLE `estatistica`
  MODIFY `idEstatistica` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `fluxograma`
--
ALTER TABLE `fluxograma`
  MODIFY `idFluxograma` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `jogador`
--
ALTER TABLE `jogador`
  MODIFY `idJogador` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- Constraints for dumped tables
--

--
-- Limitadores para a tabela `dano`
--
ALTER TABLE `dano`
  ADD CONSTRAINT `fk_dano_estatistica1` FOREIGN KEY (`estatistica_idestatistica`) REFERENCES `estatistica` (`idEstatistica`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Limitadores para a tabela `estatistica`
--
ALTER TABLE `estatistica`
  ADD CONSTRAINT `estatistica_ibfk_1` FOREIGN KEY (`jogador_idjogador`) REFERENCES `jogador` (`idJogador`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Limitadores para a tabela `fluxograma`
--
ALTER TABLE `fluxograma`
  ADD CONSTRAINT `fluxograma_ibfk_1` FOREIGN KEY (`jogador_idjogador`) REFERENCES `jogador` (`idJogador`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
