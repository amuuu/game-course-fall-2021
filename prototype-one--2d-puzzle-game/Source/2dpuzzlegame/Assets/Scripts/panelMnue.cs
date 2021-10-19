using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelMnue : MonoBehaviour
{
    public GameObject pauseMneuUI;
    private bool isPaused;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerMove.pause = !PlayerMove.pause;
        }

        if (PlayerMove.pause==true && Input.GetKeyDown(KeyCode.Space))
        {
            PlayerMove.pause = !PlayerMove.pause;
        }

        if (PlayerMove.pause)
        {
            ActivateMenu();
        }

        else{
            DeactivateMenu();
        }
    }

    public void ActivateMenu()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        pauseMneuUI.SetActive(true);
    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseMneuUI.SetActive(false);
        PlayerMove.pause = false;
    }

}
