using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MoveComponent))]
public class JoystickMoveInput : MonoBehaviour
{
    [SerializeField]
    private Joystick joystick;
    public Joystick Joystick => joystick;
    private MoveComponent moveComponent;
    private void Awake()
    {
        moveComponent = GetComponent<MoveComponent>();
    }
    void Update()
    {
        moveComponent.Move(new Vector2(joystick.Horizontal, joystick.Vertical).normalized);
    }
}
