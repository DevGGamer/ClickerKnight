using DG.Tweening;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(RectTransform))]
public class CoinAnimation : MonoBehaviour
{
    [SerializeField] private float _delay;
    private CoinFactory _coinFactory;
    private RectTransform _coinRectTransform;
    private StatsController _statsController;

    private void Awake()
    {
        _coinRectTransform = GetComponent<RectTransform>();
    }

    public void Init(CoinFactory coinFactory, StatsController statsController)
    {
        _coinFactory = coinFactory;
        _statsController = statsController;
    }

    public void PlayAnimation()
    {
        _coinRectTransform.DOScale(1f, 0.3f).SetDelay(_delay).SetEase(Ease.OutBack);
        _coinRectTransform.DOAnchorPos(new Vector2(-350, 550), 1.3f).SetDelay(_delay + 0.1f);
        _coinRectTransform.DORotate(Vector3.zero, 0.5f).SetDelay(_delay + 0.1f);
        _coinRectTransform.DOScale(0.5f, 1.3f).SetDelay(_delay + 0.1f).SetEase(Ease.OutBack).OnComplete(AnimationEnded);
    }

    private void AnimationEnded()
    {
        _coinFactory.RemoveCoin(this);
        _statsController.IncrementCoins();
        _statsController.IncrementExperience(5);
    }
}
