using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// Classe responsável por dar direção à lança e destruí-la quando ela colidir com um objeto
// @author: Dener
//

public class Lanca : MonoBehaviour {
    public int direcao;
    public Rigidbody2D lancaRB;

	
	void Start () {
        lancaRB = GetComponent<Rigidbody2D>();
	}
	
	
	void Update () {
        if (direcao == 0)
        {
            lancaRB.velocity = new Vector3(-4, 0, 0);
        }
        else if (direcao == 1)
        {
            lancaRB.velocity = new Vector3(0, 4, 0);
        }
        else if (direcao == 2)
        {
            lancaRB.velocity = new Vector3(4, 0, 0);
        }
        else if (direcao == 3) {
            lancaRB.velocity = new Vector3(0, -4, 0);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
