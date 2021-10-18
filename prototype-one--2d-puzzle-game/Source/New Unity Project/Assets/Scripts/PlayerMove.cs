using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float factor = 0.01f;
    public float jumpAmount = 0.5f;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    public GameObject clones;
    public GameObject[] listOfKeys;
    public CloneMove[] cloneMoves;
    public EventSystemCustom eventSystem;
    public Text keyCollectedText;
    public GameObject winDoor;
    private bool canJump;
    private Vector3 moveVector;
    private bool canCollectKey;
    private bool canWin;
    void Start()
    {
        cloneMoves = clones.GetComponentsInChildren<CloneMove>();
        canCollectKey = false;
        canWin = false;
        canJump = true;
        moveVector = new Vector3(1 * factor, 0, 0);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += moveVector;

            MoveClones(moveVector, true);

            spriteRenderer.flipX = false;

        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= moveVector;

            MoveClones(moveVector, false);

            spriteRenderer.flipX = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(transform.up * jumpAmount, ForceMode2D.Impulse);
            JumpClones(jumpAmount);
        }


        // This was added to answer a question.
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Destroy(this.gameObject);
        }
        
        // if (Input.GetKeyDown(KeyCode.E) && canCollectKey)
        // {
        //     isNearKey();
        // }
        
        isNearKey();
        isNeardoor();



        // This is too dirty. We must decalare/calculate the bounds in another way. 
        /*if (transform.position.x < -0.55f) 
        {
            transform.position = new Vector3(0.51f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > 0.53f)
        {
            transform.position = new Vector3(-0.53f, transform.position.y, transform.position.z);
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.DeathZone.ToString()))
        {
            eventSystem.OnPlayerLoose.Invoke();
            Debug.Log("DEATH ZONE");
            Destroy(this);
        }
        
        if (collision.gameObject.CompareTag(TagNames.CollectableItem.ToString()))
        {
            collision.gameObject.SetActive(false);
            Debug.Log("POTION!");
        }
        
        // if (collision.gameObject.CompareTag(TagNames.keyItem.ToString()) && canCollectKey && Input.GetKey(KeyCode.E))
        // {
        //     collision.gameObject.SetActive(false);
        //     Debug.Log("Key");
        // }
        
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //     Debug.Log("Key");
        if (collision.gameObject.CompareTag(TagNames.keyItem.ToString()) && canCollectKey && Input.GetKey(KeyCode.E))
        {
            collision.gameObject.SetActive(false);
            Debug.Log("Key collected");
            eventSystem.OnKeyCollected.Invoke();
        }
        if (collision.gameObject.CompareTag(TagNames.winDoor.ToString()) && canWin && Input.GetKey(KeyCode.E))
        {
            Debug.Log("exit door");
            eventSystem.OnPlayerWin.Invoke();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.StickyPlatform.ToString()))
        {
            Debug.LogWarning("sticky");
            canJump = false;
        }

        // if (collision.gameObject.CompareTag(TagNames.ExitDoor.ToString()) && canWin && Input.GetKey(KeyCode.E))
        // {
        //     Debug.Log("exit door");
        // }

       

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.StickyPlatform.ToString()))
        {
            Debug.LogWarning("sticky no more bruh");
            canJump = true;
        }
    }

    public void MoveClones(Vector3 vec, bool isDirRight)
    {
        foreach (var c in cloneMoves)
            c.Move(vec, isDirRight);
    }

    public void JumpClones(float amount)
    {
        foreach (var c in cloneMoves)
            c.Jump(amount);
    }

    public void isNearKey()
    {
        bool isNear = false;
        foreach (var k in listOfKeys)
        {
            if (k.GetComponent<Renderer>().enabled == true)
            {
                isNear = k.GetComponent<keyScript>().isNearPlayer(transform);
                if (isNear == true)
                {
                    break;
                }
            }
        }
        // Debug.Log(isNear);
        canCollectKey = isNear;
    }

    public void isNeardoor()
    {
        bool isNear = false;
        float distance = Vector3.Distance(transform.position, winDoor.GetComponent<Transform>().position);
        if (distance <= 0.2)
        {
            isNear = true;
        }
        else
        {
            isNear = false;
        }
        // Debug.Log(isNear);
        // Debug.Log(int.Parse(keyCollectedText.text));

        if (int.Parse(keyCollectedText.text) >= 3 && isNear)
        {
            canWin = true;
        }
        else
        {
            canWin = false;
        }
        // Debug.Log(canWin);
    }
}
