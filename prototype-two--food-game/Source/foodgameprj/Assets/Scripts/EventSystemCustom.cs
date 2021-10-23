using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent onBoardScoresChanged;
    public UnityEvent onGameOver;

    void Awake()
    {
        onBoardScoresChanged = new UnityEvent();
        onGameOver = new UnityEvent();
    }

    private void Update()
    {
        // Reload Game
        if (Input.GetKey(KeyCode.R) && Input.GetKey(KeyCode.LeftShift))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}