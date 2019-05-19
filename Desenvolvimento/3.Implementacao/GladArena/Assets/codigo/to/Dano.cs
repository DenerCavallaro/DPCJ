using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dano : MonoBehaviour {
    private int idDano;
    private int quantidade;
    private string tipo;

    public int IdDano
    {
        get
        {
            return idDano;
        }

        set
        {
            idDano = value;
        }
    }

    public int Quantidade
    {
        get
        {
            return quantidade;
        }

        set
        {
            quantidade = value;
        }
    }

    public string Tipo
    {
        get
        {
            return tipo;
        }

        set
        {
            tipo = value;
        }
    }
}
