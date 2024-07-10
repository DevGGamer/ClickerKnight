using System;
using Zenject;

public class WallelChangedObserver : IInitializable, IDisposable
{
    private StatsController _controller;
    private ShopPage[] _shopPages;

    [Inject]
    private void Construct(StatsController controller, ShopPage[] shopPages)
    {
        _shopPages = shopPages;
        _controller = controller;
    }

    public void Initialize()
    {
        _controller.WalletChanged += OnWalletChanged;
    }

    public void Dispose()
    {
        _controller.WalletChanged -= OnWalletChanged;
    }

    private void OnWalletChanged()
    {
        foreach (ShopPage page in _shopPages)
        {
            page.UpdateUpgraders();
        }
    }
}
