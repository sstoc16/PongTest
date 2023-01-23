using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void GoBall()// After resetting the ball redirects it in a  random Direction so that it isnt the same everytime
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb.AddForce(new Vector2(30, -5));
        }
        else
        {
            rb.AddForce(new Vector2(-30, -5));
        }
    }

    void ResetBall() 
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }
   public void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))// Redirects velocity on contact with paddle to make sure that the ball does not slowly loose speed 
        {
            source.Play();
            Vector2 vel;
            vel.x = rb.velocity.x;
            vel.y = (rb.velocity.y / 1) + (coll.collider.attachedRigidbody.velocity.y / 1);
            rb.velocity = vel;
        }
    }

}
