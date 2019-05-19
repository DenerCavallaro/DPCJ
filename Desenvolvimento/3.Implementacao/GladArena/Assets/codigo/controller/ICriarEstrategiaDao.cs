using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ICriarEstrategiaDao{

    IEnumerator recuperarFluxogramaPorJogador(Jogador jogador);

    IEnumerator atualizarFluxograma(Fluxograma fluxograma);

    IEnumerator recuperarOponentes();
}
