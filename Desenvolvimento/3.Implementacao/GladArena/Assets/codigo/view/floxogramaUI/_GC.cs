using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//
// Classe com a implementação das operações de persistência de dados dos fluxogramas
// @author: Dener
//

public class _GC : MonoBehaviour {



    private Acoes ac;
    public GameObject listaAcoes;
    public GameObject[] eventos, acoes;
    public Transform[] posicoesAcoes;
    public string[] nomeEventos;



    //
    // Realiza as ações no primeiro frame / inicia o método de verificar eventos
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    void Start()
    {
        
        this.verificarEventos();
    }

    //
    // Adiciona as ações previamente cadastradas em seus respectivos eventos
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    void verificarEventos()
    {
        int i = 0, j = 0;
        foreach (GameObject evento in eventos)
        {
            if (PlayerPrefs.GetString(nomeEventos[i]) != "Vazio")
            {
                

                foreach (GameObject acao in acoes) {
                    if (acao.tag == PlayerPrefs.GetString(nomeEventos[i])) {
                        float x = posicoesAcoes[i].position.x;
                        float y = posicoesAcoes[i].position.y;
                        float z = posicoesAcoes[i].position.z;
                        Instantiate(acao, new Vector3(x, y, z), Quaternion.identity);
                    }
                }
            }
            i++;
            
        }
    }

    //
    // Exibe as ações
    // @return <não há>
    // @param <posicao> <posição em que a ação será instancializada>
    // @param <nomeEvento> <evento no qual esta ação fará parte>
    // @exception <não há exceções> 
    //
    public void exibirAcoes(int posicao, string nomeEvento) {
        listaAcoes.SetActive(true);
        ac = FindObjectOfType(typeof(Acoes)) as Acoes;
        ac.Posicao = posicao;
        ac.NomeEvento = nomeEvento;
    }

    public void adicionarEvento(GameObject evento, string nomeEvento) {
        


    }

    //
    // Adiciona uma ação
    // @return <não há>
    // @param <nomeAcao> <NOme da ação a ser setada>
    // @param <evento> <evento no qual esta ação fará parte>
    // @param <acao> <ícone da acao>
    // @param <posicao> <posicao em que a acao será instancializada>
    // @exception <não há exceções> 
    //
    public void adicionarAcao(string nomeAcao, string evento, GameObject acao, int posicao)
    {
        PlayerPrefs.SetString(evento, nomeAcao);
        
        float x = posicoesAcoes[posicao].position.x;
        float y = posicoesAcoes[posicao].position.y;
        float z = posicoesAcoes[posicao].position.z;


        Instantiate(acao, new Vector3 (x,y,z), Quaternion.identity);
        
    }

    //
    // Cancela as alterações feitas e volta para o menu Home
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public void cancelar() {
        SceneManager.LoadScene("home");
    }

    //
    // Cancela as alterações feitas
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public void limparFluxograma() {
        PlayerPrefs.SetString("aCadaTempo", "Vazio");
        PlayerPrefs.SetString("alcanceAdversario", "Vazio");
        PlayerPrefs.SetString("aoAtacar", "Vazio");
        PlayerPrefs.SetString("aoSofrerDano", "Vazio");
        PlayerPrefs.SetString("aoDefender", "Vazio");
        PlayerPrefs.SetString("aoMudarDirecao", "Vazio");
        PlayerPrefs.SetString("aoColidir", "Vazio");


        SceneManager.LoadScene("fluxogramas");
    }
}
