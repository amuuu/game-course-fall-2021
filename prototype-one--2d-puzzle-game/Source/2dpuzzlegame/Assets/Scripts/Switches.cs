using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switches : MonoBehaviour
{
    public GameObject clones;
    public PlayerMove player;
    public CloneMove[] cloneMoves;
    public List<GameObject> player_clones;
    public int id;
    private PlayerMove oldp;
    private PlayerMove newp;
    private CloneMove oldc;
    private CloneMove newc;
    private Tuple<Color, Color> colors;
    // Start is called before the first frame update
    void Start()
    {
        id = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<PlayerMove>().letsswitch)
        {
            
            cloneMoves = FindObjectsOfType<CloneMove>();
            GameObject pArrow = player_clones[id].transform.GetChild(0).gameObject;
            if (Input.GetKeyDown(KeyCode.A))
            {
                
                pArrow.SetActive(false);
                if (--id<0)
                {
                    id = player_clones.Count - 1;
                }
                pArrow = player_clones[id].transform.GetChild(0).gameObject;
                pArrow.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                pArrow.SetActive(false);
                if (++id == player_clones.Count)
                {
                    id = 0;
                }
                pArrow = player_clones[id].transform.GetChild(0).gameObject;
                pArrow.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                bool finished = false;
                while (true)
                {
                    if (finished)
                    {
                        FindObjectOfType<PlayerMove>().GetComponent<MonoBehaviour>().enabled = true;
                        FindObjectOfType<UiManager>().switchpc.enabled = false;
                        FindObjectOfType<PlayerMove>().letsswitch = false;
                        finished = false;
                        return;
                    }

                    ChangeCharacter();
                    finished = true;
                }
            }
        }
    }

    private void Sets(bool choose,bool death)
    {
        
        if (choose)
        {
            if(death)
                Destroy(oldp);
            else 
            {
                System.Reflection.FieldInfo[] RF = oldp.GetType().GetFields();
                foreach (System.Reflection.FieldInfo f in RF)
                {
                    f.SetValue(newp.GetComponent(oldp.GetType()), f.GetValue(oldp));
                }
            }
        }
        else
        {
            if (death)
                Destroy(oldc);
            else
            {
                System.Reflection.FieldInfo[] RF = oldc.GetType().GetFields();
                foreach (System.Reflection.FieldInfo f in RF)
                {
                    f.SetValue(newc.GetComponent(oldc.GetType()), f.GetValue(oldc));
                }
            }
        }
        
    }

    private void Create()
    {
        oldp = FindObjectOfType<PlayerMove>();
        newp = player_clones[id].AddComponent<PlayerMove>();
        oldc = player_clones[id].GetComponent<CloneMove>();
        newc = oldp.gameObject.AddComponent<CloneMove>();
        colors = Tuple.Create(newp.GetComponent<SpriteRenderer>().color, oldp.GetComponent<SpriteRenderer>().color);
    }
    private void ChangeCharacter()
    {
        if (FindObjectOfType<PlayerMove>().gameObject.name == player_clones[id].name)
        {
            player_clones[id].GetComponent<MonoBehaviour>().enabled = true;
            return;
        }
        Create();

        Sets(true, false);
        newp.spriteRenderer = oldc.spriteRenderer;
        newp.GetComponent<SpriteRenderer>().color = colors.Item2;
        newp.rb = oldc.rb;
        newp.animator = newp.GetComponent<Animator>();

        Sets(false, false);
        newc.spriteRenderer = oldp.spriteRenderer;
        newc.GetComponent<SpriteRenderer>().color = colors.Item1;
        newc.rb = oldp.rb;
        newc.animator = newc.GetComponent<Animator>();

        Sets(true, true);
        Sets(false, true);
    }
    public void GetID()
    {
        id = 0;
    }
    public void GetPlayerAndClones()
    {
        player = FindObjectOfType<PlayerMove>();
        cloneMoves = FindObjectsOfType<CloneMove>();
        player_clones.Add(player.gameObject);
        foreach (CloneMove cl in FindObjectsOfType<CloneMove>())
        {
            player_clones.Add(cl.gameObject);
        }
    }
}
