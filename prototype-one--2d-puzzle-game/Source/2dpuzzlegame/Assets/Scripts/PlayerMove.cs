using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public EventSystemCustom eventSystem;
    public float factor = 0.01f;
    public float jumpAmount = 0.5f;
    public int count = 0;

    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;

    public GameObject clones;
    public GameObject keys;
    public GameObject door  ;
    public GameObject goldenkey;
    public GameObject sourcedoor;
    public GameObject destdoor;
    public CloneMove[] cloneMoves;
    public bool hasgoldenkey;
    public bool Sourcedoor;
    public bool Destdoor;
    

    private bool canJump;

    private Vector3 moveVector;
    void Start()
    {
        Sourcedoor = false;
        Destdoor = false;
        cloneMoves = clones.GetComponentsInChildren<CloneMove>();
        hasgoldenkey = false;
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
        if (Input.GetKeyDown(KeyCode.E) && door!= null && count>=2)
        {
            Destroy(this.gameObject);
            eventSystem.Win.Invoke();

        }
        if (Input.GetKeyDown(KeyCode.E) && keys !=null)
        {
            Debug.Log(door);
            count++;
            eventSystem.UpdateKeys.Invoke();
            Destroy(keys);
            Debug.Log(count);
        }
        if(Input.GetKeyDown(KeyCode.E) && goldenkey!= null)
        {
            Destroy(goldenkey);
            hasgoldenkey = true;
            Debug.Log(hasgoldenkey);
        }
        if (Input.GetKeyDown(KeyCode.E) && hasgoldenkey == true && Sourcedoor ==true )
        {
            transform.position = new Vector2( -1.403f, 1.0837611f);
            Debug.Log("transformed");
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
            eventSystem.GameOver.Invoke();
        }
        
        if (collision.gameObject.CompareTag(TagNames.CollectableItem.ToString()))
        {
            collision.gameObject.SetActive(false);
            Debug.Log("POTION!");
        }
        if (collision.gameObject.CompareTag("key"))
        {
            keys = collision.gameObject;
        }
        if (collision.gameObject.CompareTag("door"))
        {
            door = collision.gameObject;
        }
        if (collision.gameObject.CompareTag("goldenkey"))
        {
            goldenkey = collision.gameObject;
        }
        if (collision.gameObject.CompareTag("sourcedoor"))
        {
            sourcedoor = collision.gameObject;
            Sourcedoor = true;
        }
        if (collision.gameObject.CompareTag("destdoor"))
        {
            destdoor = collision.gameObject;
            Destdoor = true;
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
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("key"))
        {
            keys = null;
        }
        if (collision.gameObject.CompareTag("door"))
        {
            door = null;
        }
        if (collision.gameObject.CompareTag("goldenkey"))
        {
            goldenkey = null;
        }
        if (collision.gameObject.CompareTag("sourcedoor"))
        {
            Sourcedoor = false;
            sourcedoor = null;
        }
        if (collision.gameObject.CompareTag("destdoor"))
        {
            destdoor = null;
            Destdoor = false;
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
