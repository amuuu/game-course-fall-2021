using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public EventSystemCustom eventSystem;
    public Text heartCounterText, scoreCounterText;
    public PlayerController mainCharacter;

    void Start()
    {
        UnityEngine.Events.UnityAction UpdateScoreText = () => scoreCounterText.text = "Score count: " + mainCharacter.playerScore.ToString(); ;
       
        eventSystem.OnHeartDecreaseUIUpdate.AddListener(UpdateNumberOfHeartsText);
        eventSystem.OnScoreUpdate.AddListener(UpdateScoreText);
    }

    private void UpdateNumberOfHeartsText()
    {
        int newTextValue = int.Parse(Regex.Match(heartCounterText.text, @"\d+").Value) - 1;
        heartCounterText.text = "Hearts count: " + newTextValue.ToString();
    }
}
