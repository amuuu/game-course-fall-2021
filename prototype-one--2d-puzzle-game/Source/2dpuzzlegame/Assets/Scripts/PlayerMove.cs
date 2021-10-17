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
    public GameObject keys;
    public CloneMove[] cloneMoves;

    public EventSystemCustom eventSystem;

    private GameObject key;
    private GameObject teleportKey;
    private int collectedKeysNum;

    private int totalKeyCount;
    private bool canJump;
    private bool isNearDoor;

    private Vector3 moveVector;
    void Start()
    {
        cloneMoves = clones.GetComponentsInChildren<CloneMove>();
        totalKeyCount = keys.GetComponentsInChildren<BoxCollider2D>().Length;

        collectedKeysNum = 0;

        canJump = true;
        moveVector = new Vector3(1 * factor, 0, 0);

        isNearDoor = false;
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

        if (Input.GetKeyDown(KeyCode.E) && key)
        {
            Destroy(key);
            collectedKeysNum++;
            eventSystem.OnPlayerKeyCollect.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.E) && isNearDoor && (collectedKeysNum == totalKeyCount))
        {
            eventSystem.OnPlayerWin.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.E) && teleportKey)
        {
            Destroy(teleportKey);
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
            eventSystem.OnPlayerLose.Invoke();
        }
        
        if (collision.gameObject.CompareTag(TagNames.CollectableItem.ToString()))
        {
            collision.gameObject.SetActive(false);
            Debug.Log("POTION!");
        }

        if (collision.gameObject.CompareTag(TagNames.ExitKey.ToString()))
        {
            key = collision.gameObject;
        }

        if (collision.gameObject.CompareTag(TagNames.TeleportKey.ToString()))
        {
            teleportKey = collision.gameObject;
        }

        if (collision.gameObject.CompareTag(TagNames.ExitDoor.ToString()))
        {
            isNearDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.ExitKey.ToString()))
        {
            key = null;
        }

        if (collision.gameObject.CompareTag(TagNames.TeleportKey.ToString()))
        {
            teleportKey = null;
        }

        if (collision.gameObject.CompareTag(TagNames.ExitDoor.ToString()))
        {
            isNearDoor = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.StickyPlatform.ToString()))
        {
            Debug.LogWarning("sticky");
            canJump = false;
        }

        if (collision.gameObject.CompareTag(TagNames.ExitPlatform.ToString()))
        {
            Debug.Log("exit platform");
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
