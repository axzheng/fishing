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

    Vector2 lookDirection = new Vector2(0, -1);

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        speed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        DHorizontal = Input.GetAxis("Horizontal");
        DVertical = Input.GetAxis("Vertical");

        Vector2 DPos = new Vector2(DHorizontal, DVertical);
        if(!Mathf.Approximately(DPos.x, 0f) || !Mathf.Approximately(DPos.y, 0f))
        {
            lookDirection = DPos;
            lookDirection.Normalize();
        }

        animator.SetFloat("MoveX", lookDirection.x);
        animator.SetFloat("MoveY", lookDirection.y);
        animator.SetFloat("Speed", DPos.magnitude);

        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2D.position + Vector2.up * 0.5f,
                lookDirection, 1f, LayerMask.GetMask("Interactive", "Interactive Back"));

            if (hit.collider != null)
            {
                Debug.Log("Raycast has hit the object " + hit.collider.gameObject);
            }

        }

        //loads next scene
        if(rigidbody2D.position.y < -4.5f)
        {
            LoadNextScene();
        }
    }

    private static void LoadNextScene()
    {
        int currentscene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentscene + 1);
    }

    private void FixedUpdate()
    {
        Vector2 pos = rigidbody2D.position;

        pos.x += speed * DHorizontal * Time.deltaTime;
        pos.y += speed * DVertical * Time.deltaTime;

        rigidbody2D.position = pos;
    }
}
