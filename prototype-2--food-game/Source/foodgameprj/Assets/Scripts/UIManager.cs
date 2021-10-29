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

    private void UpdateHealth(int healthChange)
    {
        int currentHealth = int.Parse(this.health.text.Split(':')[1]); 
        

        if (currentHealth + healthChange < 0)
        {
            EventSystemCustom.current.onEndGame.Invoke("You lose!");
            Time.timeScale = 0;
        }
        else
            this.health.text = "Health : " + (currentHealth + healthChange);
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
