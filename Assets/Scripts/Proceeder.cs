using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Proceeder : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.collider.gameObject.name == "FishBoy")
        {
            animator.SetTrigger("Proceed");
        }
    }

    
}
