using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class Upgrader : MonoBehaviour
{
    public bool CanBuy => _statsController.HasEnoughCoins(_upgraderInfo.CurrentPrice);
    public bool IsActive => _upgradeButton.interactable;

    [SerializeField] private Text _priceText;
    [SerializeField] private Text _titleText;
    
    private UpgraderInfo _upgraderInfo;
    protected StatsController _statsController;
    private Button _upgradeButton;

    public void Init(UpgraderInfo upgraderInfo, StatsController controller)
    {
        _upgraderInfo = upgraderInfo;
        _statsController = controller;
        _upgradeButton = GetComponent<Button>();

        _priceText.text = _upgraderInfo.CurrentPrice.ToString();
        _titleText.text = _upgraderInfo.Title.ToString();
    }

    public void Buy()
    {
        if (CanBuy == false) 
            return;

        int currentPrice = _upgraderInfo.CurrentPrice;
        _statsController.DecrementCoins(currentPrice);
        _upgraderInfo.SetNewPrice(currentPrice * 2);
        _priceText.text = _upgraderInfo.CurrentPrice.ToString();
        UpgraderUsed();
    }

    public void ActivateUpgrader()
    {
        _upgradeButton.interactable = true;
    }

    public void DisactivateUpgrader()
    {
        _upgradeButton.interactable = false;
    }

    protected abstract void UpgraderUsed();
}
