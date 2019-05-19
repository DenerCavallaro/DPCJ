//
// Esta classe é responsável por exibir a uma lista de ações que o usuário pode fazer em um evento e excluir ações
// @author: Dener
//


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Evento : MonoBehaviour {
    public string nomeEvento;
    public int posicao;
    private _GC gc;


    //
    // Executa ações no primeiro frame / seta a referência para _GC (Game Controller)
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    void Start () {
        gc = FindObjectOfType(typeof(_GC)) as _GC;
	}



    //
    // Exibe as ações
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public void exibirAcoes()
    {
        gc.exibirAcoes(posicao, nomeEvento);
    }

    //
    // Exclui a ação deste evento
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public void excluirAcao() {
        PlayerPrefs.SetString(nomeEvento, "Vazio");
        SceneManager.LoadScene("fluxogramas");
    }
}
