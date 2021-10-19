using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    public float factor = 0.01f;
    public float jumpAmount = 0.5f;

    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;

    public GameObject clones;
    public GameObject keyObj;
    public GameObject TeleportKeyObj;
    public GameObject SourceDoorObj;
    //public GameObject DestinationDoorObj;
    public CloneMove[] cloneMoves;

    private bool canJump;

    private Vector3 moveVector;
    private Vector3 DestinationDoorPosition;
    public EventSystemCustom eventSystem;

    public UiManager uiManager;

    private bool isWin = false;
    private bool TeleportKey = false;
    
    public int keyNumToWin = 2;
    
    void Start()
    {
        cloneMoves = clones.GetComponentsInChildren<CloneMove>();

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

        if (Input.GetKey(KeyCode.E))
        {
            if (keyObj)
            {
                keyObj.SetActive(false);
                eventSystem.KeyNum.Invoke();
                keyObj = null;
            }
            else if (isWin)
            {
                Debug.Log("WIN");
                uiManager.statusText.text = "You Won!";
            }
            else if (TeleportKeyObj)
            {
                TeleportKeyObj.SetActive(false);
                TeleportKeyObj = null;
                Debug.Log("TELEPORT KEY");
                TeleportKey = true;
            }
            else if (TeleportKey && SourceDoorObj)
            {
                DestinationDoorPosition = GameObject.FindGameObjectsWithTag("DestinationDoor")[0].transform.position;
                transform.position = DestinationDoorPosition;
                SourceDoorObj = null;
            }
        }


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
            Debug.Log("DEATH ZONE");
            uiManager.statusText.text = "You lost!";
        }
        
        if (collision.gameObject.CompareTag(TagNames.CollectableItem.ToString()))
        {
            collision.gameObject.SetActive(false);
            Debug.Log("POTION!");
        }

        if (collision.gameObject.CompareTag(TagNames.key.ToString()))
        {
            keyObj = collision.gameObject;
        }

        if (collision.gameObject.CompareTag(TagNames.TeleportKey.ToString()))
        {
            TeleportKeyObj = collision.gameObject;
        }
        
        if (collision.gameObject.CompareTag(TagNames.Door.ToString()))
        {
            //Debug.Log(uiManager.keyNumberText.text.ToString());

            if (int.Parse(uiManager.keyNumberText.text) == keyNumToWin)
            {
                isWin = true;
            }
        }

        if (collision.gameObject.CompareTag(TagNames.SourceDoor.ToString()))
        {
            SourceDoorObj = collision.gameObject;   
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.key.ToString()))
        {
            keyObj = null;
        }
        if (collision.gameObject.CompareTag(TagNames.TeleportKey.ToString()))
        {
            TeleportKeyObj = null;
        }
        if (int.Parse(uiManager.keyNumberText.text) == keyNumToWin)
        {
            isWin = false;
        }
        if (collision.gameObject.CompareTag(TagNames.SourceDoor.ToString()))
        {
            SourceDoorObj = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.StickyPlatform.ToString()))
        {
            Debug.LogWarning("sticky");
            canJump = false;
        }

        if (collision.gameObject.CompareTag(TagNames.ExitDoor.ToString()))
        {
            Debug.Log("exit door");
        } 
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
}
