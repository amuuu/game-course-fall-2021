using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    public float factor = 0.01f;
    public float jumpAmount = 0.5f;
    public int totalKeys, accquiredKeys;

    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;

    public GameObject clones;
    public List<CloneMove> cloneMoves;
    int currActiveArrow;

    public GameObject myArrow;
    public GameObject keys;

    private bool canJump, canSwitchCharacter, isInSwitchChatMode;
    private bool isNearKey, isNearExitDoor;
    private Collider2D nearbyKey;

    private Vector3 moveVector;

    public EventSystemCustom eventSystem;

    void Start()
    {
        cloneMoves = clones.GetComponentsInChildren<CloneMove>().ToList();
        totalKeys = GameObject.FindGameObjectWithTag(TagNames.KeyParent.ToString()).transform.childCount;

        isInSwitchChatMode = false;
        canJump = true;
        canSwitchCharacter = false;
        moveVector = new Vector3(1 * factor, 0, 0);
        isNearKey = false;
        isNearExitDoor = false;
        nearbyKey = null;
        accquiredKeys = 0;
        currActiveArrow = 0;

        myArrow = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        UpdateCloneMoveList();
        if (!isInSwitchChatMode)
            NormalControls();

        else
            SwitchCharControls();
    }

    private void SwitchCharControls()
    {
        if (Input.GetKeyDown(KeyCode.D)) // move cursor to next clone
        {
            if (currActiveArrow == cloneMoves.Count)
                return;

            if (currActiveArrow == 0)
                myArrow.SetActive(false);

            else
                cloneMoves[currActiveArrow - 1].myArrow.SetActive(false);

            cloneMoves[currActiveArrow].myArrow.SetActive(true);
            currActiveArrow++;
        }

        if (Input.GetKeyDown(KeyCode.A)) // move cursor to previous clone
        {
            if (currActiveArrow == 0)
                return;

            if (currActiveArrow == 1)
                myArrow.SetActive(true);

            else
                cloneMoves[currActiveArrow - 2].myArrow.SetActive(true);
            
            cloneMoves[currActiveArrow - 1].myArrow.SetActive(false);
            currActiveArrow--;
        }

        if (Input.GetKeyDown(KeyCode.Space))
            SwitchCharacter();
    }

    private void SwitchCharacter()
    {
        if (currActiveArrow != 0)
        {
            var mainCharOriginalPosition = transform.position;
            transform.position = cloneMoves[currActiveArrow - 1].transform.position;
            cloneMoves[currActiveArrow - 1].transform.position = mainCharOriginalPosition;

            myArrow.SetActive(true);
            cloneMoves[currActiveArrow - 1].myArrow.SetActive(false);
        }

        currActiveArrow = 0;
        ExitSwitchCharacterMode();
    }

    private void NormalControls()
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
            Destroy(this.gameObject);

        if (Input.GetKeyDown(KeyCode.E) &&
            isNearKey)
            PickupKey();

        if (Input.GetKeyDown(KeyCode.E) &&
            isNearExitDoor && accquiredKeys == totalKeys)
            eventSystem.OnWon.Invoke();

        if (Input.GetKeyDown(KeyCode.Q) &&
            canSwitchCharacter)
            EnterSwitchCharacterMode();
    }

    private void EnterSwitchCharacterMode()
    {
        Time.timeScale = 0;
        isInSwitchChatMode = true;

        eventSystem.OnCharSwtchEnter.Invoke();
    }

    private void ExitSwitchCharacterMode()
    {
        Time.timeScale = 1;
        isInSwitchChatMode = false;
    
        eventSystem.OnCharSwtchExit.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.DeathZone.ToString()))
        {
            eventSystem.OnLost.Invoke();
        }
        
        if (collision.gameObject.CompareTag(TagNames.CollectableItem.ToString()))
        {
            collision.gameObject.SetActive(false);
            canSwitchCharacter = true;
        }

        if (collision.gameObject.CompareTag(TagNames.Key.ToString()))
        {
            eventSystem.OnCharacterNearObjectEnter.Invoke();
            isNearKey = true;
            nearbyKey = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.Key.ToString()))
        {
            eventSystem.OnCharacterNearObjectExit.Invoke();
            isNearKey = false;
            nearbyKey = null;
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
            eventSystem.OnCharacterExitDoorEnter.Invoke();
            isNearExitDoor = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.StickyPlatform.ToString()))
        {
            Debug.LogWarning("sticky no more bruh");
            canJump = true;
        }

        if (collision.gameObject.CompareTag(TagNames.ExitDoor.ToString()))
        {
            eventSystem.OnCharacterExitDoorExit.Invoke();
            isNearExitDoor = false;
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

    private void PickupKey()
    {
        if (nearbyKey != null)
        {
            accquiredKeys++;
            eventSystem.OnAccquiredKey.Invoke();
            nearbyKey.gameObject.SetActive(false);
            Debug.Log("Key accquired!!!");
            nearbyKey = null;
        }
    }

    private void UpdateCloneMoveList()
    {
        cloneMoves.RemoveAll(item => item == null);
    }
}