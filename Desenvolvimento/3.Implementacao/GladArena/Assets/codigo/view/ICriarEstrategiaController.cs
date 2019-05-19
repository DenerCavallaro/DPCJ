using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICriarEstrategiaController {

    void recuperarFluxogramaPorJogador(Jogador jogador);

    void atualizarFluxograma(Fluxograma fluxograma);

    IEnumerator recuperarOponetes();
}
