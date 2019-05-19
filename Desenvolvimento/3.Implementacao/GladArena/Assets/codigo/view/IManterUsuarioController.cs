using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IManterUsuarioController {

    string autenticarUsuario(Jogador jogador);

    string cadastrarUsuario(Jogador jogador);

    Jogador setIdJogadorPorNickname(string nickname);
	
}
