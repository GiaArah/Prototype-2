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
    //public float difficultyIndex;

    public int currScore;
    public int currDiff;
    

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

        speed = -3f;

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(0f,speed,0f);

        //difficultyIndex = 1;

        currScore = 0;
        currDiff = 0;
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
            GetComponent<Rigidbody2D>().velocity = new Vector3(0f, speed, 0f);
        }

        if (transform.position.y < -6)
        {
            Destroy(this.gameObject);
        }

        currScore = GameManager.instance.currentScore;
        currDiff = GameManager.instance.difficultyThreshold;
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
            Debug.Log("INCREASE SPEED");
            //increase the speed of all notes
            speed -= 3f;
            rb.velocity = new Vector3(0f,speed,0f);
            //GetComponent<Rigidbody2D>().velocity = new Vector3(0,speed,0);
            Debug.Log("Speed is " + speed);
        }
        
    }
} 
