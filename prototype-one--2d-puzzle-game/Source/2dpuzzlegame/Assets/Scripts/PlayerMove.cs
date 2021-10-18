using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public int storedKey = 0;
    public GameObject keys;
    public int reqKey;
    private bool isSource;
    private bool isDestination;

    private Vector3 target;
    public GameObject TeleportGoal;

    public EventSystemCustom eventSystem;

    void Start()
    {
        cloneMoves = clones.GetComponentsInChildren<CloneMove>();
        
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Key") as GameObject[];
        reqKey = objects.Length - 1;

        canJump = true;
        moveVector = new Vector3(1 * factor, 0, 0);
        isSource = false;
        isDestination = false;


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

        if (Input.GetKeyDown(KeyCode.E)&& isSource)
        {
          
            
                target = TeleportGoal.transform.position;
                // Debug.Log("position" + target);
                transform.position = target;
                Debug.Log("source Doorrrr");
                isSource = false;
            
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



    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.Key.ToString()))
        {
            if (Input.GetKey(KeyCode.E))
            {

                collision.gameObject.SetActive(false);
                Debug.Log("Key!");

                storedKey = storedKey + 1;
                Debug.Log("keyyy" + storedKey);

                eventSystem.OnCollectedKeysEvent.Invoke();
                Debug.Log("keyy invoke");


            }
        }

        if (collision.gameObject.CompareTag(TagNames.WinDoor.ToString()))
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Dooorr!");
                if (reqKey == storedKey)
                {
                    Debug.Log("winnnn" + storedKey);
                    eventSystem.OnWinDoorEvent.Invoke();
                    //  Debug.Log("WinDoor invoke");
                }
            }
        }

        if (collision.gameObject.CompareTag(TagNames.SourceDoor.ToString()))
        {
            isSource = true;
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
