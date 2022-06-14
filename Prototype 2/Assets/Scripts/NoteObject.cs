using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;

    private bool obtained = false;

    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        if(transform.position.x == -8)
        {
            keyToPress = KeyCode.E;
        }
        else if(transform.position.x == 0)
        {
            keyToPress = KeyCode.R;
        }
        else if(transform.position.x == 8)
        {
            keyToPress = KeyCode.T;
        }

        canBePressed = false;

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(0f,GameManager.instance.speed,0f);
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            if(canBePressed)
            {
                if(gameObject.tag == "Bad Note")
                {
                    GameManager.instance.NoteMissed();
                }
                else
                {
                    GameManager.instance.NoteHit();
                }

                obtained = true;

                //gameObject.SetActive(false);
                Destroy(this.gameObject);
            }
            //else
            //{

                //GameManager.instance.NoteMissed();
            //}
        }

        if (transform.position.y < -6)
        {
            Destroy(this.gameObject);
        }
    }

    // Hits note successfully
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    // Note exists but is missed
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = false;
            if(!obtained && !(gameObject.tag == "Bad Note"))
            {
                GameManager.instance.NoteMissed();
            }
            
        }
    }

} 
