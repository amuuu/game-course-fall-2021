using System;
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
    public GameObject keys;
    public Transform[] keysArray;

    private bool canJump;
    private bool canCollectKey;
    private bool canTryDoor;
    private bool canOpenDoor;

    private GameObject key;
    private int numberOfKeys;

    private Vector3 moveVector;
    
    public EventSystemCustom eventSystem;
    void Start()
    {
        cloneMoves = clones.GetComponentsInChildren<CloneMove>();
        keysArray = keys.GetComponentsInChildren<Transform>();

        canJump = true;
        canCollectKey = false;
        canTryDoor = false;
        canOpenDoor = false;
        numberOfKeys = 0;
        // key = new GameObject();
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
        
        if (Input.GetKey(KeyCode.E) && canCollectKey)
        {
            key.SetActive(false);
            eventSystem.onKeyObtained.Invoke();
            Debug.Log("KEY!");
            canCollectKey = false;
            numberOfKeys++;
            if (numberOfKeys == keysArray.Length-1)
            {
                canOpenDoor = true;
            }
        }
        
        if (Input.GetKey(KeyCode.E) && canTryDoor)
        {
            Debug.Log("TRYING DOOR!");
            if (canOpenDoor)
            {
                Debug.Log("VICTORY!");
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
        }
        
        if (collision.gameObject.CompareTag(TagNames.CollectableItem.ToString()))
        {
            collision.gameObject.SetActive(false);
            Debug.Log("POTION!");
        }
        
        if (collision.gameObject.CompareTag(TagNames.KeyItem.ToString()))
        {
            key = collision.gameObject;
            canCollectKey = true;
            Debug.Log("KEY ENTERED!");
        }
        
        if (collision.gameObject.CompareTag(TagNames.DoorItem.ToString()))
        {
            canTryDoor = true;
            Debug.Log("DOOR AREA ENTERED!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.KeyItem.ToString()))
        {
            canCollectKey = false;
            Debug.Log("exit key");
        }
        
        if (collision.gameObject.CompareTag(TagNames.DoorItem.ToString()))
        {
            canTryDoor = false;
            Debug.Log("exit door");
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
