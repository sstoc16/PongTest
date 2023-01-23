using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] float ScreenShakeDuration;
    public AnimationCurve curve;
    public bool start;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (start)
        {
            start = false;
            StartCoroutine(Shaking());
           
        }
    }

    // Physically moves camera for screen shake effect 
   public  IEnumerator Shaking()
    {
        Vector3 StartPosition = transform.position;
        float elapsedTime = 0f;
        while (elapsedTime < ScreenShakeDuration)
        {
            elapsedTime+= Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / ScreenShakeDuration);
            transform.position = StartPosition + Random.insideUnitSphere;
            yield return null;
        }
        transform.position = StartPosition;
    }

    public void StartShaking()
    {
        StartCoroutine(Shaking());
    }
}
