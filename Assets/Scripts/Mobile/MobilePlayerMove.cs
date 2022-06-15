using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlayerMove : MonoBehaviour
{
    public MovementJoystick movementJoystick;

    public float playerSpeed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(movementJoystick.JoystickVec.y != 0)
        {
            rb.velocity = new Vector2(movementJoystick.JoystickVec.x * playerSpeed, movementJoystick.JoystickVec.y * playerSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
