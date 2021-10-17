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

    public EventSystemCustom eventSystem;

    public int keyCounter = 0;
    public bool keyCollided = false;
    public GameObject key;

    public bool exitCollided = false;

    public int specialKeyCounter = 0;
    public bool specialKeyCollided = false;
    public GameObject specialKey;
    public bool teleport = false;
    public GameObject source;

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


        // Collect key
        if (Input.GetKeyDown(KeyCode.E) && keyCollided)
        {
            keyCollided = false;
            key.SetActive(false);

            // Update text on scene
            eventSystem.OnCollectKey.Invoke();

            // Key numbers
            keyCounter += 1;
        }

        // Collect special key
        if (Input.GetKeyDown(KeyCode.E) && specialKeyCollided)
        {
            specialKeyCollided = false;
            specialKey.SetActive(false);

            // Update text on scene
            eventSystem.OnCollectSpecialKey.Invoke();

            // Key numbers
            specialKeyCounter += 1;
        }

        // Exit door
        if (Input.GetKeyDown(KeyCode.E) && exitCollided && keyCounter > 0)
        {
            exitCollided = false;

            // Update text on scene
            eventSystem.OnWin.Invoke();

            // Key numbers
            keyCounter -= 1;
            eventSystem.OnLoseKey.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.E) && teleport && specialKeyCounter > 0)
        {
            teleport = false;
            GameObject destination = source.transform.GetChild(0).gameObject;
            transform.position = destination.transform.position;

            // Key numbers
            specialKeyCounter -= 1;
            eventSystem.OnLoseSpecialKey.Invoke();
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
            Destroy(this.gameObject);
            eventSystem.OnLose.Invoke();
        }
        
        if (collision.gameObject.CompareTag(TagNames.CollectableItem.ToString()))
        {
            collision.gameObject.SetActive(false);
            Debug.Log("POTION!");
        }

        if (collision.gameObject.CompareTag(TagNames.Key.ToString()))
        {
            Debug.Log("KEY!");
            keyCollided = true;
            key = collision.gameObject;
        }

        if (collision.gameObject.CompareTag(TagNames.SpecialKey.ToString()))
        {
            Debug.Log("SPECIAL KEY!");
            specialKeyCollided = true;
            specialKey = collision.gameObject;
        }

        if (collision.gameObject.CompareTag(TagNames.ExitDoor.ToString()))
        {
            Debug.Log("EXIT DOOR!");
            exitCollided = true;
        }

        if (collision.gameObject.CompareTag(TagNames.Source.ToString()))
        {
            Debug.Log("Near speacial door");
            // Retrieve its destination
            source = collision.gameObject;
            teleport = true;

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.Key.ToString()))
        {
            Debug.Log("EXIT KEY!");
            keyCollided = false;
        }

        if (collision.gameObject.CompareTag(TagNames.SpecialKey.ToString()))
        {
            Debug.Log("EXIT SPECIAL KEY!");
            specialKeyCollided = false;
        }

        if (collision.gameObject.CompareTag(TagNames.ExitDoor.ToString()))
        {
            Debug.Log("OUT OF EXIT DOOR!");
            exitCollided = false;
        }

        if (collision.gameObject.CompareTag(TagNames.Source.ToString()))
        {
            Debug.Log("Exit near speacial door");
            // Retrieve its destination
            teleport = false;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.StickyPlatform.ToString()))
        {
            Debug.LogWarning("STICKY");
            canJump = false;
        }

        //if (collision.gameObject.CompareTag(TagNames.ExitDoor.ToString()))
        //{
        //    Debug.Log("EXIT DOOR");
        //}
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.StickyPlatform.ToString()))
        {
            Debug.LogWarning("STICKY NO MORE BRUH");
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
