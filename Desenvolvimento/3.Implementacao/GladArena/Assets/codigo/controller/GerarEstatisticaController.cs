using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// Esta classe recebe os dados estatíticos da view e repassa para a dao. Também repassa os dados da dao para a view
// @author: Dener
//

public class GerarEstatisticaController : MonoBehaviour, IGerarEstatisticaController {

    //
    // inicia o método de atualizar estatísticas da dao
    // @return <Uma espera do resultado do método de recuperar da dao>
    // @param <jogador> <Objeto do tipo jogador>
    // @param <dano1> <Objeto dano do tipo "gladiador">
    // @param <dano2> <Objeto dano do tipo "leao">
    // @exception <não há exceções> 
    //
    public IEnumerator atualizarEstatisticas(Jogador jogador, Dano dano1, Dano dano2)
    {
        IGerarEstrategiaDao gerarEstatiscaDao = gameObject.AddComponent<GerarEstrategiaDao>();
        yield return StartCoroutine(gerarEstatiscaDao.atualizarEstatisticas(jogador, dano1,dano2));
    }

    //
    // recebe um nickname e retorna as estatísticas deste jogador
    // @return <Uma espera do resultado do método de recuperar da dao>
    // @param <nickname> <string com o nickname do jogador>
    // @exception <não há exceções> 
    //
    public IEnumerator RecuperarEstatisticaPorNickname(string nickname)
    {
        IGerarEstrategiaDao gerarEstatiscaDao = gameObject.AddComponent<GerarEstrategiaDao>();
        yield return StartCoroutine(gerarEstatiscaDao.RecuperarEstatisticaPorNickname(nickname));
    }
}
