using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// Esta classe recebe as estatísticas (através de um objeto Jogador) do controller e armazena
//em um banco de dados. Esta classe também recupera estes dados
// @author: Dener
//

public class GerarEstrategiaDao : MonoBehaviour, IGerarEstrategiaDao {

    //
    // atualiza as estatísticas
    // @return <uma espera dos dados vindos da dao>
    // @param <jogador> <objeto do tipo jogador>
    // @param <dano1> <objeto dano do tipo gladiador>
    // @param <dano2> <objeto dano do tipo leao>
    // @exception <não há exceções> 
    //
    public IEnumerator atualizarEstatisticas(Jogador jogador, Dano dano1, Dano dano2)
    {
        string url = "http://localhost/gladarenaDB/estatisca/atualizarEstatistica.php";
        WWWForm form = new WWWForm();
        form.AddField("nickname", jogador.Nickname);
        form.AddField("vitorias", jogador.Estatistica.Vitorias);
        form.AddField("derrotas", jogador.Estatistica.Derrotas);
        form.AddField("danoGlad", dano1.Quantidade);
        form.AddField("danoLeao", dano2.Quantidade);
        


        WWW www = new WWW(url, form);
        
        yield return www;
        print(www.text);
    }

    //
    // Recupera as estatísticas de um jogador através de um nickname
    // @return <uma espera dos dados vindos da dao>
    // @param <nickname> <string com o nickname do jogador>
    // @exception <não há exceções> 
    //
    public IEnumerator RecuperarEstatisticaPorNickname(string nickname)
    {
        string url = "http://localhost/gladarenaDB/estatisca/recuperarEstatisticaPorNickname.php";
        WWWForm form = new WWWForm();
        form.AddField("nickname", nickname);
        WWW www = new WWW(url, form);
        yield return www;
        string dados = www.text;
        string[] estatisticas = dados.Split(',');

        
        PlayerPrefs.SetString("Vitorias", estatisticas[0]);
        PlayerPrefs.SetString("Derrotas", estatisticas[1]);
        PlayerPrefs.SetString("danoGladiador", estatisticas[2]);
        PlayerPrefs.SetString("danoLeao", estatisticas[3]);
        PlayerPrefs.SetString("danoTotal", estatisticas[4]);
    }

}
