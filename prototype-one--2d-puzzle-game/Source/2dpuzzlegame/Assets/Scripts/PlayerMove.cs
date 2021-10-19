using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    private List<CloneMove> aliveClones;

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
        aliveClones = cloneMoves.Where(clone => clone.isActiveAndEnabled).ToList();
        if (aliveClones.Count > 0)
        {
            cloneToSwitchIndex = 0;
            aliveClones[0].EnableArrow();
        }
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
        eventSystem.OnExitCloneSwitchMode.Invoke();
    }

    void Update()
    {
        if (state == "move")
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += moveVector * Time.deltaTime;

                MoveClones(moveVector, true, Time.deltaTime);

                spriteRenderer.flipX = false;

            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= moveVector * Time.deltaTime;

                MoveClones(moveVector, false, Time.deltaTime);

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
            if (aliveClones.Count == 0)
            {
                state = "move";
                eventSystem.OnExitCloneSwitchMode.Invoke();
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    aliveClones[cloneToSwitchIndex].DisableArrow();
                    cloneToSwitchIndex++;
                    if (cloneToSwitchIndex == aliveClones.Count)
                        cloneToSwitchIndex = 0;
                    aliveClones[cloneToSwitchIndex].EnableArrow();
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    aliveClones[cloneToSwitchIndex].DisableArrow();
                    cloneToSwitchIndex--;
                    if (cloneToSwitchIndex == -1)
                        cloneToSwitchIndex = aliveClones.Count - 1;
                    aliveClones[cloneToSwitchIndex].EnableArrow();
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    FinishCloneSwitch();
                }
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
        if (collision.gameObject.CompareTag(TagNames.Platform.ToString())
        || collision.gameObject.CompareTag(TagNames.ExitDoor.ToString()))
        {
            canJump = true;
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
            //canJump = true;
        }
        else if (collision.gameObject.CompareTag(TagNames.Platform.ToString())
        || collision.gameObject.CompareTag(TagNames.ExitDoor.ToString()))
        {
            canJump = false;
        }
    }

    public void MoveClones(Vector3 vec, bool isDirRight, float deltaTime)
    {
        foreach (var c in cloneMoves)
            c.Move(vec, isDirRight, deltaTime);
    }

    public void JumpClones(float amount)
    {
        foreach (var c in cloneMoves)
            c.Jump(amount);
    }
}
