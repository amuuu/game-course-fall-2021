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

    public GameObject Key1;
    public GameObject Key2;
    public int takenKeys;
    private bool isNearKey1Region;
    private bool isNearKey2Region;
    public EventSystemCustom eventSystem;

    private bool isNearDoorRegion;

    public GameObject TeleportKey;
    private bool takenTeleportKey;
    private bool isNearTeleportKey;
    private bool isNearSourceDoor;
    public GameObject DestinationDoor;


    void Start()
    {
        cloneMoves = clones.GetComponentsInChildren<CloneMove>();
        canJump = true;
        isNearKey1Region = false;
        isNearKey2Region = false;
        takenTeleportKey = false;
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

        // Check if E pressed, and close enough to take the key
        if (Input.GetKey(KeyCode.E) && (isNearKey1Region || isNearKey2Region))
        {
            if (isNearKey1Region)
            {
                Key1.SetActive(false);
                isNearKey1Region = false;
                eventSystem.CollectKey.Invoke();
            }
            else if (isNearKey2Region)
            {
                Key2.SetActive(false);
                isNearKey2Region = false;
                eventSystem.CollectKey.Invoke();
            }
            // it could be else too, but it is better if in the future key count increases
            if (takenKeys == 0)
            {
                Debug.Log("First Key collected!");
            }
            else if (takenKeys == 1)
            {
                Debug.Log("Second Key collected!");
            }
            takenKeys += 1;
        }

        // win condition
        if (Input.GetKey(KeyCode.E) && takenKeys == 2 && isNearDoorRegion)
        {
            eventSystem.Win.Invoke();
        }

        if (Input.GetKey(KeyCode.E) && isNearTeleportKey)
        {
            takenTeleportKey = true;
            TeleportKey.SetActive(false);
            Debug.Log("You got the teleport key!");
        }

        if (Input.GetKey(KeyCode.E) && takenTeleportKey && isNearSourceDoor)
        {
            this.gameObject.transform.position = DestinationDoor.transform.position;
            Debug.Log("You are just teleported to the destination door!");
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
            eventSystem.Lose.Invoke();
        }
        
        if (collision.gameObject.CompareTag(TagNames.CollectableItem.ToString()))
        {
            collision.gameObject.SetActive(false);
            Debug.Log("POTION!");
        }

        if (collision.gameObject.CompareTag(TagNames.Key1.ToString()))
        {
            isNearKey1Region = true;
        }

        if (collision.gameObject.CompareTag(TagNames.Key2.ToString()))
        {
            isNearKey2Region = true;
        }

        if (collision.gameObject.CompareTag(TagNames.Door.ToString()))
        {
            isNearDoorRegion = true;
        }

        if (collision.gameObject.CompareTag(TagNames.TeleportKey.ToString()))
        {
            isNearTeleportKey = true;
        }
        if (collision.gameObject.CompareTag(TagNames.SourceDoor.ToString()))
        {
            isNearSourceDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.Key1.ToString()))
        {
            isNearKey1Region = false;
        }
        else if (collision.gameObject.CompareTag(TagNames.Key2.ToString()))
        {
            isNearKey2Region = false;
        }
        else if (collision.gameObject.CompareTag(TagNames.Door.ToString()))
        {
            isNearDoorRegion = false;
        }
        if (collision.gameObject.CompareTag(TagNames.TeleportKey.ToString()))
        {
            isNearTeleportKey = false;
        }
        if (collision.gameObject.CompareTag(TagNames.SourceDoor.ToString()))
        {
            isNearSourceDoor = false;
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
