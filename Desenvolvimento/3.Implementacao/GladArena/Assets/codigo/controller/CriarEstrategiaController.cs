//
// Esta classe recebe as ações por eventos da view (através de objetos do tipo fluxograma e jogador) 
//e repassa para a dao. Também é responsável por retornar as ações.
// @author: Dener
//


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriarEstrategiaController : MonoBehaviour, ICriarEstrategiaController {

    //
    // recebe um obejto do tipo fluxograma da view e repassa para a dao
    // @return <Uma espera do resultado do método de atualizar da dao>
    // @param <fluxograma> <objeto do tipo fluxograma>
    // @exception <não há exceções> 
    //
    public void atualizarFluxograma(Fluxograma fluxograma)
    {
        ICriarEstrategiaDao criarEstrategiaDao = gameObject.AddComponent<CriarEstrategiaDao>();
        StartCoroutine(criarEstrategiaDao.atualizarFluxograma(fluxograma));
    }

    //
    // recebe um obejto do tipo jogador da view e repassa para a dao para recuperar o fluxograma deste jogador
    // @return <Uma espera do resultado do método de recuperar da dao>
    // @param <jogador> <objeto do tipo jogador>
    // @exception <não há exceções> 
    //
    public void recuperarFluxogramaPorJogador(Jogador jogador)
    {
        
        ICriarEstrategiaDao criarEstrategiaDao = gameObject.AddComponent<CriarEstrategiaDao>();
        StartCoroutine(criarEstrategiaDao.recuperarFluxogramaPorJogador(jogador));
        
    }

    //
    // inicia o método de recuperar oponentes da dao
    // @return <Uma espera do resultado do método de recuperar da dao>
    // @param <não há> <>
    // @exception <não há exceções> 
    //
    public IEnumerator recuperarOponetes()
    {
        ICriarEstrategiaDao criarEstrategiaDao = gameObject.AddComponent<CriarEstrategiaDao>();
        yield return StartCoroutine(criarEstrategiaDao.recuperarOponentes());
    }
}
