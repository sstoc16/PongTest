using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PaddleControls : MonoBehaviour
{
    [Header ("Controls")]
    [SerializeField] public KeyCode moveUpButton = KeyCode.W;
    [SerializeField] public KeyCode moveDownButton = KeyCode.S;
    [SerializeField] public KeyCode PowerUpButton1 = KeyCode.Space;
    [SerializeField] public KeyCode PowerUpButton2 = KeyCode.RightControl;
    [SerializeField] public float paddeSpeed = 10.0f;

   
    public RawImage PowerUpReady, PowerUp2Ready;

    public GameObject ExtendedPaddle;
    [Header ("Activated Abilities")]
    public bool SpeedUpPowerUp;
    public bool PaddleGrowPowerUp;
    

    [SerializeField] public float powerUpCharges;
    public Animator Player;
    public TMP_Text powerUpChargesTxt;
    

    float boundY = 4f;
    private Rigidbody2D rb;
    private Rigidbody2D BallRB;
    private GameObject Ball;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Ball = GameObject.FindGameObjectWithTag("Ball");
        BallRB = Ball.GetComponent<Rigidbody2D>();
        ExtendedPaddle.SetActive(false);
      

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        AbilityActivate();
        powerUpChargesTxt.text = "Power Up Charges: "+ powerUpCharges.ToString();

    }
    private void Movement()
    {
        var vel = rb.velocity;
        if (Input.GetKey(moveUpButton))
        {
            vel.y = paddeSpeed;
        }
        else if (Input.GetKey(moveDownButton))
        {
            vel.y = -paddeSpeed;
        }
        else
        {
            vel.y = 0;
        }
        rb.velocity = vel;
        var pos = transform.position; //sets limit on paddle y axis so that it stays within the limits of the area 
        if (pos.y > boundY)
        {
            pos.y = boundY;
        }
        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
        }
        transform.position = pos;
    }

    private void AbilityActivate()
    {
        if (powerUpCharges > 0)
        {
            if (Input.GetKeyDown(PowerUpButton1) && SpeedUpPowerUp == true)
            {

                //   PowerUpReady.SetActive(false);

                BallRB.AddForce(BallRB.velocity * 2.5f);
                Player.SetTrigger("PowerUp");

                powerUpCharges--;
                powerUpChargesTxt.text = powerUpCharges.ToString();

                Debug.Log("Speed");

            }
            if (Input.GetKey(PowerUpButton2) && PaddleGrowPowerUp == true)
            {
                StartCoroutine(ExtendedPowerUp());
                //PowerUpReady.SetActive(false);
                powerUpCharges--;
                powerUpChargesTxt.text = powerUpCharges.ToString();
            }
        }
        else {
        PowerUpReady.color= Color.grey;
            PowerUp2Ready.color = Color.grey;
        }

    }

    public IEnumerator ExtendedPowerUp()
    {
        float PowerUpTime = 4;
        float elapsedTime = 0f;

        {
            while (elapsedTime < PowerUpTime)
            {
                {

                    elapsedTime += Time.deltaTime;
                    ExtendedPaddle.SetActive(true);
                    boundY = 2; // changes the limit on the paddle to account for the paddles increased size 
                    yield return null;
                }
            }
            ExtendedPaddle.SetActive(false);
            boundY = 4;
        }

    }
    public void FreezeBall()
    {
     
       

        
    }
  
}
