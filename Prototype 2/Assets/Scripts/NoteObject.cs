using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{

    public bool canBePressed;

    public KeyCode keyToPress;

    private bool obtained = false;

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
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            if(canBePressed)
            {
                GameManager.instance.NoteHit();

                obtained = true;

                //gameObject.SetActive(false);
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = false;
            if(!obtained)
            {
                GameManager.instance.NoteMissed();
            }
            
        }
    }
} 
