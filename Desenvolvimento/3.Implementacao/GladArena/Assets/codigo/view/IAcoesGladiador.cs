using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public interface IAcoesGladiador{

    void posicaoInicial(int spriteInicial);

    void setLancas(GameObject[] lancas);

    void setTxtVida(Text txtVida);

    void setPosicaoLanca(Transform posicaoLanca);

    void setDefesa(GameObject defesa);

    IEnumerator atacar();

    IEnumerator defender();

    void rotacionar90();

    void rotacionar180();

    void rotacionar270();
   

    void soferDano();

    void mudarDirecao(int direcao);

    void setRigidBody(Rigidbody2D gladidor);

    void setPosicoes(GameObject[] posicoes);

    void iniciarAcao(string acao);

    void realizarAcao(string acao);

    void setEventos(string aCadaTempo, string aoColidir, string alcanceInimigo, string aoAtacar,
        string aoDefender, string aoSofrerDano, string aoRotacionar, string nickname);
}
