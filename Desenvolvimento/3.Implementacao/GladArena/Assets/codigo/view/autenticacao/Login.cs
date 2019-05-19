using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//
// Classe com as entradas de dados do login de usuários/jogadores
// @author: Dener
//

public class Login : MonoBehaviour {
    public InputField email, senha;
    public Text txtSenha, txtSucesso;



    //
    // verificar se os campos de login são válidos
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public void verificar()
    {
        if (email.text.Length > 0 && senha.text.Length > 0) {
            this.autenticar();
        }
    }

    //
    // monta um objeto jogador e o passa para o controller
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public void autenticar() {
        Jogador jogador = gameObject.AddComponent<Jogador>();
        jogador.Nickname = email.text;
        jogador.Senha = senha.text;

        IManterUsuarioController manterUsuarioController = gameObject.AddComponent<ManterUsuarioController>();
        txtSucesso.text = manterUsuarioController.autenticarUsuario(jogador);
    }
}
