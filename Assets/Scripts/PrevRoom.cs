﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PrevRoom : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.name == "FishBoy")
        {
            animator.SetTrigger("GoBack");
        }
    }


}
