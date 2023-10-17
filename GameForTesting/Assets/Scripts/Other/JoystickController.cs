using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    public float dirX, dirY;
    public float speed;
    public Joystick joystick;
    private Rigidbody2D rb;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = joystick.Horizontal * speed;
        dirY = joystick.Vertical * speed;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, dirY);  
    }
}
