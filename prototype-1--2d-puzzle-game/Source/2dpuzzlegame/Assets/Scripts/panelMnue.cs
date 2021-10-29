using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelMnue : MonoBehaviour
{
    public GameObject pauseMneuUI;
    public GameObject character;
    private bool isPaused;
    public GameObject arrow;
    public GameObject arrow1;
    public GameObject arrow2;
    public GameObject arrow3;
    public int i = 0;
    public bool temp=false;

    public GameObject clones;
    public CloneMove[] cloneMoves;

    public static Vector3 switchChar;
    public static Vector3 moveVec;


    public void start()
    {
        switchChar = GameObject.FindGameObjectWithTag(TagNames.character.ToString()).transform.position;
        moveVec = GameObject.FindGameObjectWithTag(TagNames.character.ToString()).transform.position;
        cloneMoves = clones.GetComponentsInChildren<CloneMove>();
    }
    private void Update()
    {
        if (i == 0)
        {
            moveVec = GameObject.FindGameObjectWithTag(TagNames.character.ToString()).transform.position;
            arrow.SetActive(true);
            arrow1.SetActive(false);
            arrow2.SetActive(false);
            arrow3.SetActive(false);
        }
        else if (i == 1)
        {
            switchChar = GameObject.FindGameObjectWithTag(TagNames.clone.ToString()).transform.position;
            arrow.SetActive(false);
            arrow1.SetActive(true);
            arrow2.SetActive(false);
            arrow3.SetActive(false);
        }
        else if (i == 2)
        {
            switchChar = GameObject.FindGameObjectWithTag(TagNames.clone1.ToString()).transform.position;
            arrow.SetActive(false);
            arrow1.SetActive(false);
            arrow2.SetActive(true);
            arrow3.SetActive(false);
        }
        else
        {
            switchChar = GameObject.FindGameObjectWithTag(TagNames.clone2.ToString()).transform.position;
            arrow.SetActive(false);
            arrow1.SetActive(false);
            arrow2.SetActive(false);
            arrow3.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerMove.pause = !PlayerMove.pause;
        }

        if (PlayerMove.pause==true && Input.GetKeyDown(KeyCode.Space))
        {
            PlayerMove.pause = !PlayerMove.pause;
            character.transform.position = switchChar;
        }

        if (PlayerMove.pause)
        {
            ActivateMenu();
        }

        else{
            DeactivateMenu();

        }

        if (Input.GetKeyDown(KeyCode.D) && PlayerMove.pause)
        {
            if (i < 3)
            {
                i = i + 1;
            }
            else
            {
                i=0;
            }
          
        }

        if (Input.GetKeyDown(KeyCode.A) && PlayerMove.pause)
        {
            if (0<i)
            {
                i = i - 1;
            }
            else
            {
                i = 3;
            }
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
        arrow.SetActive(true);
        arrow1.SetActive(false);
        arrow2.SetActive(false);
        arrow3.SetActive(false);
    }


}
