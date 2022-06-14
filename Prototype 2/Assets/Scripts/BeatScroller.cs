using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{

    public float beatTempo;

    public bool hasStarted;

    public GameObject[] notes;
    public int[] notePosition;

    public float timer;
    public float maxTimer;

    //public NoteController noteCont;
    //public int[] spawnTimer;

    public static NoteObject note;

    public int currScore;
    public int currDiff;


    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        maxTimer = 5;

        beatTempo = beatTempo / 60f;

        currScore = 0;
        currDiff = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(hasStarted)
        {
            currScore = GameManager.instance.currentScore;
            currDiff = GameManager.instance.difficultyThreshold;
            StartCoroutine("SpawnNoteTimer");
        }


    }

    public void SpawnNote()
    {
        float y = 6.0f;
        Vector3 spawnPoint = new Vector3(notePosition[UnityEngine.Random.Range(0,notePosition.Length)], y, 0);
        spawnPoint.z = 0;
        GameObject newNote = GameObject.Instantiate(notes[UnityEngine.Random.Range(0,notes.Length - 1)], spawnPoint, new Quaternion(0,0,0,0));
        //newNote.GetComponent<Rigidbody2D>().velocity = ;
    }

    IEnumerator SpawnNoteTimer()
    {
        if(currScore >= currDiff && (maxTimer - 1 != 0))
        {
            Debug.Log("DECREASE TIMER");
            maxTimer -= 1; /* = Random.Range(3f,4f); */
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
