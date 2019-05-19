using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//
// Classe com as entradas de dados do cadastro de novos usuários/jogadores
// @author: Dener
//

public class Cadastro : MonoBehaviour {
    public InputField nickname, email, senha, confirmacaoSenha;
    public Text txtSenha, txtConfimarcaoSenha, txtSucesso;



    //
    // ações a serem executadas por frame / verifica se os campos do cadastro são válidos
    // @return <não hpa>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    void Update () {
        this.verificarCampos();
	}

    //
    // verifica se os campos do cadastro são válidos
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    void verificarCampos() {
        if (senha.text.Length < 6 && senha.text.Length > 0)
        {
            txtSenha.text = "Senha muito fraca!";
        }
        else {
            txtSenha.text = "";
        }

        if (senha.text.Length > 0 && confirmacaoSenha.text.Length > 0 && senha.text != confirmacaoSenha.text)
        {
            txtConfimarcaoSenha.text = "As senhas não estão iguais!";
        }
        else {
            txtConfimarcaoSenha.text = "";
        }
    }

    //
    // verifica se os campos do cadastro são válidos após o clique
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public void validarCampos() {
        int i = 0;
        if (nickname.text.Length > 0 && email.text.Length > 0 && senha.text.Length > 0 && confirmacaoSenha.text.Length > 0)
        {
            i++;
        }
        else {
            txtSucesso.text = "Campo(s) vazio(s)!";
        }


        if (senha.text == confirmacaoSenha.text) {
            i++;
        } else
        {
            txtSucesso.text = "As senhas não são iguais!";
        }
        if (i == 2) {
            this.cadastrarJogador();
        }
    }

    //
    // cria um objeto jogador e passa para o controller
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    void cadastrarJogador() {
        Jogador jogador = new Jogador();
        jogador.Nickname = nickname.text;
        jogador.Email = email.text;
        jogador.Senha = senha.text;

        IManterUsuarioController manterUsuarioController = new ManterUsuarioController();
        txtSucesso.text = manterUsuarioController.cadastrarUsuario(jogador);
    }
}
