using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

public class MoveUnit : MonoBehaviour
{
    private CompositeDisposable _disposable = new();
    [Inject] PlayerInput _playerInput;
    [Inject] GameStatus _gameStatus;
    [SerializeField] float _sideSpeed;
    [SerializeField] FloatReactiveProperty _forwardSpeed = new ();
    [SerializeField] Collider _tirgger;
    void Start()
    {
        ForwardMove();
        CheckBustersTrigger();
        CheckForwardSpeed();
        CheckLevelCompleteCollider();
    }

    void OnEnable() => _playerInput.leftRightAction += LeftRightMove;

    void OnDisable() => _playerInput.leftRightAction -= LeftRightMove;

    void CheckForwardSpeed() => _forwardSpeed.Where(s => s <= 0).Subscribe(v => {
        _gameStatus.SetGameOver();
        _forwardSpeed.Value = 0f;
    }).AddTo(this);

    void LeftRightMove(Vector3 dir)
    {
        transform.Translate(dir * Time.deltaTime * _sideSpeed);
    }

    void ForwardMove() => Observable.EveryFixedUpdate().Subscribe(_ => {
        transform.Translate(Vector3.forward * Time.deltaTime * _forwardSpeed.Value);
    }).AddTo(_disposable);

    void CheckBustersTrigger() => _tirgger.OnTriggerEnterAsObservable().Where(t => t.tag == "Buster")
        .Subscribe(v => {
            v.TryGetComponent(out IBusted iBusted);
            gameObject.TryGetComponent(out MoveUnit moveUnit);
            iBusted.GetEffect(moveUnit);
        }).AddTo(this);

    void CheckLevelCompleteCollider() => _tirgger.OnTriggerEnterAsObservable().Where(t => t.tag == "LvlComplete")
        .Subscribe(v => {
            _gameStatus.SetLevelComplete();
        }).AddTo(this);

    #region effects

    public void PlusForwardSpeed(float _plusSpeedValue) => _forwardSpeed.Value += _plusSpeedValue;

    public void MinusForwardSpeed(float _minusSpeedValue) => _forwardSpeed.Value -= _minusSpeedValue;

    #endregion
}
