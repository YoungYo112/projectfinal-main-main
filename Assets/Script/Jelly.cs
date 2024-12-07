using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : Enemy
{
    [SerializeField] Vector2 velocity;
    [SerializeField] Transform[] movePoints;
    


    private void Start()
    {

        Behavior();
    }

    private void FixedUpdate()
    {
        Behavior();

    }

    private void FlipCharacter()
    {
        Debug.Log("FlipCharacter called");
        velocity *= -1;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.Rotate(0f, 180f, 0f);
        //transform.localScale = scale;

        Debug.Log("localScale: " + transform.localScale);
    }


    public override void Behavior()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        if (rb.position.x <= movePoints[0].position.x && velocity.x < 0)
        {
            Debug.Log("Flipping Left");
            FlipCharacter();
        }
        else if (rb.position.x >= movePoints[1].position.x && velocity.x > 0)
        {
            Debug.Log("Flipping Right");
            FlipCharacter();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Character playerCharacter = collision.gameObject.GetComponent<Character>();
            playerCharacter.TakeDamage(2);

        }
    }
}
