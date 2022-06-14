using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public AudioSource theMusic;

    public bool startPlaying;

    //public BeatScroller theBS;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;

    public Text scoreText;
    public Text multiText;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public PlayerHealth health;
    public PlayerPlant plant;

    public int difficultyThreshold;

    public float speed;

    //FROM BEATSCROLLER
    //public bool hasStarted;

    public GameObject[] notes;
    public int[] notePosition;

    public float timer;
    public float maxTimer;

    public static NoteObject note;



    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
        multiText.text = "Multiplier: x1";
        currentMultiplier = 1;
        difficultyThreshold = 200;
        plant = GameObject.Find("Plant").GetComponent<PlayerPlant>();
        
        speed = -3f;

        timer = 0;
        maxTimer = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                // hasStarted = true;

                theMusic.Play(); 

            }
        }

        //FROM BEATSCROLLER
        if(startPlaying)
        {
            StartCoroutine("SpawnNoteTimer");
        }
        //********
    }

    public void NoteHit()
    {
        //Debug.Log("Hit on Time");

        if(currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if(multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multiText.text = "Multiplier: x" + currentMultiplier;

        currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;

        plant.GrowSprite();
    }

    public void NoteMissed()
    {
       //Debug.Log("Missed Note");

        currentMultiplier = 1;
        multiplierTracker = 0;
        multiText.text = "Multiplier: x" + currentMultiplier;

        health.TakeDamage();
    }

     //increases difficulty (note speed) based on the score
    public void Difficulty()
    {
        if(currentScore >= difficultyThreshold)
        {
            difficultyThreshold += difficultyThreshold;
            Debug.Log("INCREASE SPEED");
            //increase the speed of all notes
            speed -= 3f;
            Debug.Log("Speed is " + speed);
        }
        
    }

    //FROM BEATSCROLLER
    public void SpawnNote()
    {
        float y = 6.0f;
        Vector3 spawnPoint = new Vector3(notePosition[UnityEngine.Random.Range(0,notePosition.Length)], y, 0);
        spawnPoint.z = 0;
        GameObject newNote = GameObject.Instantiate(notes[UnityEngine.Random.Range(0,notes.Length - 1)], spawnPoint, new Quaternion(0,0,0,0));
    }

    //FROM BEATSCROLLER
    IEnumerator SpawnNoteTimer()
    {
        if(currentScore >= difficultyThreshold && (maxTimer - 1 != 0))
        {
            Debug.Log("DECREASE TIMER");
            maxTimer -= 1; /* = Random.Range(3f,4f); */
            Debug.Log("TIMER IS: " + maxTimer);
        } 

        if(timer >= maxTimer)
        {
            SpawnNote();
            timer = 0;
        }

        timer += 1f * Time.deltaTime;
        yield return new WaitForSecondsRealtime(0.1f);

    }

}
