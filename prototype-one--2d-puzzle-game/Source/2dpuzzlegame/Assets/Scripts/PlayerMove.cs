using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animator anim;
    private int MAX_KEYS;
    private bool onExitDoor;
    private GameObject _collectableObject;
    public int collectedKeys = 0;
    
    public float factor;
    public float jumpAmount ;

    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;

    public GameObject clones;
    public CloneMove[] cloneMoves;

    private bool canJump;

    private Vector3 moveVector;
    void Start()
    {
        anim = GetComponent<Animator>();
        cloneMoves = clones.GetComponentsInChildren<CloneMove>();
        MAX_KEYS = GameObject.FindGameObjectsWithTag("Key").Length;
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

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("isWalking",false);
        }
        
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool("isWalking",true);
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
            if (_collectableObject != null)
            {
                collectedKeys++;
                _collectableObject.SetActive(false);
                EventSystemCustom.current.onKeyCollect.Invoke(collectedKeys);
            }
            else if(onExitDoor)
            {
                EventSystemCustom.current.onEndGame.Invoke("You Win");
                
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
            EventSystemCustom.current.onEndGame.Invoke("You Lose,\nNoob!");
        }
        
        else if (collision.gameObject.CompareTag(TagNames.CollectableItem.ToString()))
        {
            collision.gameObject.SetActive(false);
            Debug.Log("POTION!");
        }
        
        else if (collision.gameObject.CompareTag(TagNames.Key.ToString()))
        {
            // collision.gameObject.SetActive(false);
            Debug.Log("KEY!");
            _collectableObject = collision.gameObject;
            EventSystemCustom.current.onHintChange.Invoke("Press E to collect");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.Key.ToString()))
        {
            // collision.gameObject.SetActive(false);
            _collectableObject = null;
            EventSystemCustom.current.onHintChange.Invoke("");
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
            if (collectedKeys == MAX_KEYS)
            {
                onExitDoor = true;
                Debug.Log("exit door");
                EventSystemCustom.current.onHintChange.Invoke("Press E to exit");
            }
            else
            {
                EventSystemCustom.current.onHintChange.Invoke("You need all Keys");
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.StickyPlatform.ToString()))
        {
            Debug.LogWarning("sticky no more bruh");
            canJump = true;
        }
        else if (collision.gameObject.CompareTag(TagNames.ExitDoor.ToString()))
        {
            onExitDoor = false;
            EventSystemCustom.current.onHintChange.Invoke("");
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
