using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private UpgraderData _upgraderData;
    [SerializeField] private StatsData _statsData;
    [SerializeField] private StatsModel _statsModel;

    public override void InstallBindings()
    {
        Container.Bind<StatsData>()
                 .FromInstance(_statsData)
                 .AsSingle();

        Container.Bind<StatsModel>()
                 .FromInstance(_statsModel)
                 .AsSingle();

        Container.Bind<UpgraderData>()
                 .FromInstance(_upgraderData)
                 .AsSingle();

        Container.BindInterfacesAndSelfTo<JsonSaveSystem>()
                 .AsSingle();
    }
}
