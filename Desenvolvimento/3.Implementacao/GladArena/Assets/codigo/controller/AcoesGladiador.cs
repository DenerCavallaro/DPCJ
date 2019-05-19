using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//
// Classe com as ações que acontecem com os eventos ocrridos com o Gladiador através da classe Gladiador
// @author: Dener
//

public class AcoesGladiador : MonoBehaviour, IAcoesGladiador {
    private GameObject[] posicoes, lancas;
    private GameObject defesa;
    public Transform posicaoLanca;
    private Text txtVida;
    private Rigidbody2D gladiadorRB;
    private string aCadaTempo, aoColidir, alcanceInimigo, aoAtacar, aoDefender, aoSofrerDano, aoRotacionar, nickname;
    private int coolDownAtacar = 0, coolDownDefender = 0, spriteInicial, vida = 15;
    private bool defendendo = false;

    //
    //recebe a quantidade de vida do gladiador
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public void setTxtVida(Text txtVida) {
        this.txtVida = txtVida;
    }

    //
    //recebe os sprites com as direções de cada gladiador
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public void setPosicoes(GameObject[] posicoes) {
        this.posicoes = posicoes;
    }

    //
    //recebe a posição em que a lança será instancializada
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public void setPosicaoLanca(Transform posicaoLanca) {
        this.posicaoLanca = posicaoLanca;
    }

    //
    //recebe o sprite que indicará que o gladiador está se defendendo
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public void setDefesa(GameObject defesa) {
        this.defesa = defesa;
    }

    //
    //recebe as ações de cada evento
    // @return <não há>
    // @param <aCadaTempo> <Ação a ser realizada a cada 4 segundos>
    // @param <aoColidir> <Ação a ser realizada quando colidir com alguma coisa>
    // @param <alcanceInimigo> <Ação a ser realizada ao entrar no alcance inimigo>
    // @param <aoAtacar> <Ação a ser realizada assim que for efetuado um ataque>
    // @param <aoDefender> <Ação a ser realizada assim que a defesa for ativa>
    // @param <aoSofrerDano> <Ação a ser realizada assim que se sofre dano>
    // @param <aoRotacionar> <Ação a ser realizada assim que se rotacionar>
    // @param <nickname> <Nickname do jogador>
    // @exception <não há exceções> 
    //
    public void setEventos(string aCadaTempo, string aoColidir, string alcanceInimigo, string aoAtacar,
        string aoDefender, string aoSofrerDano, string aoRotacionar, string nickname) {

        this.nickname = nickname;
        this.aCadaTempo = aCadaTempo;
        this.aoColidir = aoColidir;
        this.alcanceInimigo = alcanceInimigo;
        this.aoAtacar = aoAtacar;
        this.aoDefender = aoDefender;
        this.aoSofrerDano = aoSofrerDano;
        this.aoRotacionar = aoRotacionar;
    }

    //
    // Recebe a ação a ser realizada e chama o método que vai realizá-la
    // @return <não há>
    // @param <acao> <string que contém o nome da ação a ser realizada>
    // @exception <não há exceções> 
    //
    public void iniciarAcao(string acao) {
        if (acao != "Vazio")
        {
            if (acao == "atacar" && coolDownAtacar == 0)
            {
                StartCoroutine(atacar());
            }
            else if (acao == "defender" && coolDownDefender == 0)
            {
                StartCoroutine(defender());
            }

            StartCoroutine(acao);
        }
    }


    //
    // Executa a ação de atacar e chama o evento de nome "ao atacar"
    // @return <Uma espera de 5 segundos>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public IEnumerator atacar() {
        if (coolDownAtacar == 5)
        {
            yield return new WaitForSeconds(0.1f);
        }
        else {
            coolDownAtacar = 5;
            float x = posicaoLanca.position.x;
            float y = posicaoLanca.position.y;
            GameObject l = Instantiate(lancas[spriteInicial]);
            l.transform.position = posicaoLanca.position;
            yield return new WaitForSeconds(5);
            iniciarAcao(aoAtacar);
            coolDownAtacar = 0;
        }
        
    }

    //
    // Dimiui a vida em uma unidade e chama o evento de nome "ao sofrer dano"
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public void soferDano() {
        if (defendendo == false)
        {
            vida--;
        }
        
        txtVida.text = vida.ToString();
        iniciarAcao(aoSofrerDano);
    }

    //
    // Exibe um ícone de defesa e impede que o gladiador sofra dano
    // @return <uma espera de 10 segundos>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public IEnumerator defender() {
        if (coolDownDefender == 10)
        {
            yield return new WaitForSeconds(0.1f);
        } else
        {
            coolDownDefender = 10;
            defesa.SetActive(true);
            defendendo = true;
            yield return new WaitForSeconds(3);
            defendendo = false;
            defesa.SetActive(false);

            yield return new WaitForSeconds(10);
            iniciarAcao(aoDefender);
            coolDownDefender = 0;
        }
                
    }

    //
    // Muda a direção do gladiador
    // @return <não há>
    // @param <direcao> <nova direção do gladiador>
    // @exception <não há exceções> 
    //
    public void mudarDirecao(int direcao) {

        spriteInicial += direcao;
        if (spriteInicial >= 4) {
            spriteInicial -= 4;
        }

        for (int i = 0; i < 4; i++) {
            if (i != spriteInicial)
            {
                posicoes[i].SetActive(false);
            }
            else {
                posicoes[i].SetActive(true);
            }
        }
        
    }

    //
    // Passa para o método "mudarDirecao" a rotação de 90º
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public void rotacionar90 () {
        mudarDirecao(1);
        iniciarAcao(aoRotacionar);
    }

    //
    // Passa para o método "mudarDirecao" a rotação de 180º
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public void rotacionar180() {
        mudarDirecao(2);
        iniciarAcao(aoRotacionar);
    }

    //
    // Passa para o método "mudarDirecao" a rotação de 270º
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public void rotacionar270() {
        mudarDirecao(3);
        iniciarAcao(aoRotacionar);
    }

    //
    // Ações a serem realizada em cada frame / adiciona a velocidade certa para cada direção
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    void Update() {
        

        if (spriteInicial == 0)
        {
            gladiadorRB.velocity = new Vector3(-2, 0, 0);
        }
        else if (spriteInicial == 1)
        {
            gladiadorRB.velocity = new Vector3(0, 2, 0);
        }
        else if (spriteInicial == 2)
        {
            gladiadorRB.velocity = new Vector3(2, 0, 0);
        }
        else if (spriteInicial == 1)
        {
            gladiadorRB.velocity = new Vector3(0, -2, 0);
        }

        
    }

    //
    // Adiciona a velocidade e o sprite inicial
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public void posicaoInicial(int spriteInicial)
    {
        this.spriteInicial = spriteInicial;
        posicoes[spriteInicial].SetActive(true);

        for (int i = 0; i < 4; i++)
        {
            if (i != spriteInicial)
            {
                posicoes[i].SetActive(false);
            }
        }
    }

    public void realizarAcao(string acao)
    {
        throw new System.NotImplementedException();
    }

    //
    // Recebe o gladiador que realizará as ações deste arquivo
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public void setRigidBody(Rigidbody2D gladidor)
    {
        this.gladiadorRB = gladidor;
        
    }

    //
    // Recebe as lanças que serão intancilizadas para atacar
    // @return <não há>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public void setLancas(GameObject[] lancas)
    {
        this.lancas = lancas;        
    }
}
