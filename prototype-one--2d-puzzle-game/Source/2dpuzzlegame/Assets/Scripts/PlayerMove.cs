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
    public int collectedExitKeys = 0;
    public int collectedTeleportKeys = 0;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;

    public GameObject clones;
    public CloneMove[] cloneMoves;

    private bool canJump;
    public bool canEnd = false;
    private GameObject onExitKey;
    private GameObject onTeleportKey;
    private GameObject onDoor;
    private GameObject onSrcDoor;
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
            
            if (onExitKey != null && canEnd == false)
            {
                collectedExitKeys++;
                if(eventSystem != null)
                    eventSystem.onCloneKeyCounterEnter.Invoke();
                Destroy(this.onExitKey);
                // onExitKey.SetActive(false);
            }
            
            if (onDoor != null && canEnd)
            {
                Debug.Log("YOU WON! My friend");
                if(eventSystem != null)
                    eventSystem.onCloneExitDoorEnter.Invoke();
                Time.timeScale = 0;
                // Destroy(this.onDoor);
                // onExitKey.SetActive(false);
            }
            
            if (collectedExitKeys == 4)
            {
                canEnd = true;
            }

            if (onTeleportKey != null)
            {
                collectedTeleportKeys++;
                Destroy(this.onTeleportKey);
            }

            if (onSrcDoor != null && collectedTeleportKeys == 2)
            {
                GameObject targetDoor = GameObject.FindWithTag(TagNames.TargetDoor.ToString());
                transform.position = targetDoor.transform.position;
            }
            
        }
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
            onExitKey = collision.gameObject;
            // collision.gameObject.SetActive(false);
            Debug.Log("ExitKey!");

        }
        if (collision.gameObject.CompareTag(TagNames.TeleportKey.ToString()))
        {
            onTeleportKey = collision.gameObject;
            // collision.gameObject.SetActive(false);
            Debug.Log("TeleportKey!");

        }
        if (collision.gameObject.CompareTag(TagNames.FinishDoor.ToString()))
        {
            onDoor = collision.gameObject;
            // collision.gameObject.SetActive(false);
            Debug.Log("FinishDoor!");
        }
        if (collision.gameObject.CompareTag(TagNames.SrcDoor.ToString()))
        {
            onSrcDoor = collision.gameObject;
            // collision.gameObject.SetActive(false);
            Debug.Log("SrcDoor!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.ExitKey.ToString()))
        {
            onExitKey = null;
            // collision.gameObject.SetActive(false);
            Debug.Log("Key Exited!");

        }
        if (collision.gameObject.CompareTag(TagNames.FinishDoor.ToString()))
        {
            onDoor = null;
            // collision.gameObject.SetActive(false);
            Debug.Log("FinishDoor Exited!");
        }
        if (collision.gameObject.CompareTag(TagNames.SrcDoor.ToString()))
        {
            onSrcDoor = null;
            // collision.gameObject.SetActive(false);
            Debug.Log("SrcDoor Exited");
        }
        if (collision.gameObject.CompareTag(TagNames.TeleportKey.ToString()))
        {
            onTeleportKey = null;
            // collision.gameObject.SetActive(false);
            Debug.Log("TeleportKey!");

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
