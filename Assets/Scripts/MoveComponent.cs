#pragma warning disable 0649

using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class MoveComponent : MonoBehaviour
{
    [SerializeField]
    private float baseSpeed = 2f;
    [SerializeField]
    private float scaleSpeed = 8f;
    private float multiplier = 1f;
    public float Multiplier { get => multiplier; set => multiplier = value; }
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Move(Vector2 direction)
    {
        rb.velocity = direction * (baseSpeed + scaleSpeed * multiplier);
    }
}

