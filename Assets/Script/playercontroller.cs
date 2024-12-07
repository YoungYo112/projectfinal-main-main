using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontroller : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 move;
    float moveX;
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;

    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
       
        rb.velocity = new Vector2(moveX * speed * Time.fixedDeltaTime, rb.velocity.y);
        

        if (moveX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); 
        }
        else if (moveX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); 
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(0, jumpSpeed);
        }
       
    }



}
