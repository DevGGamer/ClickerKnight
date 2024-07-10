using UnityEngine;

public class CoinsUpgrader : Upgrader
{
    private int _nextStageUpgrader = 1;

    protected override void UpgraderUsed()
    {
        _statsController.IncrementCoinsPerClick(_nextStageUpgrader);
    }
}
