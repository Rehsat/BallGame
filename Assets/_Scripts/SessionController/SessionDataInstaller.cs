using UnityEngine;
using Zenject;

public class SessionDataInstaller : MonoInstaller
{
    [SerializeField] private SessionData _sessionController;

    public override void InstallBindings()
    {
        Container.Bind<SessionData>().FromInstance(_sessionController).AsSingle();
    }
}
