using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// Classe com as ações do leão.
// @author: Dener
//

public class Leao : MonoBehaviour {
    public Transform[] gladiadores;
    public Transform destino, gladiador;
    public Rigidbody2D leaoRB;
    private int vida = 15, alvo = 0;

    //
    // ação a ser realizada no primeiro frame / Obtem o componete RigidBody2D para o leão
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    void Start () {
        leaoRB = GetComponent<Rigidbody2D>();
	}

    //
    // ação a ser realizada a cada frame / Verificar se o leão morreu e modifica seu alvo de perseguição
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    void Update () {
        if (vida <= 0) {
            Destroy(this.gameObject);
        }

        if (alvo == 0)
        {
            entrar();
        }
        else if (alvo == 1) {
            perseguirGladiador();
        } 
        
    }

    //
    // Faz o leão entrar na arena
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    void entrar() {
        leaoRB.position = Vector3.MoveTowards(leaoRB.position,destino.position, 3 * Time.deltaTime);
    }

    //
    // Faz o leão perseguir algum gladiador
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    void perseguirGladiador() {
       
        
       
        leaoRB.position = Vector3.MoveTowards(leaoRB.position,gladiador.position, 3 * Time.deltaTime);
    }

    //
    // Detecta no que o leão colidiu
    // @return <não há>
    // @param <collision> <objeto no qual o leão colidiu>
    // @exception <não há exceções> 
    //
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag) {
            case "gladiador":
                vida--;
                
                break;
            case "lanca":
                vida--;
                break;
            case "morte":
                Destroy(this.gameObject);
                break;
        }
        if (vida > 0)
        {
            mudarAlvo();
            alvo = 1;
        }
        
    }

    //
    // Muda o alvo do leão
    // @return <não há>
    // @param <collision> <objeto no qual o leão colidiu>
    // @exception <não há exceções> 
    //
    void mudarAlvo() {
        gladiador = gladiadores[UnityEngine.Random.Range(0, 3)];
    }
}
