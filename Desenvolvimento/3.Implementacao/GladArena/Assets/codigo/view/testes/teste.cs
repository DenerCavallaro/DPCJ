using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//
// Classe de testes. Exibe a quantidade de quadros por segundo em partida
// @author: Dener
//

public class teste : MonoBehaviour {
    public Text quadrosPorSegundo;
    private int quadros = 0;

    //
    // Ações a serem realizadas no primeiro frame / inicia o método para se obter os quadros por segundo
    // @return <não há>
    // @param <collision> <objeto no qual o leão colidiu>
    // @exception <não há exceções> 
    //
    void Start () {
        StartCoroutine("fps");
    }

    //
    // Ações a serem realizadas em cada frame / conta o número de quadros
    // @return <não há>
    // @param <collision> <objeto no qual o leão colidiu>
    // @exception <não há exceções> 
    //
    void Update () {
        quadros++;
	}

    //
    // conta a quantidade de quadros em um segundo
    // @return <uma espera de 1 segundo>
    // @param <collision> <objeto no qual o leão colidiu>
    // @exception <não há exceções> 
    //
    IEnumerator fps() {
        yield return new WaitForSeconds(1);
        quadrosPorSegundo.text = quadros.ToString() + " FPS";
        quadros = 0;
        StartCoroutine("fps");
    }
}
