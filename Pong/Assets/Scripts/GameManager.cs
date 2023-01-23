using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
    public GameObject ball;
   
    [Header("Player One")]
    public GameObject PlayerOnePaddle;
    public GameObject PlayerOneGoal;
    public Animator PlayerOne;
   
    [Header("Player Two")]
    public GameObject PlayerTwoPaddle;
    public GameObject PlayerTwoGoal;
    public Animator PlayerTwo;

    [Header("Ui")]
    public Slider PlayerOneHealth;
    public GameObject PlayerTwoText;
    public Slider PlayerTwoHealth;
    public ScreenShake screenShake;
    public GameObject GameOverScreen;
    public TMP_Text Winner;
    

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerOneScored()
    {
      
        PlayerTwoHealth.value--;
        PlayerTwo.SetTrigger("Hit");
        screenShake.StartShaking();
        if (PlayerTwoHealth.value > 0)
        {
            Reset();

        }
        else {
            Winner.text = "Player One Wins!";
            GameOver();
        }
       

    }

    public void PlayerTwoScored()
    {
  
        PlayerOneHealth.value--;
        PlayerOne.SetTrigger("Hit");
        screenShake.StartShaking();


        if (PlayerOneHealth.value > 0)
        {
            Reset();

        }
        else
        {
            Winner.text = "Player Two Wins!";
            GameOver();

        }


    }


    public void Reset()
    {

        PowerUPReset();
        ball.GetComponent<BallControl>().RestartGame();

    }

    public void PowerUPReset()
    {
        PaddleControls PowerUpReset = PlayerOnePaddle.GetComponent<PaddleControls>();
        PowerUpReset.powerUpCharges = 2;
        PowerUpReset.PowerUpReady.color= Color.white;
        PowerUpReset.PowerUp2Ready.color = Color.white;
        PaddleControls PowersUpReset = PlayerTwoPaddle.GetComponent<PaddleControls>();
        PowersUpReset.powerUpCharges = 2;
        PowersUpReset.PowerUpReady.color = Color.white;
        PowersUpReset.PowerUp2Ready.color = Color.white;

    }
    public void GameOver()
    {
        GameOverScreen.SetActive(true);
    }
}
