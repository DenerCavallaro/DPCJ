using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//
// Classe responsável por retornar as estatíticas do jogador
// @author: Dener
//

public class ManterEstatiscasView : MonoBehaviour {
    public Text txtVitorias, txtDerrotas, txtDanoGladiador, txtDanoLeao, txtDanoTotal;

    //
    // Executa ações no primeiro frame / chama a função para recuperar as estatísticas do jogador logado
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    void Start () {
        StartCoroutine("recuperarEstatisticaPorNickname");
	}

    //
    // Recupera as estatísticas do jogador logado
    // @return <retorna uma espera pelos dados vindos do controller>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    IEnumerator recuperarEstatisticaPorNickname() {
        IGerarEstatisticaController gerarEstatisticaController = gameObject.AddComponent<GerarEstatisticaController>();
        yield return StartCoroutine (gerarEstatisticaController.RecuperarEstatisticaPorNickname(PlayerPrefs.GetString("nickname")));

        
        txtVitorias.text = PlayerPrefs.GetString("Vitorias");
        txtDerrotas.text = PlayerPrefs.GetString("Derrotas");
        txtDanoGladiador.text = PlayerPrefs.GetString("danoGladiador");
        txtDanoLeao.text = PlayerPrefs.GetString("danoLeao");
        txtDanoTotal.text = PlayerPrefs.GetString("danoTotal");
    }

}
