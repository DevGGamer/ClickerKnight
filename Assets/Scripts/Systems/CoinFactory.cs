using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CoinFactory : MonoBehaviour
{
    [SerializeField] private CoinAnimation _coinPrefab;
    [SerializeField] private Transform _coinsContainer;

    private StatsController _statsController;
    private Queue<CoinAnimation> _coinsPool = new Queue<CoinAnimation>();

    [Inject]
    private void Construct(StatsController controller)
    {
        _statsController = controller;
    }

    public void SpawnCoin(Vector2 position)
    {
        CoinAnimation coin;

        if (_coinsPool.TryDequeue(out coin))
        {
            coin.gameObject.SetActive(true);
        }
        else
        {
            coin = Instantiate(_coinPrefab, _coinsContainer);
            coin.Init(this, _statsController);
        }

        coin.PlayAnimation();
        RectTransform coinTransform = coin.GetComponent<RectTransform>();
        coinTransform.anchoredPosition = position;
    }

    public void RemoveCoin(CoinAnimation coin)
    {
        _coinsPool.Enqueue(coin);
        coin.gameObject.SetActive(false);
    }
}


