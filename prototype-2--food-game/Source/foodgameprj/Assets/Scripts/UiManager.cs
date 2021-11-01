using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public Text Score;
    public Text Heart;
    public PlayerController playerController;
    public HeartComboController HeartComboController;
    public EventSystemCustom eventSystem;

    // Start is called before the first frame update
    void Start()
    {
        Score.gameObject.SetActive(true);
        Heart.gameObject.SetActive(true);
        eventSystem.UpdatScore.AddListener(UpdateScore);
        eventSystem.UpdateHeart.AddListener(UpdateHeart);
    }

    // Update is called once per frame
    
       public  void UpdateScore()
        {
            Debug.Log("UPDATE KEYS");
            Score.text = "Score : " + playerController.playerScore.ToString();

        }

    public void UpdateHeart()
    {
        Debug.Log("UPDATE Heart");
        Score.text = "Hearts : " + HeartComboController.heart.ToString();

    }

}
