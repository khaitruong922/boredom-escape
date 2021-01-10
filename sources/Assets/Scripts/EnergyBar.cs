#pragma warning disable 0649

using UnityEngine;
using UnityEngine.UI;
public class EnergyBar : MonoBehaviour
{
    private Energy energy;
    private Image energyBar;
    private void Awake()
    {
        energyBar = GetComponent<Image>();
    }
    private void Start()
    {
        Player player = Player.Instance;
        if (player == null) return;
        energy = player.GetComponent<Energy>();
        energy.OnEnergyChanged += UpdateEnergyBar;
    }
    private void UpdateEnergyBar()
    {
        if (energy == null) return;
        energyBar.fillAmount = energy.Percentage;

    }
    private void OnDestroy()
    {
        energy.OnEnergyChanged -= UpdateEnergyBar;
    }
}

