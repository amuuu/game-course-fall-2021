using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloneMove : MonoBehaviour
{
    public bool isMovingSameDirection;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    private bool canJump;

    private bool canMove;
    //public Text counterText; // Too dirty!

    public EventSystemCustom eventSystem;

    // New variables
    public GameObject pickableItem = null;
    public bool isNearTeleport = false;


    private void Awake()
    {
        canJump = true;
        canMove = true;
    }

    public void Move(Vector3 vec, bool isDirRight)
    {
        if (!canMove)
            return;

        int factor = 1;
        if (isDirRight)
        {
            if (isMovingSameDirection)
            {
                spriteRenderer.flipX = false;
                factor = 1;
            }
            else
            {
                spriteRenderer.flipX = true;
                factor = -1;
            }
        }
        else
        {
            if (isMovingSameDirection)
            {
                spriteRenderer.flipX = true;
                factor = -1;
            }
            else
            {
                spriteRenderer.flipX = false;
                factor = 1;
            }
        }

        transform.position += vec * factor;
    }

    public void Jump(float amount)
    {
        if (canJump)
            rb.AddForce(transform.up * amount, ForceMode2D.Impulse);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.PickableItem.ToString()))
        {
            Debug.Log("POTION! enter trigger pickable");
            pickableItem = collision.gameObject;
        }


        if (collision.gameObject.CompareTag(TagNames.TeleportDoor.ToString()))
        {
            isNearTeleport = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.PickableItem.ToString()))
        {
            Debug.Log("POTION! exit trigger pickable key");
            pickableItem = null;
        }


        if (collision.gameObject.CompareTag(TagNames.TeleportDoor.ToString()))
        {
            isNearTeleport = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.StickyPlatform.ToString()))
        {
            Debug.LogWarning("sticky for clone");

            // Updating the UI text. But this is not a clean way. We'll fix it later.
            /*int newTextValue = int.Parse(counterText.text) + 1;
            counterText.text = newTextValue.ToString();*/

            // This is used by UiManager
            eventSystem.OnCloneStickyPlatformEnter.Invoke();
            Debug.Log("OnCloneStickyPlatformEnter fired.");

            canJump = false;
            canMove = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.StickyPlatform.ToString()))
        {
            Debug.LogWarning("sticky no more for clone bruh");
            canJump = true;
        }
    }
}