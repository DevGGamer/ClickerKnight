using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class StatsView : MonoBehaviour
{
    [SerializeField] private Text _coinsText;
    [SerializeField] private Text _levelText;
    [SerializeField] private Text _healthText;
    [SerializeField] private Text _damageText;
    [SerializeField] private Text _defenceText;
    [SerializeField] private Image _experienceBar;

    public void UpdateCoinsText(int coins)
    {
        _coinsText.text = coins.ToString();
    }

    public void UpdateExperienceBar(int currentExperience, int maxExperience)
    {
        _experienceBar.DOFillAmount(1f * currentExperience / maxExperience, 0.5f);
    }

    public void UpdateLevelText(int level)
    {
        _levelText.text = $"Level {level}";
    }

    public void UpdateHealthText(int health)
    {
        _healthText.text = health.ToString();
    }

    public void UpdateDamageText(int damage)
    {
        _damageText.text = damage.ToString();
    }

    public void UpdateDefenceText(int defence)
    {
        _defenceText.text = defence.ToString();
    }
}
