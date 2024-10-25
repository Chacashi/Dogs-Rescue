using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _compRigidbody2D;

    float horizontal;
    float vertical;
    Vector2 position;
    [SerializeField] float currentX , currentY ;
    bool IsTake = false;
    [SerializeField] float xMin , xMax , yMin , yMax ;
    GameObject objetDog;
    bool IsTaking = false;
    public static event Action OnDestroyPlayer;
    public static event Action OnSafeDogs;
   [SerializeField] float speed;
    int numberSafes = 0;





    private void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
       
        currentX = Mathf.Clamp(transform.position.x, xMin, xMax);
        currentY = Mathf.Clamp(transform.position.y, yMin, yMax);
        transform.position = new Vector2(currentX , currentY);
    }


    public void  AxisY  (InputAction.CallbackContext context)
    {
        if(horizontal == 0)
        {
            vertical = context.ReadValue<float>();
        }

        if (vertical < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipY = false;
        }
        
    }

    public void AxisX (InputAction.CallbackContext context) 
    {
        if (vertical == 0)
        {
            horizontal = context.ReadValue<float>();
        }
        
    
    }

    public void LetterZ(InputAction.CallbackContext context)
    {

        IsTake = context.performed;
    }

    public void LetterX(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if(objetDog != null) { 
            objetDog.transform.SetParent(null);
            IsTaking = false;
                objetDog.gameObject.SetActive(true);

            }
        }
    }

    private void FixedUpdate()
    {
        _compRigidbody2D.velocity = new Vector2(horizontal * speed, vertical * speed);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {


        if (collision != null && collision.gameObject.tag == "Dog" && IsTake ==true && IsTaking ==false)
        {
            IsTaking = true;
            objetDog = collision.gameObject;


            
            objetDog.transform.SetParent(transform);
            objetDog.transform.position = transform.position;

            objetDog.gameObject.SetActive(false);

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.tag == "Car")
        {
            Destroy(gameObject);
            OnDestroyPlayer?.Invoke();
        }

        if (collision != null && collision.gameObject.tag == "Safe" && IsTaking == true)
        {
            numberSafes++;
            if(numberSafes >=2 ) {
            OnSafeDogs?.Invoke();
                 }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision != null && collision.gameObject.tag=="Safe" && IsTaking ==true)
        {
            numberSafes--;
        }
    }

    


}
