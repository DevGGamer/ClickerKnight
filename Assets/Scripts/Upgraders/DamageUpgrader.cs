using UnityEngine;

public class DamageUpgrader : Upgrader
{
    private int _nextStageUpgrader = 5;

    protected override void UpgraderUsed()
    {
        _statsController.IncrementDamage(_nextStageUpgrader);
    }
}
