using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloneMove : MonoBehaviour
{
    public bool isMovingSameDirection;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    private bool canJump;
    private bool canMove;
    //public Text counterText; // Too dirty!
    public GameObject arrow;
    public bool arrowActive;
    public Vector3 position;
    public GameObject DestinationDoor;

    public EventSystemCustom eventSystem;

    private void Awake()
    {
        canJump = true;
        canMove = true;
        arrowActive = false;
    }
    private void Update()
    {
        arrow.SetActive(arrowActive);
        position = transform.position;
    }

    public void SwitchCloneAndCharacter(Vector3 SwitchPosition)
    {
        transform.position = SwitchPosition;
    }
    public void Move(Vector3 vec, bool isDirRight)
    {
        if (!canMove)
            return;

        int factor = 1;
        if (isDirRight)
        {
            if (isMovingSameDirection)
            {
                spriteRenderer.flipX = false;
                factor = 1;
            }
            else
            {
                spriteRenderer.flipX = true;
                factor = -1;
            }
        }
        else
        {

            if (isMovingSameDirection)
            {
                spriteRenderer.flipX = true;
                factor = -1;
            }
            else
            {
                spriteRenderer.flipX = false;
                factor = 1;

            }
        }

        transform.position += vec * factor;
    }

    public void Jump(float amount)
    {
        if (canJump)
            rb.AddForce(transform.up * amount, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.StickyPlatform.ToString()))
        {
            Debug.LogWarning("sticky for clone");

            // Updating the UI text. But this is not a clean way. We'll fix it later.
            /*int newTextValue = int.Parse(counterText.text) + 1;
            counterText.text = newTextValue.ToString();*/

            // This is used by UiManager
            eventSystem.OnCloneStickyPlatformEnter.Invoke();
            Debug.Log("OnCloneStickyPlatformEnter fired.");

            canJump = false;
            canMove = false;

        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.StickyPlatform.ToString()))
        {
            Debug.LogWarning("sticky no more for clone bruh");
            canJump = true;
            canMove = true;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.DeathZone.ToString()))
        {
            //rb.gameObject.SetActive(false);
            Destroy(this.gameObject);

        }
        if (collision.gameObject.CompareTag(TagNames.EnterTransportDoor.ToString()))
        {
            //rb.gameObject.SetActive(false);
            Debug.Log("hello");
            transform.position = DestinationDoor.transform.position;

        }
    }
}
