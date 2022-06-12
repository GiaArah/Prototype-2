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

    //WORKING ON
    //public int timeElapsed;
    public int[] difficultyThresholds;
    public float difficultyIndex;
    public int currentDifficulty;

    

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

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0,speed);

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
        }
        if(transform.position.y < -6)
        {
            Destroy(this.gameObject);
        }
        Difficulty();
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


    public void Difficulty()
    {
        if(GameManager.instance.currentScore >= GameManager.instance.difficultyThreshold)
        {
            GameManager.instance.difficultyThreshold += GameManager.instance.difficultyThreshold;
            
            //increase the speed of all spawns, increase rate of spiders
            speed -= 0.25f;
            rb.velocity = new Vector2(0,speed);

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
