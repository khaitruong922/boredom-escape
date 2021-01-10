using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameManager : MonoBehaviour
{
    private Player player;
    public static Action OnDefeat { get; set; }
    private void Start()
    {
        player = Player.Instance;
        player.Health.OnDead += Defeat;
    }
    private void Defeat()
    {
        OnDefeat?.Invoke();
    }
    private void OnDestroy()
    {
        player.Health.OnDead -= Defeat;
    }
}
