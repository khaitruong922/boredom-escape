#pragma warning disable 0649

using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    private Health health;
    private Image healthBar;
    private void Awake()
    {
        healthBar = GetComponent<Image>();
    }
    private void Start()
    {
        Player player = Player.Instance;
        if (player == null) return;
        health = player.GetComponent<Health>();
        health.OnHealthChanged += UpdateHealthBar;
    }
    private void UpdateHealthBar()
    {
        if (health == null) return;
        healthBar.fillAmount = health.Percentage;

    }
    private void OnDestroy()
    {
        health.OnHealthChanged -= UpdateHealthBar;
    }
}

