using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    float scrollspeed;
    Rigidbody2D rigidbody2D;

    Vector2 backgroundoffset;
    float imagelength;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        scrollspeed = -1f;
        rigidbody2D.velocity = new Vector2(scrollspeed, 0);

        imagelength = 6.3f;
        backgroundoffset = new Vector2(imagelength * 2f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -imagelength)
        {
            RepositionBackground();
        }
    }

    void RepositionBackground()
    {
        transform.position = (Vector2)transform.position + backgroundoffset;
    }
}
