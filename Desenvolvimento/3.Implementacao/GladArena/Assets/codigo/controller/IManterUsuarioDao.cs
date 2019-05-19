using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IManterUsuarioDao {

    string cadastrarUsuario(Jogador jogador);

    string autenticarUsuario(Jogador jogador);

    Jogador setIdJogadorPorNickname(string nickname);


}
