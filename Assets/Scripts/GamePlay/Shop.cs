using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ShopAnimation))]
public class Shop : MonoBehaviour
{
    [SerializeField] private Button _clicker;
    private ShopAnimation _shopAnimation;
    private bool _isShopPanelOpen = false;

    private void Start()
    {
        _shopAnimation = GetComponent<ShopAnimation>();
    }

    public void ShopButtonClick()
    {
        if (_isShopPanelOpen == false)
            _shopAnimation.OpenShop();
        else
            _shopAnimation.CloseShop();

        _isShopPanelOpen = !_isShopPanelOpen;
        _clicker.enabled = !_isShopPanelOpen;
    }

}
