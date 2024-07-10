using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [Header("Coin Factory")]
    [SerializeField] private CoinFactory _coinFactory;

    [Header("Stats")]
    [SerializeField] private StatsView _statsView;

    [Header("Clicker")]
    [SerializeField] private ClickButton _clickButton;
    [SerializeField] private CharacterView _characterView;

    [Header("Shop")]
    [SerializeField] private ShopPage[] _shopPages;

    public override void InstallBindings()
    {
        Container.Bind<StatsView>()
                 .FromInstance(_statsView)
                 .AsSingle();

        Container.BindInterfacesAndSelfTo<StatsController>()
                 .AsSingle()
                 .NonLazy();

        Container.Bind<ClickButton>()
                 .FromInstance(_clickButton)
                 .AsSingle(); ;

        Container.Bind<CharacterView>()
                 .FromInstance(_characterView)
                 .AsSingle();

        Container.Bind<CoinFactory>()
                 .FromInstance(_coinFactory)
                 .NonLazy();

        Container.BindInterfacesAndSelfTo<ButtonClickObserver>()
                 .AsSingle()
                 .NonLazy();

        foreach (ShopPage page in _shopPages)
        {
            Container.Bind<ShopPage>()
                     .FromInstance(page)
                     .AsCached();
        }

        Container.BindInterfacesAndSelfTo<WallelChangedObserver>()
                 .AsSingle()
                 .NonLazy();
    }
}
