<?php

$nickname = $_POST ['nickname'];


$pdo = new PDO('mysql:host=localhost;dbname=gladarena', "root", "");
$pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

$consulta = $pdo->query("SELECT * FROM estatistica, dano, jogador "
        . "WHERE nickname = '" . $nickname. "' AND idJogador = jogador_idjogador"
        . " AND tipo = 'gladiador' AND idEstatistica = estatistica_idestatistica");

        while ($linha = $consulta->fetch(PDO::FETCH_ASSOC)){
            echo $linha['vitorias'] . "," . $linha['derrotas'] . "," . $linha['quantidade']. ",";
        }
        
$consulta = $pdo->query("SELECT * FROM estatistica, dano, jogador "
        . "WHERE nickname = '$nickname' AND idJogador = jogador_idjogador"
        . " AND idEstatistica = estatistica_idestatistica AND tipo = 'leoes'");

        while ($linha = $consulta->fetch(PDO::FETCH_ASSOC)){
            echo $linha['quantidade'] . "," . $linha['danoRecebido'];
        }

