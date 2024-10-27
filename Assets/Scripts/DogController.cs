using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DogController : MonoBehaviour
{
    Rigidbody2D _compRigidbody2D;
    
    [SerializeField]  float timer;
    [SerializeField] float Maxtime;
    [SerializeField] TMP_Text textTime;
    [SerializeField] int vertical;
    [SerializeField] float speed;
    [SerializeField] float Maxspeed;
    [SerializeField] Vector2 positionObjective;
    [SerializeField] float xMin, xMax, yMin, yMax;
    [SerializeField] float currentX, currentY;
    public static event Action DogsSafe;
    public static event Action DogsDanger;
    
    


    private void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
      
    }
    private void Start()
    {
        transform.position = new Vector2(currentX, currentY);
        SetTextTime(timer.ToString());
   
    }

    private void Update()
    {
        currentX = Mathf.Clamp(transform.position.x, xMin, xMax);
        currentY = Mathf.Clamp(transform.position.y, yMin, yMax);
        transform.position = new Vector2(currentX, currentY);
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            vertical = 0;
            SetTextTime(Mathf.FloorToInt(timer).ToString());
        }
        if(timer < 0)
        {
            SetTextTime("0");
            vertical = -1;
        }
        
        
    }



    public Vector2 GetPositionObjective()
    {
        return positionObjective;
    }
    private void FixedUpdate()
    {
        _compRigidbody2D.velocity = new Vector2(0,speed*vertical);  
    }

    private void OnEnable()
    {
        if(tag == "Dog")
        {
            PlayerController.OnLeaveDogSafeZone += FreezeTimer;
            PlayerController.OnTakingDog += ResetTimeDog;
        }
        if(tag == "Dog 2")
        {
            PlayerController.OnLeaveDog2SafeZone += FreezeTimer;
            PlayerController.OnTakingDog2 += ResetTimeDog;
        }
        
    }


    
    private void OnDisable()
    {
        if (tag == "Dog")
        {
            PlayerController.OnLeaveDogSafeZone -= FreezeTimer;
            PlayerController.OnTakingDog -= ResetTimeDog;
        }
        if (tag == "Dog 2")
        {
            PlayerController.OnLeaveDog2SafeZone -= FreezeTimer;
            PlayerController.OnTakingDog2 -= ResetTimeDog;
        }

    }


    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision != null && collision.gameObject.tag == "Safe"  )
        {
            DogsSafe?.Invoke();
            FreezeTimer();
            transform.position = positionObjective;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.tag == "Safe")
        {
            DogsDanger?.Invoke();

        }
    }


    void SetTextTime(string text)
    {
        textTime.text = text;
    }

    void ResetTimeDog()
    {
        timer = Maxtime;
        speed  = Maxspeed;
    }

    void FreezeTimer()
    {
        timer = 0;
        textTime.text = "";
        speed = 0;
    }


}
