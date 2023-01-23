using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float walkSpeed = 0.05f;

    private Vector2 _moveInput;
    private CharacterController _charControl;

    // Start is called before the first frame update
    void Start()
    {
        _charControl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    private void Run()
    {
        // _charControl.velocity.y => 0 in the vector3 because we want to stay on ground
        Vector3 playerVelocity = new Vector3(_moveInput.x * walkSpeed, 0, _moveInput.y * walkSpeed);

        // rigid.body.velocity ok but velocity just get for a CharController
        // SimpleMove in Unity forum, dont works in this case
        _charControl.Move(transform.TransformDirection(playerVelocity));
    }

    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }
}
