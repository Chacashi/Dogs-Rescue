using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DogController : MonoBehaviour
{
    Rigidbody2D _compRigidbody2D;
    
    [SerializeField]  float timer;
    [SerializeField] TMP_Text textTime;
    [SerializeField] int vertical;
    [SerializeField] float speed;

    public static event Action OnTimeIsUp;


    private void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
      
    }
    private void Start()
    {
        SetTextTime(timer.ToString());
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        SetTextTime(Mathf.FloorToInt(timer).ToString()) ;
        if(timer < 0)
        {
            OnTimeIsUp?.Invoke();
        }
        
    }
    private void FixedUpdate()
    {
        _compRigidbody2D.velocity = new Vector2(0,speed*vertical);  
    }
    void SetTextTime(string text)
    {
        textTime.text = text;
    }
    

}
