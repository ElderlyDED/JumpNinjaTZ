using UnityEngine;
using Zenject;

public class PlayerInputInsaller : MonoInstaller
{
    [SerializeField] PlayerInput _playerInput;
    public override void InstallBindings()
    {
        Container.Bind<PlayerInput>().FromInstance(_playerInput).AsTransient().NonLazy();
    }
}