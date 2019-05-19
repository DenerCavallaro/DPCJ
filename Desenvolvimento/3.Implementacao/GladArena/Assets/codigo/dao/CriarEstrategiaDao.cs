//
// Esta classe recebe os ações por eventos (através de um objeto Fluxograma) do controller e armazenam localmente ou 
//em um banco de dados. Esta classe também recupera estes dados
// @author: Dener
//


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class CriarEstrategiaDao : MonoBehaviour, ICriarEstrategiaDao {

    //
    // recupera os oponentes para a partida
    // @return <Uma espera do resultado vindo do bando de dados>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public IEnumerator recuperarOponentes()
    {
        List<Jogador> jogadores = new List<Jogador>();
        string url = "http://localhost/gladarenaDB/usuario/recuperarOponentes.php";
        WWW www = new WWW(url);
        yield return www;
        string resultado = www.text;
        string[] oponentes = resultado.Split(',');
        
        for (int i = 0; i < oponentes.Length / 8; i++)
        {
            Jogador jogador = gameObject.AddComponent<Jogador>();
            Fluxograma fluxograma = gameObject.AddComponent<Fluxograma>();

            jogador.Nickname = oponentes[0 + i * 8];
            
            fluxograma.ACadaTempo = oponentes[1 + i * 8];
            fluxograma.AlcanceAdversario = oponentes[2 + i * 8];
            fluxograma.AoAtacar = oponentes[3 + i * 8];
            fluxograma.AoSofrerDano = oponentes[4 + i * 8];
            fluxograma.AoDefender = oponentes[5 + i * 8];
            fluxograma.AoMudarDirecao = oponentes[6 + i * 8];
            fluxograma.AoColidir = oponentes[7 + i * 8];

            jogador.Fluxograma = fluxograma;

            jogadores.Add(jogador);
        }

        iniciarCenaJogar(jogadores);
        
    }

    //
    // pega todos os jogadores seleciona 3 aleatoriamente
    // @return <não há>
    // @param <jogadores> <lista de objetos de jogadores>
    // @exception <não há exceções> 
    //
    public void iniciarCenaJogar(List <Jogador> jogadores) {
        int a = 0, b = 0, c = 0, d= 0, i = 0;
        
        foreach (Jogador jogador in jogadores) {
            if (PlayerPrefs.GetString("nickname") == jogador.Nickname) {
                d = i;
            }
            i++;
        }
        
        
        while (a == b || b == c || a == c || a == d || b == d || c == d) {
            a = UnityEngine.Random.Range(0, i);
            b = UnityEngine.Random.Range(0, i);
            c = UnityEngine.Random.Range(0, i);
        }
        
        int[] elementos = { a, b, c };
        
        for (int j = 0; j < 3; j++)
        {
            PlayerPrefs.SetString("nickname" + j,jogadores[elementos[j]].Nickname);

            PlayerPrefs.SetString("aCadaTempo" + j, jogadores[elementos[j]].Fluxograma.ACadaTempo);
            PlayerPrefs.SetString("alcanceAdversario" + j, jogadores[elementos[j]].Fluxograma.AlcanceAdversario);
            PlayerPrefs.SetString("aoAtacar" + j, jogadores[elementos[j]].Fluxograma.AoAtacar);
            PlayerPrefs.SetString("aoSofrerDano" + j, jogadores[elementos[j]].Fluxograma.AoSofrerDano);
            PlayerPrefs.SetString("aoDefender" + j, jogadores[elementos[j]].Fluxograma.AoDefender);
            PlayerPrefs.SetString("aoMudarDirecao" + j, jogadores[elementos[j]].Fluxograma.AoMudarDirecao);
            PlayerPrefs.SetString("aoColidir" + j, jogadores[elementos[j]].Fluxograma.AoColidir);
        }
        
        SceneManager.LoadScene("arena");
    }

    //
    // atualiza o fluxograma
    // @return <uma espera dos dados vindos da dao>
    // @param <jogadores> <lista de objetos de jogadores>
    // @exception <não há exceções> 
    //
    IEnumerator ICriarEstrategiaDao.atualizarFluxograma(Fluxograma fluxograma)
    {
        string url = "http://localhost/gladarenaDB/fluxograma/atualizarFluxograma.php";
        WWWForm form = new WWWForm();
        form.AddField("idFluxograma", fluxograma.IdFluxograma);
        form.AddField("aoAtacar", fluxograma.AoAtacar);
        form.AddField("aoDefender", fluxograma.AoDefender);
        form.AddField("aoColidir", fluxograma.AoColidir);
        form.AddField("aoMudarDirecao", fluxograma.AoMudarDirecao);
        form.AddField("aoSofrerDano", fluxograma.AoSofrerDano);
        form.AddField("alcanceAdversario", fluxograma.AlcanceAdversario);
        form.AddField("aCadaTempo", fluxograma.ACadaTempo);

        WWW www = new WWW(url, form);
        yield return www;
        SceneManager.LoadScene("home");
    }

    //
    // recupera fluxograma através de um jogador
    // @return <uma espera dos dados vindos da dao>
    // @param <jogador> <objeto Jogador>
    // @exception <não há exceções> 
    //
    IEnumerator ICriarEstrategiaDao.recuperarFluxogramaPorJogador(Jogador jogador)
    {
        string url = "http://localhost/gladarenaDB/fluxograma/recuperarFluxogramaPorJogador.php";
        string[] eventos;

        WWWForm form = new WWWForm();

        form.AddField("nickname", jogador.Nickname);

        WWW confirmacao = new WWW(url, form);
        yield return confirmacao;
        string fluxograma = confirmacao.text;
        eventos = fluxograma.Split(',');
        
        PlayerPrefs.SetString("idFluxograma", eventos[0]);
        
        PlayerPrefs.SetString("aCadaTempo", eventos[1]);
        PlayerPrefs.SetString("alcanceAdversario", eventos[2]);
        PlayerPrefs.SetString("aoAtacar", eventos[3]);
        PlayerPrefs.SetString("aoSofrerDano", eventos[4]);
        PlayerPrefs.SetString("aoDefender", eventos[5]);
        PlayerPrefs.SetString("aoMudarDirecao", eventos[6]);
        PlayerPrefs.SetString("aoColidir", eventos[7]);
    }
}
