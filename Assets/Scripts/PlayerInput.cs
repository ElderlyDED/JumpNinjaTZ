using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public delegate void LeftRightAction(Vector3 direction);
    public event LeftRightAction leftRightAction;

    void Start()
    {
        Observable.EveryUpdate().Subscribe(_ => {
            if (Input.GetKey(KeyCode.D))
                leftRightAction?.Invoke(Vector3.right);
            else if (Input.GetKey(KeyCode.A))
                leftRightAction?.Invoke(Vector3.left);
            else
                leftRightAction?.Invoke(Vector3.zero);
        }).AddTo(this);
    }

    
}
