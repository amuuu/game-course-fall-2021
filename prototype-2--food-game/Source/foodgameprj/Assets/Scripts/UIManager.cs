using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text Score;
    public Text Heart;
    public int playerHeartsCount;
    public EventSystemCustom eventSystem;

    void Start()
    {
        playerHeartsCount = 3;
        //Heart.text = FindObjectOfType<PlayerController>().playerHeartsCount.ToString();
        Heart.text = playerHeartsCount.ToString();
        eventSystem.onGetFood.AddListener(UpdateScoreText);
        eventSystem.onGetHeart.AddListener(UpdateHeartText);
    }

    public void UpdateScoreText()
    {
        Score.text = FindObjectOfType<PlayerController>().playerScore.ToString();
    }

    public void UpdateHeartText()
    {
        Heart.text = playerHeartsCount.ToString();
    }
}
