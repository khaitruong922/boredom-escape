#pragma warning disable 0649

using UnityEngine;

public class PlayerFinder : MonoBehaviour
{
    private Player player;
    private void Start()
    {
        player = Player.Instance;
    }
    public Vector2 TargetDirection => (TargetPosition - transform.position).normalized;
    public Vector3 TargetPosition => player.transform.position;
    public float Distance => Vector2.Distance(TargetPosition, transform.position);

}

