using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    

    public void MainToStage1()
    {
        Debug.Log("asdf");
        SceneManager.LoadScene(1);
    }
}
