<?php

include (__DIR__ . '/../conexao.php');

$nickname = $_POST['nickname'];
$email = $_POST['email'];
$senha = $_POST['senha'];

$sql = "INSERT INTO jogador (nickname, email, senha) VALUES ('" . $nickname . "','" . $email . "','"
        . $senha ."')";
$resultado = mysqli_query($conectar, $sql);

$pdo = new PDO('mysql:host=localhost;dbname=gladarena', "root", "");
$pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

$consulta = $pdo->query("SELECT * FROM jogador WHERE email = '". $email . "'");
		
		while ($linha = $consulta->fetch(PDO::FETCH_ASSOC)) {	
                    $idJogador = $linha['idJogador'];
		}

$sql = "INSERT INTO fluxograma (aCadaTempo, alcanceAdversario, aoAtacar, aoSofrerDano, aoDefender, "
        . "aoMudarDirecao, aoColidir, jogador_idjogador) VALUES "
        . "('Vazio','Vazio','Vazio','Vazio','Vazio','Vazio','Vazio',". $idJogador .")";
$resultado = mysqli_query($conectar, $sql);

$sql = "INSERT INTO estatistica (danoCausado, danoRecebido, vitorias, derrotas,"
        . " jogador_idjogador) VALUES (0,0,0,0,". $idJogador .")";
$resultado = mysqli_query($conectar, $sql);

$consulta = $pdo->query("SELECT * FROM estatistica WHERE jogador_idjogador = '". $idJogador . "'");
		
		while ($linha = $consulta->fetch(PDO::FETCH_ASSOC)) {	
                    $idEstatistica = $linha['idEstatistica'];
		}
                
$sql = "INSERT INTO dano (quantidade, tipo, estatistica_idestatistica) VALUES "
        . "(0,'gladiador',". $idEstatistica .")";
$resultado = mysqli_query($conectar, $sql);

$sql = "INSERT INTO dano (quantidade, tipo, estatistica_idestatistica) VALUES "
        . "(0,'leoes',". $idEstatistica .")";
$resultado = mysqli_query($conectar, $sql);