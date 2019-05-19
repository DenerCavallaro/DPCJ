using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//
// Classe Esta classe recebe os dados de um usuário (através de um objeto Jogador) do controller e armazena localmente ou
//em um banco de dados. Esta classe também recupera estes dados
// @author: Dener
//


public class ManterUsuarioDao : MonoBehaviour, IManterUsuarioDao
{
    Jogador jog;

    //
    // Recupera os dados do jogador para autenticar
    // @return <um erro>
    // @param <jogador> <objeto do tipo Jogador>
    // @exception <não há exceções> 
    //
    public string autenticarUsuario(Jogador jogador)
    {
        this.jog = jogador;
        StartCoroutine(verificarUsuario());
        return "Email ou senha incorretos!";
    }

    //
    // Verifica usuário e email do jogador
    // @return <uma espera dos dados vindos do banco de dados>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public IEnumerator verificarUsuario() {
        string url = "http://localhost/gladarenaDB/usuario/autenticar.php";

        WWWForm form = new WWWForm();
        
        form.AddField("nickname", jog.Nickname);
        form.AddField("senha", jog.Senha);

        WWW confirmacao = new WWW(url, form);
        yield return confirmacao;
        if (confirmacao.text.Length > 0) {
            PlayerPrefs.SetString("nickname", jog.Nickname);
            SceneManager.LoadScene("home");
        }
    }

    //
    // Cadastra usuário
    // @return <não há>
    // @param <jogador> <objeto do tipo Jogador>
    // @exception <erro de SQL> 
    //
    public string cadastrarUsuario(Jogador jogador)
    {    
        string url = "http://localhost/gladarenaDB/usuario/cadastrarUsuario.php";
        try {
            WWWForm form = new WWWForm();
            form.AddField("nickname", jogador.Nickname);
            form.AddField("email", jogador.Email);
            form.AddField("senha", jogador.Senha);
            WWW www = new WWW(url, form);
            PlayerPrefs.SetString("nickname", jogador.Nickname);
            SceneManager.LoadScene("home");
            return "Jogador " + jogador.Nickname + " cadastrado com sucesso!";
        }
        catch (System.Exception e) {
            return "Erro ao cadastrar jogador: " + e.Message;
        }
    }

    public Jogador setIdJogadorPorNickname(string nickname)
    {
        throw new System.NotImplementedException();
    }
}
