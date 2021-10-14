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
    public CloneMove[] cloneMoves;
    public GameObject[] keys; 

    private bool canJump;

    private GameObject keyToDestroy=null;
    public int keyCollectedCount=0;
    private bool WonOrNot=false;
    private bool ReadyToSwitch=false;
    private bool ReadyToTransport=false;
    private GameObject ReadyToCollectTransportKey;
    public bool CollectTransportKey = false;
    public bool Switching=false;
    public EventSystemCustom eventSystem;
    public UiManager WonOrLostText;
    public GameObject arrow;
    public GameObject DestinationDoor;
    public int chooseClone=0;
    public CloneMove chosenClone;
    private Vector3 tempPostion;



    private Vector3 moveVector;
    void Start()
    {
        //cloneMoves = clones.GetComponentsInChildren<CloneMove>();

        canJump = true;
        moveVector = new Vector3(1 * factor, 0, 0);
    }

    void Update()
    {
        cloneMoves = clones.GetComponentsInChildren<CloneMove>();


        if (Switching)
        {

            if (Input.GetKeyDown(KeyCode.D))
            {
                chooseClone += 1;
                chooseClone %= cloneMoves.Length+1;
                this.ArrowChange(chooseClone);

            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                if (chooseClone == 0)
                {
                    chooseClone = cloneMoves.Length;
                }
                else
                {
                    chooseClone -= 1;
                }
                chooseClone %= cloneMoves.Length+1;
                this.ArrowChange(chooseClone);

            }


            if (Input.GetKeyDown(KeyCode.Space))
            {
                Switching = false;
                WonOrLostText.UpdateWonOrLostText("");
                this.SwitchCloneAndCharacter();
            }
        }
        else
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

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (keyToDestroy)
                {
                    Destroy(keyToDestroy);
                    keyCollectedCount += 1;
                    eventSystem.OnKeyCollected.Invoke();
                }
            }

            if (Input.GetKeyDown(KeyCode.E) && WonOrNot)
            {
                if (keyCollectedCount == keys.Length)
                {
                    WonOrLostText.UpdateWonOrLostText("YOU WON");
                    Debug.Log("YOU WON");
                }
            }
            if (Input.GetKeyDown(KeyCode.E) && ReadyToCollectTransportKey)
            {
                CollectTransportKey = true;
                ReadyToCollectTransportKey.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.E) && ReadyToSwitch)
            {
                Switching = true;
                WonOrLostText.UpdateWonOrLostText("Choose the new player among the clones.");
            }

            if (Input.GetKeyDown(KeyCode.E) && ReadyToTransport && CollectTransportKey)
            {
                transform.position = DestinationDoor.transform.position;
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
            WonOrLostText.UpdateWonOrLostText("YOU LOST");
            Debug.Log("DEATH ZONE");
        }
        
        if (collision.gameObject.CompareTag(TagNames.CollectableItem.ToString()))
        {
            collision.gameObject.SetActive(false);
            Debug.Log("POTION!");
        }

        if (collision.gameObject.CompareTag(TagNames.key.ToString()))
        {
            keyToDestroy = collision.gameObject;
            
        }
        if (collision.gameObject.CompareTag(TagNames.transportKey.ToString()))
        {
            ReadyToCollectTransportKey = collision.gameObject;

        }
        if (collision.gameObject.CompareTag(TagNames.Switch.ToString()))
        {
            ReadyToSwitch = true;

        }
        if (collision.gameObject.CompareTag(TagNames.EnterTransportDoor.ToString()))
        {
            ReadyToTransport = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.key.ToString()))
        {
            keyToDestroy = null;

        }
        if (collision.gameObject.CompareTag(TagNames.transportKey.ToString()))
        {
            ReadyToCollectTransportKey = null;

        }

        if (collision.gameObject.CompareTag(TagNames.Switch.ToString()))
        {
            ReadyToSwitch = false;

        }
        if (collision.gameObject.CompareTag(TagNames.EnterTransportDoor.ToString()))
        {
            ReadyToTransport = false;

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
            WonOrNot = true;
        }

       

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.StickyPlatform.ToString()))
        {
            Debug.LogWarning("sticky no more bruh");
            canJump = true;
        }

        if (collision.gameObject.CompareTag(TagNames.ExitDoor.ToString()))
        {
            Debug.Log("exit door");
            WonOrNot = false;
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
    public void ArrowChange(int index)
    {
        if (index == 0)
        {
            foreach (var c in cloneMoves)
                c.arrowActive=false;
            arrow.SetActive(true);
            chosenClone = null;
        }
        else
        {
            arrow.SetActive(false);
            foreach (var c in cloneMoves)
                if (c == cloneMoves[index - 1])
                {
                    c.arrowActive = true;
                    chosenClone = c;
                }
                else
                {
                    c.arrowActive = false;
                }
        }
    }

    public void SwitchCloneAndCharacter()
    {
        if (chosenClone)
        {
            tempPostion = transform.position;
            transform.position = chosenClone.position;
            chosenClone.SwitchCloneAndCharacter(tempPostion);
            foreach (var c in cloneMoves)
                c.arrowActive = false;
            arrow.SetActive(true);
            chosenClone = null;
        }
        
    }
}
