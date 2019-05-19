using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour {

	private int 	idJogador;
	private string 	nickname;
	private string 	email;
    private string senha;
	private Fluxograma fluxograma;
    private Estatistica estatistica;

    public int IdJogador
    {
        get
        {
            return idJogador;
        }

        set
        {
            idJogador = value;
        }
    }

    public string Nickname
    {
        get
        {
            return nickname;
        }

        set
        {
            nickname = value;
        }
    }

    public string Email
    {
        get
        {
            return email;
        }

        set
        {
            email = value;
        }
    }

    public Fluxograma Fluxograma
    {
        get
        {
            return fluxograma;
        }

        set
        {
            fluxograma = value;
        }
    }

    public Estatistica Estatistica
    {
        get
        {
            return estatistica;
        }

        set
        {
            estatistica = value;
        }
    }

    public string Senha
    {
        get
        {
            return senha;
        }

        set
        {
            senha = value;
        }
    }
}
