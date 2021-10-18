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

    private bool canJump;

    private Vector3 moveVector;

    private int collectedKeyCount;
    public EventSystemCustom eventSystem;
    private GameObject collidingKey;
    private bool nearExit;
    public int allExitKeysCount;
    private GameObject collidingSwitchKey;
    private GameObject collidingTeleportDoor;
    private int collectedTeleportKeyCount;
    public Animator animator;

    void Start()
    {
        cloneMoves = clones.GetComponentsInChildren<CloneMove>();

        canJump = true;
        moveVector = new Vector3(1 * factor, 0, 0);

        collidingKey = null;
        collectedKeyCount = 0;
        collectedTeleportKeyCount = 0;
        nearExit = false;
        allExitKeysCount = GameObject.FindGameObjectsWithTag(TagNames.LockOpener.ToString()).Length;
        collidingSwitchKey = null;
        GetAnimator();
    }

    void Update()
    {
        float speed = 0;
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += moveVector;

            MoveClones(moveVector, true);

            spriteRenderer.flipX = false;

            speed += moveVector.x;

        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= moveVector;

            MoveClones(moveVector, false);

            spriteRenderer.flipX = true;
            speed += moveVector.x;
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
            if(collidingKey != null)
            {
                collidingKey.SetActive(false);
                collectedKeyCount++;
                eventSystem.onCollectKey.Invoke(collectedKeyCount);
            }
            
            if(nearExit && collectedKeyCount == allExitKeysCount)
            {
                FindObjectOfType<UiManager>().WinScene();
            }

            if (collidingSwitchKey != null)
            {
                collidingSwitchKey.SetActive(false);
                FindObjectOfType<UiManager>().CharacterSwitchingState();
            }

            if(collidingTeleportDoor != null && collectedTeleportKeyCount > 0)
            {
                collidingTeleportDoor.GetComponent<TeleportDoor>().SendObjectToDest(this.gameObject);
                collectedTeleportKeyCount--;
            }

        }

        animator.SetFloat("Speed", speed);

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

    public void GetAnimator()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.DeathZone.ToString()))
        {
            FindObjectOfType<UiManager>().GameOver();
            Debug.Log("DEATH ZONE");
        }

        if (collision.gameObject.CompareTag(TagNames.CollectableItem.ToString()))
        {
            collision.gameObject.SetActive(false);
            Debug.Log("POTION!");
        }

        if (collision.gameObject.CompareTag(TagNames.LockOpener.ToString()))
        {
            collidingKey = collision.gameObject;
        }

        if (collision.gameObject.CompareTag(TagNames.ExitDoor.ToString()))
        {
            nearExit = true;
        }

        if (collision.gameObject.CompareTag(TagNames.SwitchCharacter.ToString()))
        {
            collidingSwitchKey = collision.gameObject;
        }

        if (collision.gameObject.CompareTag(TagNames.TeleportKey.ToString()))
        {
            collision.gameObject.SetActive(false);
            collectedTeleportKeyCount++;
        }

        if (collision.gameObject.CompareTag(TagNames.TeleportSrc.ToString()))
        {
            collidingTeleportDoor = collision.gameObject;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.LockOpener.ToString()))
        {
            collidingKey = null;
        }

        if (collision.gameObject.CompareTag(TagNames.ExitDoor.ToString()))
        {
            nearExit = false;
        }

        if (collision.gameObject.CompareTag(TagNames.SwitchCharacter.ToString()))
        {
            collidingSwitchKey = null;
        }

        if (collision.gameObject.CompareTag(TagNames.TeleportSrc.ToString()))
        {
            collidingTeleportDoor = null;
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.StickyPlatform.ToString()))
        {
            Debug.LogWarning("sticky");
            canJump = false;
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
        foreach (var c in clones.GetComponentsInChildren<CloneMove>())
            c.Move(vec, isDirRight);
    }

    public void JumpClones(float amount)
    {
        foreach (var c in clones.GetComponentsInChildren<CloneMove>())
            c.Jump(amount);
    }

}
