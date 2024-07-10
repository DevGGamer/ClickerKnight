using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class ShopAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform _shopButton;
    [SerializeField] private RectTransform _battleButton;
    [SerializeField] private Transform _characterTransform;
    private RectTransform _shopPanelRect;

    private void Start()
    {
        _shopPanelRect = GetComponent<RectTransform>();
    }

    public void OpenShop()
    {
        _battleButton.DOAnchorPos(new Vector2(-1050f, 407), 0.6f).SetEase(Ease.OutBack);
        _shopPanelRect.DOAnchorPos(new Vector2(11, 687), 1f).SetEase(Ease.OutBounce).SetDelay(0.3f);
        _shopButton.DOAnchorPos(new Vector2(0, 600), 0.6f).SetEase(Ease.OutBounce).SetDelay(0.4f);
        _shopButton.DOScale(0.8f, 0.6f).SetEase(Ease.OutBack).SetDelay(0.4f);
        _characterTransform.DOMoveY(2.2f, 0.5f).SetEase(Ease.OutBounce).SetDelay(0.3f);
        _characterTransform.DOScale(0.7f, 0.5f).SetEase(Ease.OutBounce).SetDelay(0.3f);
    }

    public void CloseShop()
    {
        _shopPanelRect.DOAnchorPos(new Vector2(11, -820), 0.6f).SetEase(Ease.OutBounce);
        _shopButton.DOAnchorPos(new Vector2(0, 960), 0.6f).SetEase(Ease.OutBounce).SetDelay(0.2f);
        _shopButton.DOScale(1f, 0.6f).SetEase(Ease.OutBack).SetDelay(0.1f);
        _characterTransform.DOMoveY(-0.779f, 0.5f).SetEase(Ease.OutBounce);
        _characterTransform.DOScale(1f, 0.5f).SetEase(Ease.OutBounce);
        _battleButton.DOAnchorPos(new Vector2(10.5f, 407), 0.8f).SetEase(Ease.OutBack).SetDelay(0.3f);
    }
}
