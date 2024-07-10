using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent (typeof(RectTransform))]
public class ShopPage : MonoBehaviour
{
    public UpgraderInfo[] UpgraderInfos => _upgraderInfos;

    [SerializeField] private Upgrader _upgraderPrefab;
    [SerializeField] private Transform _upgradersContainer;
    [SerializeField] private UpgraderInfo[] _upgraderInfos;

    private RectTransform _rectTransform;
    private StatsController _statsController;
    private List<Upgrader> _upgradersList = new();

    [Inject]
    private void Construct(StatsController controller)
    {
        _statsController = controller;
    }

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        ClosePage();
    }

    private void Start()
    {
        SpawnUpgraders();
    }

    private void SpawnUpgraders()
    {
        for (int i = 0; i < _upgraderInfos.Length; i++)
        {
            Upgrader upgrader = Instantiate(_upgraderPrefab, _upgradersContainer);
            upgrader.Init(_upgraderInfos[i], _statsController);
            _upgradersList.Add(upgrader);
        }

        UpdateUpgraders();
    }

    public void UpdateUpgraders()
    {
        foreach (Upgrader upgrader in _upgradersList)
        {
            if (upgrader.IsActive && upgrader.CanBuy)
                continue;

            if (!upgrader.IsActive && !upgrader.CanBuy)
                continue;

            if (upgrader.CanBuy)
                upgrader.ActivateUpgrader();
            else
                upgrader.DisactivateUpgrader();
        }
    }

    public void OpenPage()
    {
        _rectTransform.DOScale(1f, 0.5f).SetDelay(0.1f);
    }

    public void ClosePage()
    {
        _rectTransform.DOScale(0f, 0.5f);
    }
}
