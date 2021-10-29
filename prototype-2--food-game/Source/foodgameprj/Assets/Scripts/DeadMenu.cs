using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeadMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreText;
    void Update()
    {
        scoreText.text= GameObject.Find("Player").GetComponent<PlayerController>().getScoreCount().ToString();
    }
    public void Click_Restart()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex));
    }

    public void Click_Exit()
    {
        Application.Quit();
    }
}
