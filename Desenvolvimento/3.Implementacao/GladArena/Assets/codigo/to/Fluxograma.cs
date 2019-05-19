using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fluxograma : MonoBehaviour {
	private int 	idFluxograma;
	private string 	aCadaTempo;
	private string	alcanceAdversario;
	private string 	aoAtacar;
	private string	aoSofrerDano;
	private string	aoDefender;
	private string	aoMudarDirecao;
	private string 	aoColidir;
	private Jogador jogador;

    public int IdFluxograma
    {
        get
        {
            return idFluxograma;
        }

        set
        {
            idFluxograma = value;
        }
    }

    public string ACadaTempo
    {
        get
        {
            return aCadaTempo;
        }

        set
        {
            aCadaTempo = value;
        }
    }

    public string AlcanceAdversario
    {
        get
        {
            return alcanceAdversario;
        }

        set
        {
            alcanceAdversario = value;
        }
    }

    public string AoAtacar
    {
        get
        {
            return aoAtacar;
        }

        set
        {
            aoAtacar = value;
        }
    }

    public string AoSofrerDano
    {
        get
        {
            return aoSofrerDano;
        }

        set
        {
            aoSofrerDano = value;
        }
    }

    public string AoDefender
    {
        get
        {
            return aoDefender;
        }

        set
        {
            aoDefender = value;
        }
    }

    public string AoMudarDirecao
    {
        get
        {
            return aoMudarDirecao;
        }

        set
        {
            aoMudarDirecao = value;
        }
    }

    public string AoColidir
    {
        get
        {
            return aoColidir;
        }

        set
        {
            aoColidir = value;
        }
    }

    public Jogador Jogador
    {
        get
        {
            return jogador;
        }

        set
        {
            jogador = value;
        }
    }
}
