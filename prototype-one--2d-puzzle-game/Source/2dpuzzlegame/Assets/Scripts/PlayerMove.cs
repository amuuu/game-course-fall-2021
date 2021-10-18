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
    private bool getkey;
    public GameObject keys;
    private bool enterdoor;
    private bool canJump;
    private int totalkeycount;
    public bool telKey;
    public bool teleportPermission;

    public Animator animator;

    public EventSystemCustom eventSystem;

    private Vector3 moveVector;
    void Start()
    {
        telKey = false;
        teleportPermission = false;
        totalkeycount = 3;
        cloneMoves = clones.GetComponentsInChildren<CloneMove>();
        keys = null;
        canJump = true;
        getkey = false;
        enterdoor = false;
        moveVector = new Vector3(1 * factor, 0, 0);
    }

    void Update()
    {
        float sp = 0;
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += moveVector;

            MoveClones(moveVector, true);

            spriteRenderer.flipX = false;
            sp += moveVector.x+1;

            animator.SetFloat("speed", sp);

        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= moveVector;

            MoveClones(moveVector, false);

            spriteRenderer.flipX = true;
            sp += moveVector.x+1;

            animator.SetFloat("speed", sp);
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
            if (getkey)
            {
                keys.SetActive(false);
                eventSystem.OnKeyGetStay.Invoke();
                getkey = false;
                totalkeycount -= 1;
                Debug.Log("deasipear key!");
            }

            if (enterdoor && totalkeycount == 0)
            {
                enterdoor = false;
                FindObjectOfType<UiManager>().WiningScene();
            }
        }
        animator.SetFloat("speed", sp);

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
            FindObjectOfType<UiManager>().GameOverScene();
            Debug.Log("DEATH ZONE");
        }
        
        if (collision.gameObject.CompareTag(TagNames.CollectableItem.ToString()))
        {
            collision.gameObject.SetActive(false);
            Debug.Log("POTION!");
        }

        if (collision.gameObject.CompareTag(TagNames.Door.ToString()))
        {
            enterdoor = true;
            Debug.Log("doooor");
        }

        if (collision.gameObject.CompareTag(TagNames.keyitem.ToString()))
        {
            Debug.Log("key!");
            getkey = true;
            keys = collision.gameObject;
        }

        if (collision.gameObject.CompareTag(TagNames.telkey.ToString()))
        {
            Debug.Log("telkey!");
            collision.gameObject.SetActive(false);
            telKey = true;
            FindObjectOfType<UiManager>().GetteleportKey();
        }

        if (collision.gameObject.CompareTag(TagNames.doorT.ToString()) && !FindObjectOfType<Teleport>().destinationDoor)
        {
            Debug.Log("enter near door");
            teleportPermission = true;
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag(TagNames.keyitem.ToString()))
    //    {
    //        if (keydisappear)
    //        {
    //            collision.gameObject.SetActive(false);
    //            keydisappear = false;
    //            eventSystem.OnKeyGetStay.Invoke();
    //            Debug.Log("deasipear key!");
    //        }
    //    }
    //}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.Door.ToString()))
        {
            enterdoor = false;
            Debug.Log("doooor transporteeed");
        }

        if (collision.gameObject.CompareTag(TagNames.keyitem.ToString()))
        {
            Debug.Log("key!");
            getkey = false;
        }

        if (collision.gameObject.CompareTag(TagNames.doorT.ToString()) && !FindObjectOfType<Teleport>().destinationDoor)
        {
            teleportPermission = false;
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
