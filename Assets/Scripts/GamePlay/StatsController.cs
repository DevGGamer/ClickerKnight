using System;
using UnityEngine;
using Zenject;

public class StatsController : IInitializable
{
    public event Action WalletChanged;

    private StatsView _view;
    private StatsModel _model;

    [Inject]
    private void Construct(StatsModel model, StatsView view)
    {
        _model = model;
        _view = view;
    }

    public void Initialize()
    {
        UpdateAllStats();
    }

    private void UpdateAllStats()
    {
        _view.UpdateCoinsText(_model.Coins);
        _view.UpdateExperienceBar(_model.Experience, _model.MaxExperinece);
        _view.UpdateLevelText(_model.Level);
        _view.UpdateHealthText(_model.Health);
        _view?.UpdateDamageText(_model.Damage);
        _view.UpdateDefenceText(_model.Defence);
    }

    public void IncrementCoins()
    {
        _model.AddCoins(_model.CoinsPerClick);
        _view.UpdateCoinsText(_model.Coins);
        WalletChanged?.Invoke();
    }

    public void IncrementCoins(int amount)
    {
        _model.AddCoins(amount);
        _view.UpdateCoinsText(_model.Coins);
        WalletChanged?.Invoke();
    }

    public void DecrementCoins(int amount)
    {
        _model.ReduceCoins(amount);
        _view.UpdateCoinsText(_model.Coins);
        WalletChanged?.Invoke();
    }

    public bool HasEnoughCoins(int amount)
    {
        return _model.Coins >= amount;
    }

    public void IncrementCoinsPerClick(int amount)
    {
        _model.AddCoinsPerClick(amount);
    }

    public void IncrementExperience(int amount)
    {
        _model.AddExperience(amount);
        _view.UpdateExperienceBar(_model.Experience, _model.MaxExperinece);
        _view.UpdateLevelText(_model.Level);
    }

    public void IncrementHealth(int amount)
    {
        _model.AddHealth(amount);
        _view.UpdateHealthText(_model.Health);
    }

    public void DecrementHealth(int amount)
    {

    }

    public void IncrementDamage(int amount)
    {
        _model.AddDamage(amount);
        _view?.UpdateDamageText(_model.Damage);
    }

    public void IncrementDefence(int amount)
    {
        _model.AddDefence(amount);
        _view.UpdateDefenceText(_model.Defence);
    }
}
