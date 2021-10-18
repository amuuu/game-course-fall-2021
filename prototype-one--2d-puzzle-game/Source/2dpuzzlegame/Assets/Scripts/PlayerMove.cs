using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    
    public float factor = 0.01f;
    public float jumpAmount = 0.5f;
	private int keyLimit = 3;
	private int keyCount;
	private int specialKeys;
	private Text text;
	//private Door door;

    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;

    public GameObject clones;
    public CloneMove[] cloneMoves;

    private bool canJump;

	public EventSystemCustom eventSystem;

	private Vector3 moveVector;
    void Start()
    {
        cloneMoves = clones.GetComponentsInChildren<CloneMove>();

        canJump = true;
        moveVector = new Vector3(1 * factor, 0, 0);

		text = GameObject.Find("KeyText").GetComponent<Text>();
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
		// if player gets near a key and presses E, KeyText ui++ 
		if (collision.gameObject.CompareTag(TagNames.Key.ToString()))
		{
			Debug.Log("player near a key");
			if (Input.GetKey(KeyCode.E))
			{
				Debug.Log("player entered E");
				eventSystem.OnKeyTrigger.Invoke();
				Debug.Log("OnKeyTrigger fired.");
				collision.gameObject.SetActive(false);
			}
		}

		// if player gets near a special key and presses E, specialKeyText ui++ 
		if (collision.gameObject.CompareTag(TagNames.SpecialKey.ToString()))
		{
			Debug.Log("player near a special key");
			if (Input.GetKey(KeyCode.E))
			{
				Debug.Log("player entered E");
				eventSystem.OnSpecialKeyTrigger.Invoke();
				Debug.Log("OnSpecialKeyTrigger fired.");
				collision.gameObject.SetActive(false);
			}
		}

		// check for teleport
		if (collision.gameObject.CompareTag(TagNames.Door.ToString()))
		{
			Door sourceDoor = collision.gameObject.GetComponent<Door>();
			Door destDoor = null;
			Debug.Log("player near a door");

			if (sourceDoor.isSource)
			{
				// find how many special key the player has
				specialKeys = int.Parse(GameObject.Find("SpecialKeyText").GetComponent<Text>().text);

				Debug.Log("source door");
				// if presses E, and has specialKey, should teleport
				if (Input.GetKey(KeyCode.E) && specialKeys > 0)
				{
					Doors sourceNum = sourceDoor.doorNum; // source door number
					Debug.Log(sourceNum);

					// get all doors in order to find dest door
					GameObject[] objs = GameObject.FindGameObjectsWithTag("Door");
					foreach(var obj in objs)
					{
						Door d = obj.GetComponent<Door>();
						if (d.isSource)
							continue;

						// find dest door related to this door
						if (d.doorNum == sourceNum)
						{
							Debug.Log("found dest door!");
							destDoor = d;
							break;
						}
					}

					// transfer player to destDoor
					this.transform.position = destDoor.transform.position;
					// special key is used. so decrease its count
					eventSystem.OnSpecialKeyDecrease.Invoke();
				}
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

	private void OnCollisionStay2D(Collision2D collision)
	{
		// if player gets to the door, presses E and has enough key, show win UI text
		if (collision.gameObject.CompareTag(TagNames.ExitDoor.ToString()))
		{
			// get the number of keys
			keyCount = int.Parse(text.text);

			if (Input.GetKey(KeyCode.E) && keyCount >= keyLimit)
			{
				Debug.Log("met exit conditions");
				eventSystem.OnWinCondition.Invoke();
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
}
