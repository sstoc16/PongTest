using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isPlayerOneGoal;
    public AudioSource audioSource;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            audioSource.Play();
            if(!isPlayerOneGoal)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().PlayerOneScored();
            }
            else
            {
                
                
                    GameObject.Find("GameManager").GetComponent<GameManager>().PlayerTwoScored();
                
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
