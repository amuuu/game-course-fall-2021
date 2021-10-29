using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    [SerializeField] Text health;
    [SerializeField] Text score;
    [SerializeField] Text endGame;
    // [SerializeField] EventSystemCustom eventSystemCustom;
    
    // Start is called before the first frame update
    void Start()
    {
        
        EventSystemCustom.current.onEndGame.AddListener(UpdateEndGame);
        EventSystemCustom.current.onHealthChange.AddListener(UpdateHealth);
        EventSystemCustom.current.onScoreChange.AddListener(UpdateScore);
        
        
    }

    private void UpdateHealth(int health)
    {
        this.health.text = "Health : " + health.ToString();
    }
    private void UpdateScore(int score)
    {
        this.score.text = "Score : " + score.ToString();
    }
    private void UpdateEndGame(string text)
    {
        this.endGame.text = text;
    }
}
