using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradersData", menuName = "Save/Upgrader")]
public class UpgraderData : ScriptableObject
{
    public List<UpgraderInfo> upgradeList = new List<UpgraderInfo>();
}
