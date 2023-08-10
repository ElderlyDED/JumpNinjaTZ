using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class PlusSpeed : MonoBehaviour, IBusted
{
    [Inject] GameStatus _gameStatus;
    [SerializeField] float _plusSpeedValue;
    [SerializeField] ParticleSystem _equipEffect;
    public void GetEffect(MoveUnit moveUnit)
    {
        moveUnit.PlusForwardSpeed(_plusSpeedValue);
        _gameStatus.PlusBlueBoosters(1);
        _equipEffect.Play();
        Destroy(gameObject, 0.2f);
    }
}
