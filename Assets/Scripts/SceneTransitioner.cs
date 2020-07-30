using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        BoyController Boy = other.gameObject.GetComponent<BoyController>();

        if (Boy != null)
        {
            animator.SetTrigger("Fadeout");
        }
    }


    public void OnFadeComplete()
    {
        int currentscene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentscene + 1);
    }
}
