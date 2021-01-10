using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    private Player player;
    private AudioSource audioSource;
    public static Action OnDefeat { get; set; }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = Player.Instance;
        player.Health.OnDead += Defeat;
    }
    private void Defeat()
    {
        audioSource.Play();
        OnDefeat?.Invoke();
    }
    private void OnDestroy()
    {
        player.Health.OnDead -= Defeat;
    }
}
