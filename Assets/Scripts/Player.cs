#pragma warning disable 0649

using UnityEngine;
using System.Collections.Generic;
using System;

public class Player : MonoBehaviour
{
    private Health health;
    public Health Health => health;
    public static Player Instance { get; set; }
    [SerializeField]
    private void Awake()
    {
        SingletonSetup();
        health = GetComponent<Health>();
    }
    private void SingletonSetup()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }
}

