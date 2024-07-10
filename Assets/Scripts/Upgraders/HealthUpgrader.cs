using UnityEngine;

public class HealthUpgrader : Upgrader
{
    private int _nextStageUpgrader = 5;

    protected override void UpgraderUsed()
    {
        _statsController.IncrementHealth(_nextStageUpgrader);
    }
}
