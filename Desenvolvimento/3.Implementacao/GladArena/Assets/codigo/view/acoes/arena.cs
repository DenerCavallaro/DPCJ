using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//
// Classe responsável por detectar o gladiador vencedor e instancializar leões
// @author: Dener
//

public class arena : MonoBehaviour {
    public int numGladiadoresVivos = 4;
    public GameObject leao;
    public Transform spawnLeao;


    //
    //Ações a serem executadasno primeir frame / inicia a método para se instancilizar o primeiro leão
    // @return <void- não há retorno>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    void Start () {
        StartCoroutine(primeiroLeao());
	}


    //
    // ações a serem realizadas por frame / verifica quem é o vencedor
    // @return <void- não há retorno>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    void Update () {
        if (numGladiadoresVivos <= 1) {
            print(numGladiadoresVivos);
            voltar();
        }
	}

    //
    //Conta o número de gladiadores mortos
    // @return <void- não há retorno>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public void morreu() {
        numGladiadoresVivos--;
    }

    //
    //Instancializa o primeiro leão
    // @return <retorna uma espera de 20 segundos>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public IEnumerator primeiroLeao() {
        yield return new WaitForSeconds (20);
        Instantiate(leao, spawnLeao.position, Quaternion.identity);
        StartCoroutine(instancializarLeoes());
    }

    //
    // adiciona derrota a todos os gladiadores e volta para o menu
    // @return <retorna de 3 segundos>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public IEnumerator voltar() {

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("home");
    }

    //
    // Tem 40 % de instacializar leoes na cena
    // @return <retorna de 20 segundos>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public IEnumerator instancializarLeoes()
    {
        yield return new WaitForSeconds(20);
        if (UnityEngine.Random.Range (1,10) > 4)
        {
            Instantiate(leao, spawnLeao.position, Quaternion.identity);
        }
        
        instancializarLeoes();
    }
    
}
