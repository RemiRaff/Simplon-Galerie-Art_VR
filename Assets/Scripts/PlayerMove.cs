using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float walkSpeed = 20f;

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
        Vector3 playerVelocity = new Vector3(_moveInput.x, 0, _moveInput.y);
        // Vector3 move = transform.right * x + transform.forward * z;  // tranform.* use local direction

        // rigid.body.velocity ok but velocity just get for a CharController
        // SimpleMove in Unity forum, dont works in this case
        _charControl.Move(transform.TransformDirection(playerVelocity) * Time.deltaTime * walkSpeed);
    }

    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }
}
