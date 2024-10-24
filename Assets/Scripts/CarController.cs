using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    Rigidbody2D _compRigidbody;
    [SerializeField] float speed;
    [SerializeField] int direction;

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
    }
}
