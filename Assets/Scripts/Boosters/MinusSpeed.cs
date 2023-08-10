using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MinusSpeed : MonoBehaviour, IBusted
{
    [Inject] GameStatus _gameStatus;
    [SerializeField] float _minusSpeedValue;
    [SerializeField] ParticleSystem _equipEffect;
    public void GetEffect(MoveUnit moveUnit)
    {
        _equipEffect.Play();
        _gameStatus.PlusRedBoosters(1);
        moveUnit.MinusForwardSpeed(_minusSpeedValue);
        Destroy(gameObject, 0.2f);
    }
}
