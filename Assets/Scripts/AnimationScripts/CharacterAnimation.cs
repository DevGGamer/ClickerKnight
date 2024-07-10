using DG.Tweening;
using UnityEngine;
using Zenject;

public class CharacterAnimation : MonoBehaviour
{
    [Inject] private CoinFactory _coinFactory;

    public void PlayAnimation()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(0.7f, 0.1f).SetDelay(0.2f).SetEase(Ease.InQuad));
        sequence.Append(transform.DOScale(1, 0.1f).SetEase(Ease.InQuad).OnComplete(OnComplete));
        DOTween.Play(sequence);
    }

    private void OnComplete()
    {
        Vector3 randomPosition = transform.position + new Vector3(Random.Range(-50, 50), Random.Range(-50, 50));
        _coinFactory.SpawnCoin(randomPosition);
    }
}
