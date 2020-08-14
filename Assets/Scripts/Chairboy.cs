using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chairboy : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    float horizontal;
    float vertical;
    Vector2 DPos;

    float speed;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        speed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        DPos = new Vector2(horizontal, vertical);

        rigidbody2D.AddForce(DPos * speed);
        
    }
}
