<?php

$pdo = new PDO('mysql:host=localhost;dbname=gladarena', "root", "");
$pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

$consulta = $pdo->query("SELECT * FROM jogador, fluxograma WHERE idJogador = jogador_idjogador");

        while ($linha = $consulta->fetch(PDO::FETCH_ASSOC)){
            echo $linha['nickname'] . "," . $linha['aCadaTempo'] . "," . $linha['alcanceAdversario']. ","
                 . $linha['aoAtacar']. "," . $linha['aoSofrerDano']. "," . $linha['aoDefender']. ","
                     . $linha['aoMudarDirecao']. "," . $linha['aoColidir']. ",";
        }
