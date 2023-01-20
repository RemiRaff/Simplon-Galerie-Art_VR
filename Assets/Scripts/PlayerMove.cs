using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float speedMove = 50f;

    private CharacterController _charControl;
    // private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        _charControl = GetComponent<CharacterController>();
        // _camera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMove(InputValue value)
    {
        // Debug.Log("key pressed");
        _charControl.Move(speedMove * Time.deltaTime * new Vector3(value.Get<Vector2>().x, 0, value.Get<Vector2>().y));
        // transform.position = speedMove * Time.deltaTime * new Vector3(value.Get<Vector2>().x, 0, value.Get<Vector2>().y);
    }
}
