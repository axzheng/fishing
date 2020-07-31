using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelchanger : MonoBehaviour
{
    public void LoadPrevScene()
    {
        int currentscene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentscene - 1);
    }

    public void LoadNextScene()
    {
        int currentscene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentscene + 1);
    }
}
