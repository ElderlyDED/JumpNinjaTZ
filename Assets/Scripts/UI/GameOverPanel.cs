using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameOverPanel : MonoBehaviour
{
    [Inject] GameStatus _gameStatus;

    [SerializeField] TextMeshProUGUI _onigiriText;
    [SerializeField] TextMeshProUGUI _wineText;

    void Start()
    {
        _onigiriText.text = "Onigiri: " + _gameStatus.EquipBlueBoosters.ToString();
        _wineText.text = "Wine: " + _gameStatus.EquipRedBoosters.ToString();
    }

    public void OnClickRestartBtn()
    {
        SceneManager.LoadScene(0);
    }

}
