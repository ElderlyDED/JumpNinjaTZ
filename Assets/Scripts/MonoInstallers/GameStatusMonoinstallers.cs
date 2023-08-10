using UnityEngine;
using Zenject;

public class GameStatusMonoinstallers : MonoInstaller
{
    [SerializeField] GameStatus _gameStatus;
    public override void InstallBindings()
    {
        Container.Bind<GameStatus>().FromInstance(_gameStatus).AsTransient().NonLazy();
    }
}