//
// Esta classe é responsável por recuperar o fluxograma se o usuário quiser editá-lo após criar
// @author: Dener
//


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManterFluxograma : MonoBehaviour {
	//
	// Este método é chamado no primeiro frame.
	//
	public void Start () {
        this.recuperarFluxograma();

    }
	
	//
	// Este método é chamado em todos os outros frames.
	//
	public void Update () {
		
	}

    public void sair() {
        SceneManager.LoadScene("autenticacao");
    }
    void recuperarFluxograma() {
        ICriarEstrategiaController criarEstrategiaController = gameObject.AddComponent<CriarEstrategiaController>();
        Jogador jogador = gameObject.AddComponent<Jogador>();
        jogador.Nickname = PlayerPrefs.GetString("nickname");
       
        criarEstrategiaController.recuperarFluxogramaPorJogador(jogador);
    }

    public void atualizarFluxograma() {
        ICriarEstrategiaController criarEstrategiaController = gameObject.AddComponent<CriarEstrategiaController>();
        Fluxograma fluxograma = new Fluxograma();
        int idFluxograma;
        int.TryParse(PlayerPrefs.GetString("idFluxograma"),out idFluxograma);

        fluxograma.IdFluxograma = idFluxograma;
        fluxograma.AoAtacar = PlayerPrefs.GetString("aoAtacar");
        fluxograma.AoColidir = PlayerPrefs.GetString("aoColidir");
        fluxograma.AoDefender = PlayerPrefs.GetString("aoDefender");
        fluxograma.AoMudarDirecao = PlayerPrefs.GetString("aoMudarDirecao");
        fluxograma.AoSofrerDano = PlayerPrefs.GetString("aoSofrerDano");
        fluxograma.AlcanceAdversario = PlayerPrefs.GetString("alcanceAdversario");
        fluxograma.ACadaTempo = PlayerPrefs.GetString("aCadaTempo");

        criarEstrategiaController.atualizarFluxograma(fluxograma);

    }

    public void iniciar() {
        StartCoroutine(recuperarOponentes());
    }
    public IEnumerator recuperarOponentes() {
        ICriarEstrategiaController criarEstrategiaController = gameObject.AddComponent<CriarEstrategiaController>();
        yield return StartCoroutine(criarEstrategiaController.recuperarOponetes());
    }

    public void carregarCenaFluxograma() {
        SceneManager.LoadScene("fluxogramas");
    }
	
}
