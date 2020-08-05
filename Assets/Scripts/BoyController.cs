using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BoyController : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    Animator animator;

    float DHorizontal;
    float DVertical;
    float speed;

    public Vector2 lookDirection = new Vector2(0, -1);

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        //set speed
        speed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        //boy movement
        
            
        DHorizontal = Input.GetAxis("Horizontal");
        DVertical = Input.GetAxis("Vertical");

        Vector2 DPos = new Vector2(DHorizontal, DVertical);
        if (!Mathf.Approximately(DPos.x, 0f) || !Mathf.Approximately(DPos.y, 0f))
        {
            lookDirection = DPos;
            lookDirection.Normalize();
        }

        animator.SetFloat("MoveX", lookDirection.x);
        animator.SetFloat("MoveY", lookDirection.y);
        animator.SetFloat("Speed", DPos.magnitude);


        //raycasting
        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2D.position + Vector2.up * 0.5f,
                lookDirection, 1f, LayerMask.GetMask("Interactive", "Interactive Back"));

            if (hit.collider != null)
            {
                Debug.Log("Raycast has hit the object " + hit.collider.gameObject);
            }
            switch (hit.collider.gameObject.name)
            {
                case "chair":
                    SceneManager.LoadScene(2, LoadSceneMode.Additive);
                    break;
                case "desk":
                    SceneManager.UnloadSceneAsync(2);
                    break;

            }
            //raycasting
        }

    }

    private void FixedUpdate()
    {
        Vector2 pos = rigidbody2D.position;

        pos.x += speed * DHorizontal * Time.deltaTime;
        pos.y += speed * DVertical * Time.deltaTime;

        rigidbody2D.position = pos;
    }


}
