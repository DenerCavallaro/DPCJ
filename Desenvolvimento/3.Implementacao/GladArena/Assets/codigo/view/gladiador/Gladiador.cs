using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//
// Classe com os eventos que ocorrem em partida com o gladiador
// @author: Dener
//

public class Gladiador : MonoBehaviour {
    private IAcoesGladiador acoesGladiador;
    public Rigidbody2D gladiadorRB;
    public Transform posicaoLanca;
    private string aCadaTempo, aoColidir, alcanceInimigo, aoAtacar, aoDefender, aoSofrerDano, aoRotacionar, nickname;
    public Text nick;
    public Text txtVida;
    public int spriteInicial, numOponente;
    public bool oponente, morreu = false, venceu = false;
    private bool colisao = false;
    private int lanca = 0, leao = 0, gladiador = 0, coolDownAlcance = 0, coolDownAtacar = 0, coolDownDefender = 0;
    public GameObject defesa;
    public GameObject[] posicoes, lancas;
    private arena arena;



    //
    // recebe o nome da ação a ser realizada e encaminha para a função que a executa
    // @return <void- não há retorno>
    // @param <acao> <String que nomeia a ação a ser executada>
    // @exception <não há exceções> 
    //
    public void iniciarAcao(string acao)
    {
        if (acao != "Vazio")
        {
            if (acao == "atacar" && coolDownAtacar == 0)
            {
                StartCoroutine(acoesGladiador.atacar());
            }
            else if (acao == "denfender" && coolDownDefender == 0)
            {
                StartCoroutine(acoesGladiador.defender());
            }
            else if (acao == "rotacionar90")
            {
                acoesGladiador.rotacionar90();
            }
            else if (acao == "rotacionar180")
            {
                acoesGladiador.rotacionar180();
            }
            else if (acao == "rotacionar270")
            {
                acoesGladiador.rotacionar90();
            }

        }
    }


    //
    // Ações a serem executadas no primeiro frame do jogo / Seta as variáveis necessárias na camada abaixo (controller)
    // @return <void- não há retorno>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    void Start () {
        arena = FindObjectOfType(typeof(arena)) as arena;
        gladiadorRB = GetComponent<Rigidbody2D>();
        acoesGladiador = gameObject.AddComponent<AcoesGladiador>();
        acoesGladiador.setRigidBody(gladiadorRB);
        acoesGladiador.setLancas(lancas);
        acoesGladiador.setTxtVida(txtVida);
        acoesGladiador.setDefesa(defesa);
        acoesGladiador.setPosicaoLanca(posicaoLanca);
        acoesGladiador.setPosicoes(posicoes);
        acoesGladiador.posicaoInicial(spriteInicial);
        
