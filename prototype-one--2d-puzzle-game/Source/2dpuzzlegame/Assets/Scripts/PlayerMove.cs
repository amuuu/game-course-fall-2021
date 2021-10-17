using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public int neededKeys;
    public EventSystemCustom eventSystem;
    public float factor = 0.01f;
    public float jumpAmount = 0.5f;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    public GameObject clones;
    public GameObject KEY;
    public bool ExitDoorTouched;
    public CloneMove[] cloneMoves;
    public lost lost;
    public win win;
    public Text NeededKeyText;
    public  int eatenKeys;
    private bool canJump;
    private Vector3 moveVector;
    
    void Start()
    {
        neededKeys=Random.Range(0, 8);
        NeededKeyText.text=neededKeys.ToString();
        eatenKeys=0;
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

        if(Input.GetKey(KeyCode.E) && KEY!=null){
            KEY.SetActive(false);
            eventSystem.OnCollectKey.Invoke();
            eatenKeys++;
            Debug.Log("KEY");
        }

        if(eatenKeys>=neededKeys && Input.GetKeyDown(KeyCode.E) && ExitDoorTouched==true){
            win.setup();
            Debug.Log("exit door");
            
        }


        // This was added to answer a question.
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ///DEATH ZONE
        if (collision.gameObject.CompareTag(TagNames.DeathZone.ToString()))
        {
            lost.setup();
            Debug.Log("DEATH ZONE");
            Destroy(this.gameObject);
        }
        //POTION
        if (collision.gameObject.CompareTag(TagNames.CollectableItem.ToString()))
        {
            collision.gameObject.SetActive(false);
            Debug.Log("POTION!");
        }
        ///key
        if ( collision.gameObject.CompareTag(TagNames.normalkey.ToString()))
        {
            KEY=collision.gameObject;
        }
        ///exit door
        if (collision.gameObject.CompareTag(TagNames.ExitDoor.ToString()))
        {
           ExitDoorTouched=true;
            Debug.Log("touched door");
        }

    }
        private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.CompareTag(TagNames.normalkey.ToString()))
        {
            KEY=null;
            ExitDoorTouched=false;
        }
      }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.StickyPlatform.ToString()))
        {
            Debug.Log("sticky");
            canJump = false;
        }
       
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.StickyPlatform.ToString()))
        {
            Debug.Log("sticky no more bruh");
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
