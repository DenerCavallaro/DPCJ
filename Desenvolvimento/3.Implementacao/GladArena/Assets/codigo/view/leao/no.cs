using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// Classe com que armazena a posição de um jogador
// @author: Dener
//

public class no : MonoBehaviour {
    public GameObject gladiador;
    
	
	void Start () {
		
	}
	
	
	void Update () {
        if (gladiador != null)
        {
            this.transform.position = gladiador.transform.position;
        }
        
	}
}
