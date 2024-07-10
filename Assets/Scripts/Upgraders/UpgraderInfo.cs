using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrader Config", menuName = "Upgrader/Create New Upgrader Info"), Serializable]
public class UpgraderInfo : ScriptableObject
{
    [TextArea] public string Title;
    public int CurrentPrice = 100;

    public void SetNewPrice(int price)
    {
        if (price < 0)
            return;

        CurrentPrice = price;
    }
}
