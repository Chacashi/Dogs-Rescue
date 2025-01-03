using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CarController : MonoBehaviour
{
    Rigidbody2D _compRigidbody;
    [SerializeField] float speed;
    [SerializeField] int direction;
    public static event Action OnDestroyDog;
    private void Awake()
    {
        _compRigidbody = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        _compRigidbody.velocity = new Vector2(speed * direction, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision!=null && collision.gameObject.tag== "Wall")
        {
            Destroy(gameObject);
        }
        if (collision!= null && (collision.gameObject.tag == "Dog" || collision.gameObject.tag == "Dog 2"))
        {
            Destroy(collision.gameObject);
            OnDestroyDog?.Invoke();
        }


    }


}
