<?php

$idFluxograma = $_POST['idFluxograma'];
$aoAtacar = $_POST['aoAtacar'];
$aoDefender = $_POST['aoDefender'];
$aoColidr = $_POST['aoColidir'];
$aoMudarDirecao = $_POST['aoMudarDirecao'];
$aoSofrerDano = $_POST['aoSofrerDano'];
$aoAlcanceAdversario = $_POST['alcanceAdversario'];
$aoACadaTempo = $_POST['aCadaTempo'];

$pdo = new PDO('mysql:host=localhost;dbname=gladarena', "root", "");
$pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

$resultado = $pdo->query("UPDATE fluxograma SET aCadaTempo='" . $aoACadaTempo . "',alcanceAdversario='"
        . $aoAlcanceAdversario . "',aoAtacar='" . $aoAtacar . "',aoSofrerDano='" . $aoSofrerDano. "',"
        . "aoDefender='" . $aoDefender . "',aoMudarDirecao='" . $aoMudarDirecao . 
        "',aoColidir='" . $aoColidr. "' WHERE idFluxograma =" . $idFluxograma);



