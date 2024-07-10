using UnityEngine;

public class DefenceUpgrader : Upgrader
{
    private int _nextStageUpgrader = 5;

    protected override void UpgraderUsed()
    {
        _statsController.IncrementDefence(_nextStageUpgrader);
    }
}
