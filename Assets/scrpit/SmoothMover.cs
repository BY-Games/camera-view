using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SmoothMover : MonoBehaviour
{
    [Tooltip("Step size in meters")][SerializeField] float speed = 1f;

    [SerializeField]
    InputAction moveUp = new InputAction(type: InputActionType.Button);

    [SerializeField]
    InputAction moveDown = new InputAction(type: InputActionType.Button);


    [SerializeField]
    InputAction moveRight = new InputAction(type: InputActionType.Button);

    [SerializeField]
    InputAction moveLeft = new InputAction(type: InputActionType.Button);

    [SerializeField]
    [Tooltip("Move the player to the location of 'moveToLocation'")]
    InputAction moveTo = new InputAction(type: InputActionType.Button);

    [SerializeField]
    InputAction moveToLocation = new InputAction(type: InputActionType.Value, expectedControlType: "Vector2");
    // Start is called before the first frame update

    // Update is called once per frame

    void OnEnable()
    {
        moveUp.Enable();
        moveDown.Enable();
        moveTo.Enable();
        moveToLocation.Enable();
        moveRight.Enable();
        moveLeft.Enable();
    }

    void OnDisable()
    {
        moveUp.Disable();
        moveDown.Disable();
        moveTo.Disable();
        moveToLocation.Disable();
        moveRight.Disable();
        moveLeft.Disable();
    }
    void Update()
    {
        if (moveUp.IsPressed())
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
        else if (moveDown.IsPressed())
        {
            transform.position += new Vector3(0, -Time.deltaTime * speed, 0);
        }
        else if (moveRight.IsPressed())
        {
            transform.position += new Vector3(Time.deltaTime* speed, 0, 0);

        }
        else if (moveLeft.IsPressed())
        {
            transform.position += new Vector3(-Time.deltaTime * speed, 0, 0);
        }
        else if (moveTo.IsPressed())
        {
            Vector2 mousePositionInScreenCoordinates = moveToLocation.ReadValue<Vector2>();
            Vector3 mousePositionInWorldCoordinates = Camera.main.ScreenToWorldPoint(mousePositionInScreenCoordinates);
            // The z coordinate does not matter because we are dealing with 2D view, set it to the default.
            mousePositionInWorldCoordinates.z = transform.position.z;
            transform.position = mousePositionInWorldCoordinates;
        }
    }
}
