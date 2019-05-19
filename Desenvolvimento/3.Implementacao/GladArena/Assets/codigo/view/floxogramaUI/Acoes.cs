using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// Classe responsável por adicionar ações nos eventos
// @author: Dener
//

public class Acoes : MonoBehaviour
{
    private int posicao;
    public Transform[] posicoes;
    public GameObject[] acoes;
    private string nomeAcao, nomeEvento;
    private _GC gc;

    //
    // Ações a serem executadas no primeiro frame / seta a referência para o _GC (Game Controller)
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    void Start()
    {
        gc = FindObjectOfType(typeof(_GC)) as _GC;
    }

    //
    // Encapsulamento de posição
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public int Posicao
    {
        get
        {
            return posicao;
        }

        set
        {
            posicao = value;
        }
    }

    //
    // Encapsulamento de nomeEvento
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public string NomeEvento
    {
        get
        {
            return nomeEvento;
        }

        set
        {
            nomeEvento = value;
        }
    }

    //
    // Adiciona ação atacar
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public void atacar() {
        nomeAcao = "atacar";
        this.adicionarAcao();
    }

    //
    // Adiciona ação defender
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public void defender()
    {
        nomeAcao = "defender";
        this.adicionarAcao();
    }

    //
    // Adiciona ação rotacionar 90º
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public void rotacionar90()
    {
        nomeAcao = "rotacionar90";
        this.adicionarAcao();
    }

    //
    // Adiciona ação rotacionar 180º
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public void rotacionar180()
    {
        nomeAcao = "rotacionar180";
        this.adicionarAcao();
    }

    //
    // Adiciona ação rotacionar 270º
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public void rotacionar270()
    {
        nomeAcao = "rotacionar270";
        this.adicionarAcao();
    }

    //
    // Adiciona ação
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public void adicionarAcao() {
        foreach (GameObject a in acoes) {
            if (a.tag == nomeAcao) {
                gc.adicionarAcao(nomeAcao, NomeEvento, a, posicao);
                this.gameObject.SetActive(false);
            }
        }

        
    }

}
