using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public EventSystemCustom eventSystem;
    public float factor = 0.01f;
    public float jumpAmount = 0.5f;
    public int collectedKeys = 0;

    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;

    public GameObject clones;
    public CloneMove[] cloneMoves;

    private bool canJump;
    public bool canEnd = false;
    private GameObject onKey;
    private GameObject onDoor;
    private Vector3 moveVector;
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

        if (Input.GetKeyDown((KeyCode.E)))
        {
            
            if (onKey != null && canEnd == false)
            {
                collectedKeys++;
                if(eventSystem != null)
                    eventSystem.onCloneKeyCounterEnter.Invoke();
                Destroy(this.onKey);
                // onKey.SetActive(false);
            }
            
            if (onDoor != null && canEnd)
            {
                Debug.Log("YOU WON! My friend");
                if(eventSystem != null)
                    eventSystem.onCloneExitDoorEnter.Invoke();
                // Destroy(this.onDoor);
                // onKey.SetActive(false);
            }
            
            if (collectedKeys == 4)
            {
                canEnd = true;
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
            if (eventSystem != null)
            {
                Time.timeScale = 0;
                Destroy(this.gameObject);
                eventSystem.onCloneDeathZoneEnter.Invoke();
            }
        }

        if (collision.gameObject.CompareTag(TagNames.CollectableItem.ToString()))
        {
            collision.gameObject.SetActive(false);
            Debug.Log("POTION!");

        }
        if (collision.gameObject.CompareTag(TagNames.ExitKey.ToString()))
        {
            onKey = collision.gameObject;
            // collision.gameObject.SetActive(false);
            Debug.Log("Key!");

        }
        if (collision.gameObject.CompareTag(TagNames.FinishDoor.ToString()))
        {
            onDoor = collision.gameObject;
            // collision.gameObject.SetActive(false);
            Debug.Log("FinishDoor!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.ExitKey.ToString()))
        {
            onKey = null;
            // collision.gameObject.SetActive(false);
            Debug.Log("Key Exited!");

        }
        if (collision.gameObject.CompareTag(TagNames.FinishDoor.ToString()))
        {
            onDoor = null;
            // collision.gameObject.SetActive(false);
            Debug.Log("FinishDoor Exited!");
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
