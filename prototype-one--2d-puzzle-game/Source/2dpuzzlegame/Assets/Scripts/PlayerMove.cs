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
    private GameObject arrow;

    public EventSystemCustom eventSystem;

    private bool canJump;

    private Vector3 moveVector;
    string state;
    private int cloneToSwitchIndex;

    void Start()
    {
        cloneMoves = clones.GetComponentsInChildren<CloneMove>();
        arrow = transform.GetChild(0).gameObject;
        eventSystem.OnCloneSwitchMode.AddListener(EnableCloneSwitch);

        canJump = true;
        moveVector = new Vector3(1 * factor, 0, 0);
        state = "move";
        cloneToSwitchIndex = 0;
    }

    private void EnableCloneSwitch()
    {
        arrow.SetActive(false);
        cloneMoves[cloneToSwitchIndex].EnableArrow();
        state = "switch";
    }
    private void FinishCloneSwitch()
    {
        cloneMoves[cloneToSwitchIndex].DisableArrow();
        arrow.SetActive(true);
        var clone = cloneMoves[cloneToSwitchIndex];
        var position = clone.transform.position;
        var flipX = clone.spriteRenderer.flipX;

        clone.transform.position = transform.position;
        clone.spriteRenderer.flipX = spriteRenderer.flipX;
        transform.position = position;
        spriteRenderer.flipX = flipX;
        state = "move";
    }

    void Update()
    {
        if (state == "move")
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
        }
        else if (state == "switch")
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                cloneMoves[cloneToSwitchIndex].DisableArrow();
                cloneToSwitchIndex++;
                if (cloneToSwitchIndex == cloneMoves.Length)
                    cloneToSwitchIndex = 0;
                cloneMoves[cloneToSwitchIndex].EnableArrow();
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                cloneMoves[cloneToSwitchIndex].DisableArrow();
                cloneToSwitchIndex--;
                if (cloneToSwitchIndex == -1)
                    cloneToSwitchIndex = cloneMoves.Length - 1;
                cloneMoves[cloneToSwitchIndex].EnableArrow();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FinishCloneSwitch();
            }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.DeathZone.ToString()))
        {
            eventSystem.OnPlayerDeath.Invoke();
            Debug.Log("DEATH ZONE");
            gameObject.SetActive(false);
        }
        
        if (collision.gameObject.CompareTag(TagNames.CollectableItem.ToString()))
        {
            collision.gameObject.SetActive(false);
            Debug.Log("POTION!");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (collision.gameObject.CompareTag(TagNames.Key.ToString()))
            {
                collision.gameObject.SetActive(false);
                Debug.Log("KEY!");
                eventSystem.OnKeyPickup.Invoke();
                Debug.Log("OnKeyPickup fired.");
            }
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
