using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMove : MonoBehaviour
{

    public float factor = 0.01f;
    public float jumpAmount = 0.5f;
    public int keyCounter;
    public int keyTCounter;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    public bool isEDown;
    public GameObject clones;
    public CloneMove[] cloneMoves;
    public GameObject winObject;
    private bool canJump;
    public Text keyNum;
    private bool win;
    private bool Lose;
    public GameObject loser;
    public GameObject dDoor;
    private Vector3 moveVector;
    void Start()
    {
        cloneMoves = clones.GetComponentsInChildren<CloneMove>();
        keyNum.text = 0.ToString();
        canJump = true;
        moveVector = new Vector3(1 * factor, 0, 0);
    }

    void Update()
    {
        if (Lose)
        {
            loser.SetActive(true);
        }

        if (win)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                winObject.SetActive(true);
            }
        }
        if (Input.GetKey(KeyCode.E))
        {

            isEDown = true;
        }
        else
        {
            isEDown = false;
        }


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


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Sdoor")
        {
            
            if (isEDown)
            {
                if (keyTCounter > 0)
                {
                    this.transform.position = dDoor.transform.position;


                }
            }
        }

        if (collision.gameObject.CompareTag(TagNames.DeathZone.ToString()))
        {
            
            Lose = true;
        }

        if (collision.gameObject.CompareTag(TagNames.StickyPlatform.ToString()))
        {
            
            Lose = true;
        }
        if (collision.gameObject.CompareTag(TagNames.CollectableItem.ToString()))
        {
            
            if (Input.GetKey(KeyCode.E))
            {

                collision.gameObject.SetActive(false);
                keyCounter++;
                keyNum.text = keyCounter.ToString();
                Debug.Log("POTION!");
            }
           
        }

        if (collision.gameObject.tag == "KeyT")
        {
            if (isEDown)
            {

                collision.gameObject.SetActive(false);
                keyTCounter++;
                //keyNum.text = keyCounter.ToString();
                Debug.Log(keyTCounter);
            }
        }
        if (collision.gameObject.CompareTag(TagNames.ExitDoor.ToString()))
        {
            
            if (Input.GetKey(KeyCode.E))
            {
                if (keyCounter > 0)
                {

                    Debug.Log("You Win");
                }
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.StickyPlatform.ToString()))
        {
            
            Lose = true;
            Lose = true;
            canJump = false;
        }

        if (collision.gameObject.CompareTag(TagNames.ExitDoor.ToString()))
        {
            if (keyCounter > 0)
            {
                win = true;


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

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "CollectableItem")
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                keyCounter++;
                keyNum.text = keyCounter.ToString();
                Debug.Log("got a key");
                Destroy(gameObject);
            }
        }
    }


}
