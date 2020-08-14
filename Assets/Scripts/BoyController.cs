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

    bool firsthit;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        //set speed
        speed = 2f;

        firsthit = true;
    }

    // Update is called once per frame
    void Update()
    {
        //boy movement
        //only happens if firsthit, i.e. boy has NOT opened minigame
        if (firsthit)
        {
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
        }
        //boy movement

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
                    ManageRelatedScene(2);
                    break;

            }
            
        }
        //raycasting
    }

    //loads/unloads the scene requested by FishBoy
    private void ManageRelatedScene(int scene)
    {
        if (firsthit)
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Additive);
            firsthit = false;
        }
        else
        {
            SceneManager.UnloadSceneAsync(scene);
            firsthit = true;
        }
    }

    private void FixedUpdate()
    {
        if (firsthit)
        {
            Vector2 pos = rigidbody2D.position;

            pos.x += speed * DHorizontal * Time.deltaTime;
            pos.y += speed * DVertical * Time.deltaTime;

            rigidbody2D.position = pos;
        }
    }


}