        this.getEventos();
        this.setTextoNickname();
        StartCoroutine(sairDeColisao());
    }

    //
    // Inicializa os dados do gladiador em cena
    // @return <void- não há retorno>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public void getEventos() {
        if (oponente)
        {
            this.nickname = PlayerPrefs.GetString("nickname" + numOponente);
            
            this.aCadaTempo = PlayerPrefs.GetString("aCadaTempo" + numOponente);
            this.aoColidir = PlayerPrefs.GetString("aoColidir" + numOponente);
            this.alcanceInimigo = PlayerPrefs.GetString("alcanceAdversario" + numOponente);
            this.aoAtacar = PlayerPrefs.GetString("aoAtacar" + numOponente);
            this.aoDefender = PlayerPrefs.GetString("aoDefender" + numOponente);
            this.aoSofrerDano = PlayerPrefs.GetString("aoSofrerDano" + numOponente);
            this.aoRotacionar = PlayerPrefs.GetString("aoMudarDirecao" + numOponente);
        }else {
            this.nickname = PlayerPrefs.GetString("nickname");
            this.aCadaTempo = PlayerPrefs.GetString("aCadaTempo");
            this.aoColidir = PlayerPrefs.GetString("aoColidir");
            this.alcanceInimigo = PlayerPrefs.GetString("alcanceAdversario");
            this.aoAtacar = PlayerPrefs.GetString("aoAtacar");
            this.aoDefender = PlayerPrefs.GetString("aoDefender");
            this.aoSofrerDano = PlayerPrefs.GetString("aoSofrerDano");
            this.aoRotacionar = PlayerPrefs.GetString("aoMudarDirecao");
        }

        acoesGladiador.setEventos(aCadaTempo, aoColidir, alcanceInimigo, 
            aoAtacar, aoDefender, aoSofrerDano, aoRotacionar, nickname);
    }

    //
    // Desprende o gladiador se ele estiver preso em um objeto de cena
    // @return <retorna uma espera de 1 a 3 segundos>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public IEnumerator sairDeColisao() {
        colisao = true;
        yield return new WaitForSeconds(UnityEngine.Random.Range (1, 3));
        
        acoesGladiador.mudarDirecao(1);
            
        colisao = false;
    }

    //
    // Adiciona o nickname do jogador em um texto acima do seu gladiador
    // @return <void- não há retorno>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public void setTextoNickname() {
        nick.text = nickname;
    }

    //
    //Ações a serem executadas uma vez por frame / verifica se o gladiador morreu ou venceu uma partida
    // @return <void- não há retorno>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    void Update () {
        if (txtVida.text == "0") {
            if (morreu == false)
            {
                morreu = true;
                StartCoroutine(morte());
            }
            
        }
        if (arena.numGladiadoresVivos == 1) {
            if (venceu == false && morreu == false)
            {
                venceu = true;
                StartCoroutine(vitoria());
            }
            
        }
    }

    //
    // Destroi o gladiador morto e inicializa suas estatísticas
    // @return <retorna a espera da atualização de estatísticas>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    IEnumerator morte() {
        yield return StartCoroutine(atualizarEstatisticas(false));
        arena.morreu();
        Destroy(this.gameObject);
    }

    //
    // Inicializa as estatísticas do gladiador vencedor
    // @return <retorna a espera da atualização de estatísticas>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    IEnumerator vitoria() {
        yield return StartCoroutine(atualizarEstatisticas(true));
        SceneManager.LoadScene("home");
    }

    //
    // Recebe os dados estatísticos do gladiador repassa para o controlles
    // @return <retorna a espera da atualização de estatísticas>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    IEnumerator atualizarEstatisticas(bool vitoria) {
        IGerarEstatisticaController gerarEstatisticasController = gameObject.AddComponent<GerarEstatisticaController>();
        Jogador jogador = gameObject.AddComponent<Jogador>();
        jogador.Nickname = nickname;


        Estatistica estatisca = gameObject.AddComponent<Estatistica>();
        if (vitoria == true)
        {
            estatisca.Vitorias = 1;
            estatisca.Derrotas = 0;
        }
        else {
            estatisca.Derrotas = 1;
            estatisca.Vitorias = 0;
        }
        

        
        Dano dano = gameObject.AddComponent<Dano>();
        dano.Tipo = "gladiador";
        dano.Quantidade = lanca + gladiador;

        

        Dano dano2 = gameObject.AddComponent<Dano>();
        dano2.Tipo = "leoes";
        dano2.Quantidade = leao;
        

        jogador.Estatistica = estatisca;
        yield return gerarEstatisticasController.atualizarEstatisticas(jogador, dano, dano2);
    }

    //
    // Realiza alguma ação a cada 4 segundos
    // @return <retorna a espera de 4 segundos>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    IEnumerator aCada4Segundos() {
        
        yield return new WaitForSeconds(4);
        iniciarAcao(aCadaTempo);
        StartCoroutine(aCada4Segundos());
    }

    //
    // Detecta o momento de uma colisão
    // @return <não há>
    // @param <col> <recebe o valor do objeto no qual está de colidindo>
    // @exception <não há exceções> 
    //
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "lanca")
        {
            lanca++;
            acoesGladiador.soferDano();
        }
        else if (col.gameObject.tag == "leao")
        {
            leao++;
            acoesGladiador.soferDano();
        }
        else if (col.gameObject.tag == "gladiador") {
            acoesGladiador.soferDano();
            gladiador++;
            iniciarAcao(aoColidir);
        }
        else
        {
            iniciarAcao(aoColidir);
        }


    }

    //
    // Detecta a permanência de uma colisão
    // @return <não há>
    // @param <col> <recebe o valor do objeto no qual está de colidindo>
    // @exception <não há exceções> 
    //
    void OnCollisionStay2D(Collision2D col)
    {
        if (gladiadorRB.velocity.x < 2 && gladiadorRB.velocity.y < 2 && !colisao)
        {
            StartCoroutine(sairDeColisao());
        }
    }

    //
    //administra o tempo de recarga do detector de alcance (evita bugs visuais)
    // @return <retorna uma espera de 3 segundos>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public IEnumerator cdAlcance()
    {
        
        yield return new WaitForSeconds(3);
        coolDownAlcance = 0;
    }

    //
    // Detecta alguma trigger (alcance inimigo)
    // @return <não há>
    // @param <col> <recebe o valor do objeto que entrou no alcance da trigger>
    // @exception <não há exceções> 
    //
    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (coolDownAlcance == 0)
        {
            acoesGladiador.iniciarAcao(alcanceInimigo);
            coolDownAlcance = 3;
            StartCoroutine(cdAlcance());
        }
        
    }

    
}
