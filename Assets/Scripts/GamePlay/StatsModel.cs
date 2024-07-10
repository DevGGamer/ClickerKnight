using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Create Stats Info"), Serializable]
public class StatsModel : ScriptableObject
{
    public int Coins => _coins;
    public int CoinsPerClick => _coinsPerClick;
    public int Experience => _experience;
    public int Level => _level;
    public int MaxExperinece => _maxExperience;
    public int Health => _health;
    public int Damage => _damage;
    public int Defence => _defence;

    [SerializeField] private int _maxExperience = 1000;
    [SerializeField] private int _health = 10;
    [SerializeField] private int _damage = 10;
    [SerializeField] private int _defence = 5;
    [SerializeField] private int _coins = 0;
    [SerializeField] private int _coinsPerClick = 1;
    [SerializeField] private int _experience = 0;
    [SerializeField] private int _level = 1;

    public void AddCoins(int amount)
    {
        if (amount <= 0)
            return;

        _coins += amount;
    }

    public void ReduceCoins(int amount)
    {
        if (amount <= 0)
            return;

        if (_coins < amount)
            _coins = 0;
        else
            _coins -= amount;
    }

    public void AddCoinsPerClick(int amount) 
    {
        if (amount <= 0)
            return;

        _coinsPerClick += amount;
    }

    public void AddExperience(int amount)
    {
        if (amount <= 0)
            return;

        _experience += amount;
        if (_experience >= _maxExperience)
        {
            int multiplier = _experience / _maxExperience;
            _experience -= _maxExperience * multiplier;
            AddLevel(multiplier);
        }
    }

    private void AddLevel(int amount)
    {
        if (amount <= 0)
            return;

        _level += amount;
    }

    public void AddDefence(int amount)
    {
        if (amount <= 0)
            return;

        _defence += amount;
    }

    public void AddHealth(int amount)
    {
        if (amount <= 0)
            return;

        _health += amount;
    }

    public void AddDamage(int amount)
    {
        if (amount <= 0)
            return;

        _damage += amount;
    }
}
