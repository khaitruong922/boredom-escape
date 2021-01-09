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
        print(player);
        if (player == null) return;
        health = player.GetComponent<Health>();
        print(health);
        health.OnHealthChanged += UpdateHealthBar;
    }
    private void UpdateHealthBar()
    {
        if (health == null) return;
        healthBar.fillAmount = health.Percentage;

    }
}

