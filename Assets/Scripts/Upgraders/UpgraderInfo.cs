using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrader Config", menuName = "Upgrader/Create New Upgrader Info"), Serializable]
public class UpgraderInfo : ScriptableObject
{
    public int CurrentPrice => _currentPrice;
    public string Title => _title;

    [SerializeField, TextArea] private string _title;
    [SerializeField] private int _currentPrice;

    public void SetNewPrice(int price)
    {
        if (price < 0)
            return;

        _currentPrice = price;
    }
}
