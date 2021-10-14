using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    public float factor = 0.01f;
    public float jumpAmount = 0.5f;
    public int accquiredKeys;

    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;

    public GameObject clones;
    public CloneMove[] cloneMoves;

    public GameObject keys;

    private bool canJump;
    private bool isNearKey;
    private Collider2D nearbyKey;

    private Vector3 moveVector;

    public EventSystemCustom eventSystem;

    void Start()
    {
        cloneMoves = clones.GetComponentsInChildren<CloneMove>();

        canJump = true;
        moveVector = new Vector3(1 * factor, 0, 0);
        isNearKey = false;
        nearbyKey = null;
        accquiredKeys = 0;
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

        if (Input.GetKeyDown(KeyCode.E) &&
            isNearKey)
        {
            PickupKey();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.DeathZone.ToString()))
        {
            Debug.Log("DEATH ZONE");
        }
        
        if (collision.gameObject.CompareTag(TagNames.CollectableItem.ToString()))
        {
            collision.gameObject.SetActive(false);
            Debug.Log("POTION!");
        }

        if (collision.gameObject.CompareTag(TagNames.Key.ToString()))
        {
            eventSystem.OneCharacterNearObjectEnter.Invoke();
            isNearKey = true;
            nearbyKey = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.Key.ToString()))
        {
            eventSystem.OneCharacterNearObjectExit.Invoke();
            isNearKey = false;
            nearbyKey = null;
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

    private void PickupKey()
    {
        if (nearbyKey != null)
        {
            accquiredKeys++;
            eventSystem.OnAccquiredKey.Invoke();
            nearbyKey.gameObject.SetActive(false);
            Debug.Log("Key accquired!!!");
            nearbyKey = null;
        }
    }
}