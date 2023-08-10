using ModestTree;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class ChaseCamera : MonoBehaviour
{
    [Inject] GameStatus _gameStatus;
    [SerializeField] Camera _mainCam;
    [SerializeField] Transform _playerTransform;
    [SerializeField] float _offsetCam;

    void Start()
    {
        Observable.EveryUpdate().Subscribe(v => {
            _mainCam.transform.position = new Vector3(_mainCam.transform.position.x,
                     _mainCam.transform.position.y, _playerTransform.transform.position.z - _offsetCam);
                
        }).AddTo(this);
    }
}
