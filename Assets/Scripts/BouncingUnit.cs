using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

public class BouncingUnit : MonoBehaviour
{
    [Inject] GameStatus _gameStatus;

    private CompositeDisposable _disposable = new();

    [SerializeField] List<Rigidbody> _rbs = new();
    [SerializeField] Rigidbody _mainRb;
    [SerializeField] float _jumpForce;
    [SerializeField] Collider _trigger;
    [SerializeField] Vector3 _dir;

    void Start()
    {
        AutoJump();
    }

    void AutoJump() => _trigger.OnTriggerEnterAsObservable().Where(t => t.tag == "floor").Subscribe(_ => {
        Debug.Log("enter floor");
        foreach (Rigidbody rb in _rbs)
        {
            rb.velocity = Vector3.zero;
        }
        Jump();
    }).AddTo(_disposable);

    void Jump()
    {
        if(_gameStatus.gameOver.Value == false)
            _mainRb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    } 

}
