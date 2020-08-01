using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelchanger : MonoBehaviour
{
    public static int currentscene;
    public static int prevscene = -1;
    Animator animator;


    public virtual void Start()
    {

        animator = GetComponent<Animator>();

        currentscene = SceneManager.GetActiveScene().buildIndex;

    }

    public void LoadPrevScene()
    {
        prevscene = currentscene;
        currentscene -= 1;
        SceneManager.LoadScene(currentscene);
    }

    public void LoadNextScene()
    {
        prevscene = currentscene;
        currentscene += 1;
        SceneManager.LoadScene(currentscene);
    }

}
