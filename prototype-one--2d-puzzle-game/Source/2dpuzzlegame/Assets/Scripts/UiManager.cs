using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text counterText;
    public Text keyCounter;
    public EventSystemCustom eventSystem;
    public GameObject winPanel;
    public GameObject losePanel;
    private bool inCharacterSwitchingState;
    public GameObject clones;

    private List<GameObject> characterAndClones;
    private int characterSelected;
    public GameObject chooseCharacterText;

    void Start()
    {
        eventSystem.OnCloneStickyPlatformEnter.AddListener(UpdateScoreText);
        eventSystem.onCollectKey.AddListener(UpdateKeyCounter);
        characterAndClones = new List<GameObject>();
        toggleSwitchingState(false);
    }

    private void toggleSwitchingState(bool inState)
    {
        inCharacterSwitchingState = inState;
        chooseCharacterText.SetActive(inState);
    }

    private void Update()
    {
        if (inCharacterSwitchingState)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                GameObject arrow = characterAndClones[characterSelected].transform.GetChild(0).gameObject;
                arrow.SetActive(false);
                if (--characterSelected < 0)
                    characterSelected = characterAndClones.Count - 1;
                arrow = characterAndClones[characterSelected].transform.GetChild(0).gameObject;
                arrow.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                GameObject arrow = characterAndClones[characterSelected].transform.GetChild(0).gameObject;
                arrow.SetActive(false);
                if (++characterSelected == characterAndClones.Count)
                    characterSelected = 0;
                arrow = characterAndClones[characterSelected].transform.GetChild(0).gameObject;
                arrow.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (characterAndClones[characterSelected].GetComponent<PlayerMove>() != null)
                {
                    FindObjectOfType<PlayerMove>().GetComponent<MonoBehaviour>().enabled = true;
                    toggleSwitchingState(false);
                    return;
                }
                PlayerMove characterMove = FindObjectOfType<PlayerMove>();
                PlayerMove newCharacterMove = characterAndClones[characterSelected].AddComponent<PlayerMove>();
                CloneMove cloneMove = characterAndClones[characterSelected].GetComponent<CloneMove>();
                CloneMove newCloneMove = characterMove.gameObject.AddComponent<CloneMove>();

                System.Reflection.FieldInfo[] fields = characterMove.GetType().GetFields();
                foreach (System.Reflection.FieldInfo field in fields)
                {
                    field.SetValue(newCharacterMove.GetComponent(characterMove.GetType()), field.GetValue(characterMove));
                }
                newCharacterMove.spriteRenderer = cloneMove.spriteRenderer;
                newCharacterMove.rb = cloneMove.rb;
                SpriteRenderer cloneRenderer = newCharacterMove.GetComponent<SpriteRenderer>();
                Color cloneColor = cloneRenderer.color;
                cloneRenderer.color = characterMove.GetComponent<SpriteRenderer>().color;
                newCharacterMove.GetAnimator();

                fields = cloneMove.GetType().GetFields();
                foreach (System.Reflection.FieldInfo field in fields)
                {
                    field.SetValue(newCloneMove.GetComponent(cloneMove.GetType()), field.GetValue(cloneMove));
                }
                newCloneMove.spriteRenderer = characterMove.spriteRenderer;
                newCloneMove.rb = characterMove.rb;
                newCloneMove.GetComponent<SpriteRenderer>().color = cloneColor;
                newCloneMove.GetAnimator();

                Destroy(cloneMove);
                Destroy(characterMove);

                toggleSwitchingState(false);
            }
        }
    }

    public void UpdateKeyCounter(int count)
    {
        Debug.Log("UPDATE KEYS");
        keyCounter.text = count.ToString();
    }

    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        int newTextValue = int.Parse(counterText.text) + 1;
            counterText.text = newTextValue.ToString();
    }

    public void WinScene()
    {
        winPanel.SetActive(true);
        FindObjectOfType<PlayerMove>().GetComponent<MonoBehaviour>().enabled = false;
    }

    public void GameOver()
    {
        losePanel.SetActive(true);
        FindObjectOfType<PlayerMove>().GetComponent<MonoBehaviour>().enabled = false;
    }

    public void CharacterSwitchingState()
    {
        PlayerMove character = FindObjectOfType<PlayerMove>();
        characterAndClones.Add(character.gameObject);
        foreach (CloneMove script in clones.GetComponentsInChildren<CloneMove>())
        {
            characterAndClones.Add(script.gameObject);
        }
        FindObjectOfType<PlayerMove>().GetComponent<MonoBehaviour>().enabled = false;
        characterSelected = 0;

        toggleSwitchingState(true);
    }

}
