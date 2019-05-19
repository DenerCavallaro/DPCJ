using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estatistica : MonoBehaviour {
    private int idEstatistica;
    private int danoCausado;
    private int danoRecebido;
    private int vitorias;
    private int derrotas;
    private List<Dano> dano;

    public int IdEstatistica
    {
        get
        {
            return idEstatistica;
        }

        set
        {
            idEstatistica = value;
        }
    }

    public int DanoCausado
    {
        get
        {
            return danoCausado;
        }

        set
        {
            danoCausado = value;
        }
    }

    public int DanoRecebido
    {
        get
        {
            return danoRecebido;
        }

        set
        {
            danoRecebido = value;
        }
    }

    public int Vitorias
    {
        get
        {
            return vitorias;
        }

        set
        {
            vitorias = value;
        }
    }

    public int Derrotas
    {
        get
        {
            return derrotas;
        }

        set
        {
            derrotas = value;
        }
    }

    public List<Dano> Dano
    {
        get
        {
            return dano;
        }

        set
        {
            dano = value;
        }
    }
}
