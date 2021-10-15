using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    
    public float factor = 0.01f;
    public float jumpAmount = 0.5f;
    public float doordist;

    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;

    public GameObject clones;
    public CloneMove[] cloneMoves;
    public Text keyNumber;
    public GameObject winText;
    public GameObject winDoor;
    public GameObject deathZone;
    public GameObject sourceDoor;
    public GameObject destDoor;

    private bool canJump;
    private bool inExitPos;
    private float dist;

    private Vector3 moveVector;
    void Start()
    {
        cloneMoves = clones.GetComponentsInChildren<CloneMove>();

        canJump = true;
        inExitPos = false;
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

        // 
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inExitPos)
            {
                dist = Vector3.Distance(sourceDoor.transform.position, transform.position);
                if (int.Parse(keyNumber.text) > 0 && dist < doordist)
                {
                    winText.SetActive(true);
                }
                else
                {
                    Debug.Log("You don't have enough key to open the door");
                }
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
            deathZone.SetActive(true);
            Debug.Log("DEATH ZONE");
        }
        
        if (collision.gameObject.CompareTag(TagNames.CollectableItem.ToString()))
        {
            collision.gameObject.SetActive(false);
            Debug.Log("POTION!");
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
            inExitPos = true;
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
