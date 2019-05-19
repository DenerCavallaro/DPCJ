<?php

require_once (__DIR__ . '/../conexao.php');

$email = $_POST['nickname'];
$senha = $_POST['senha'];

$pdo = new PDO('mysql:host=localhost;dbname=gladarena', "root", "");
$pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

$consulta = $pdo->query("SELECT COUNT(*) as total FROM jogador WHERE nickname = '". $email . 
        "' AND senha  = '". $senha . "'");
		$linha = $consulta->fetchAll();
                if ($linha[0]['total'] > 0) {
                    echo 'Usuario encontrado';
		}

