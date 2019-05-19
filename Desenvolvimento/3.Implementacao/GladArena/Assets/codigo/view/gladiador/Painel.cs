using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// Classe responsável por exibir o nickname do gladiador em partida
// @author: Dener
//

public class Painel : MonoBehaviour {
    public Transform posicao;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (posicao != null)
        {
            this.transform.position = posicao.position;
        }
        else {
            Destroy(this.gameObject);
        }
        
	}
}
