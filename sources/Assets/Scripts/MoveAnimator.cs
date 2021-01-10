using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(JoystickMoveInput), typeof(Animator))]
public class MoveAnimator : MonoBehaviour
{
    private JoystickMoveInput joystickMoveInput;
    private Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        joystickMoveInput = GetComponent<JoystickMoveInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(joystickMoveInput.Joystick.Horizontal, joystickMoveInput.Joystick.Vertical);
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }
}
