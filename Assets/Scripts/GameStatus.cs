using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [SerializeField] public int EquipBlueBoosters { get; private set; }
    [SerializeField] public int EquipRedBoosters { get; private set; }

    [SerializeField] public BoolReactiveProperty gameOver = new();

    [SerializeField] public BoolReactiveProperty levelComplete = new();
    void Start()
    {
        
    }

    public void SetLevelComplete() => levelComplete.Value = true;
    public void SetGameOver() => gameOver.Value = true;
    public void PlusBlueBoosters(int count) => EquipBlueBoosters += count;
    public void PlusRedBoosters(int count) => EquipRedBoosters += count;
}
