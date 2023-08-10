using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class MenusSwitcher : MonoBehaviour
{
    [Inject] GameStatus _gameStatus;
    [SerializeField] Transform _gameOverPanel;
    [SerializeField] Transform _levelCompletePanel;
    void Start()
    {
        CheckGameStatus();
    }

    void CheckGameStatus()
    {
        _gameStatus.levelComplete.Where(s => s == true).Subscribe(v => {
            OnLevelCompletePanel();
        }).AddTo(this);
        _gameStatus.gameOver.Where(s => s == true).Subscribe(v => {
            OnGameOverPanel();
        }).AddTo(this);
    }

    void OnGameOverPanel()
    {
        _gameOverPanel.gameObject.SetActive(true);
        _levelCompletePanel.gameObject.SetActive(false);
    }

    void OnLevelCompletePanel()
    {
        _levelCompletePanel.gameObject.SetActive(true);
        _gameOverPanel.gameObject.SetActive(false);
    }
}
