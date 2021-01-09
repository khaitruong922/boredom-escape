#pragma warning disable 0649

using UnityEngine;
using System;

[RequireComponent(typeof(MoveComponent))]
public class Energy : MonoBehaviour
{
    public Action OnEnergyChanged = delegate { };
    [SerializeField]
    private float maxEnergy = 100;
    [SerializeField]
    private float drainRate = 2;
    private MoveComponent moveComponent;
    private float currentEnergy;
    private void Awake()
    {
        currentEnergy = maxEnergy;
        moveComponent = GetComponent<MoveComponent>();
    }
    private void Update()
    {
        ModifyEnergy(-drainRate * Time.deltaTime);
        moveComponent.Multiplier = Percentage;
    }
    public void ModifyEnergy(float amount)
    {
        currentEnergy += amount;
        ClampEnergy();
        OnEnergyChanged?.Invoke();
    }
    private void ClampEnergy()
    {
        currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);
    }
    public float Percentage => currentEnergy / maxEnergy;
    public bool IsFull => currentEnergy == maxEnergy;

}

