using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{

    public float factor;
    public float jumpAmount = 0.5f;

    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;

    public Image EnableTeleport;

    public GameObject clones;
    public CloneMove[] cloneMoves;

    private bool canJump;
    private bool isGrounded;

    public EventSystemCustom eventSystem;

    public GameObject TeleportDestination;

    private Vector3 moveVector;
    void Start()
    {
        cloneMoves = clones.GetComponentsInChildren<CloneMove>();

        canJump = true;
        isGrounded = false;
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

        if (Input.GetKeyDown(KeyCode.Space) && canJump && isGrounded)
        {
            rb.AddForce(transform.up * jumpAmount, ForceMode2D.Impulse);
            JumpClones(jumpAmount);
        }
        isGrounded = false;


        // This was added to answer a question.
        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    Destroy(this.gameObject);
        //}


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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.CollectableKey.ToString()))
        {
            if (Input.GetKey(KeyCode.E))
            { 
                collision.gameObject.SetActive(false);
                eventSystem.OnCharacterEatKey.Invoke();
                //Debug.Log("KEY EVENT FIRED!");
            }
        }

        if (collision.gameObject.CompareTag(TagNames.ExitDoor.ToString()))
        {
            if (Input.GetKey(KeyCode.E))
            {
                eventSystem.OnGameEndedWon.Invoke();
                //Debug.Log("YOU WON Event fired!");
            }
        }

        if (collision.gameObject.CompareTag(TagNames.TeleportSource.ToString()))
        {
            if (Input.GetKey(KeyCode.E) && EnableTeleport.enabled)
            {
                spriteRenderer.transform.position = new Vector2(TeleportDestination.transform.position.x, TeleportDestination.transform.position.y);
            }   
        }

        if (collision.gameObject.CompareTag(TagNames.TeleportKey.ToString()))
        {
            if (Input.GetKey(KeyCode.E))
            {
                collision.gameObject.SetActive(false);
                eventSystem.OnCharacterEatTeleportKey.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.DeathZone.ToString()))
        {
            eventSystem.OnGameEndedLost.Invoke();
            this.gameObject.SetActive(false);
            //Debug.Log("YOU LOST Event fired!");
        }

        if (collision.gameObject.CompareTag(TagNames.CollectableItem.ToString()))
        {
            collision.gameObject.SetActive(false);
            //Debug.Log("POTION!");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.StickyPlatform.ToString()))
        {
            //Debug.LogWarning("sticky");
            canJump = false;
        }

        
        //if (collision.gameObject.CompareTag(TagNames.ExitDoor.ToString()))
        //{
        //    Debug.Log("exit door");
        //}



    }

    void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.StickyPlatform.ToString()))
        {
            //Debug.LogWarning("skticky no more bruh");
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
