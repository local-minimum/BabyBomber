using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField]
    string nextScene;

    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(nextScene);
    }
}
