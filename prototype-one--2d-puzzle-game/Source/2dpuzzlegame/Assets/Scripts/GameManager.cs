using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject YouWonPanel;
    public GameObject YouLostPanel;
    
    public void LevelComplete()
    {
        YouWonPanel.SetActive(true);
    }

    public void Lost()
    {
        YouLostPanel.SetActive(true);
    }
}
