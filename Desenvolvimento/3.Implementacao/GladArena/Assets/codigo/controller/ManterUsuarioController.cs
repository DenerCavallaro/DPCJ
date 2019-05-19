using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// Esta classe recebe os dados de usuário da view e os repassada para a dao. Também retorna a autenticação da dao.
// @author: Dener
//

public class ManterUsuarioController : MonoBehaviour, IManterUsuarioController
{
    public string autenticarUsuario(Jogador jogador)
    {
        IManterUsuarioDao manterUsuarioDao = gameObject.AddComponent <ManterUsuarioDao>();
        return manterUsuarioDao.autenticarUsuario(jogador);
    }

    public string cadastrarUsuario(Jogador jogador)
    {
        IManterUsuarioDao manterUsuarioDao = new ManterUsuarioDao();
        return manterUsuarioDao.cadastrarUsuario(jogador);
    }

    public Jogador setIdJogadorPorNickname(string nickname)
    {
        throw new System.NotImplementedException();
    }
}
