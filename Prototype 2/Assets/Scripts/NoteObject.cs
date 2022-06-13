using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{

    public bool canBePressed;

    public KeyCode keyToPress;

    private bool obtained = false;

    public float speed;
    private Rigidbody2D rb;

    //public int timeElapsed;
    //public int[] difficultyThresholds;
    //public int currentDifficulty;
    public float difficultyIndex;
    

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
        rb.velocity = new Vector3(0,speed,0);

        speed = 1.0f;

        difficultyIndex = 1;
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
            else
            {
                GameManager.instance.NoteMissed();
            }
        }

        if (transform.position.y < -6)
        {
            Destroy(this.gameObject);
        }

        Difficulty();
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
            if(!obtained)
            {
                GameManager.instance.NoteMissed();
            }
            
        }
    }


    //increases difficulty (note speed) based on the score
    public void Difficulty()
    {
        if(GameManager.instance.currentScore >= GameManager.instance.difficultyThreshold)
        {
            GameManager.instance.difficultyThreshold += GameManager.instance.difficultyThreshold;
            
            //increase the speed of all spawns, increase rate of spiders
            speed *= 1.5f;
            rb.velocity = new Vector3(0,speed,0);
            Debug.Log("Speed is " + speed);
        }

        // if(difficultyIndex - 1 > difficultyThresholds.Length)
        // {
        //     //difficultyIndex = 0;
        //     return;
        // }
        // else if(difficultyIndex - 1 < difficultyThresholds.Length)
        // {
        //     if(difficultyThresholds[difficultyIndex - 1] <= GameManager.instance.currentScore)
        //     {
        //         difficultyIndex++;
        //         currentDifficulty++;


        //     }
        // }
    }
} 
