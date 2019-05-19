using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGerarEstrategiaDao {

    IEnumerator RecuperarEstatisticaPorNickname(string nickname);

    IEnumerator atualizarEstatisticas(Jogador jogador, Dano dano1, Dano dano2);
}
