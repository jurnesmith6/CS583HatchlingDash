using System;
using UnityEngine;

public class TurtlePlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    private Rigidbody2D rbComponent;

    private Vector2 movement;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbComponent = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // get input
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        
        // no backward movement
        if (moveY < 0)
        {
            moveY = 0;
        }

        movement = new Vector2(moveX, moveY).normalized;
    }

    private void FixedUpdate()
    {
        rbComponent.MovePosition(rbComponent.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
