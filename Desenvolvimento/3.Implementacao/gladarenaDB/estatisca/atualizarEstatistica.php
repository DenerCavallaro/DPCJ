<?php
$nickname = $_POST['nickname'];
$vitorias = $_POST['vitorias'];
$derrotas = $_POST['derrotas'];
$danoGladiador = $_POST['danoGlad'];
$danoLeao = $_POST['danoLeao'];

$pdo = new PDO('mysql:host=localhost;dbname=gladarena', "root", "");
$pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

$pdo = new PDO('mysql:host=localhost;dbname=gladarena', "root", "");
$pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

$consulta = $pdo->query("SELECT * FROM estatistica, dano, jogador "
        . "WHERE nickname = '" . $nickname. "' AND idJogador = jogador_idjogador"
        . " AND tipo = 'gladiador' AND idEstatistica = estatistica_idestatistica");

        while ($linha = $consulta->fetch(PDO::FETCH_ASSOC)){
            $idEstatistica = $linha['idEstatistica'];
            $vitorias += $linha['vitorias'];
            $derrotas += $linha['derrotas'];
            $danoGladiador += $linha['quantidade'];
        }
        
        $consulta = $pdo->query("SELECT * FROM estatistica, dano, jogador "
        . "WHERE nickname = '$nickname' AND idJogador = jogador_idjogador"
        . " AND idEstatistica = estatistica_idestatistica AND tipo = 'leoes'");

        while ($linha = $consulta->fetch(PDO::FETCH_ASSOC)){
            $danoLeao += $linha['quantidade']; 
            $danoRecebido = $danoLeao + $danoGladiador;
        }
        
        $resultado = $pdo->query("UPDATE estatistica SET danoRecebido = '" . $danoRecebido . "', vitorias = '"
                . $vitorias . "', derrotas = '" . $derrotas . "' WHERE idEstatistica ='" . $idEstatistica ."'");
       
        $resultado = $pdo->query("UPDATE dano SET quantidade = '" . $danoGladiador . 
                "' WHERE tipo = 'Gladiador'" ." AND estatistica_idestatistica = '" . $idEstatistica ."'");
        $resultado = $pdo->query("UPDATE dano SET quantidade = '" . $danoLeao . 
                "' WHERE estatistica_idestatistica = '" . $idEstatistica . "' AND tipo = 'leoes'");

        
        


