using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{

    public float beatTempo;

    public bool hasStarted;

    public GameObject[] notes;
    public int[] notePosition;

    //public GameObject tempTest;

    private List<GameObject> allNotes = new List<GameObject>();

    public float timer;
    public float maxTimer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        maxTimer = Random.Range(5f,12f);

        beatTempo = beatTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasStarted)
        {
            StartCoroutine("SpawnNoteTimer");
        }
    }

    public void SpawnNote()
    {
        float y = 6.0f;
        Vector3 spawnPoint = new Vector3(notePosition[UnityEngine.Random.Range(0,notePosition.Length)], y, 0);
        spawnPoint.z = 0;
        GameObject newNote = GameObject.Instantiate(notes[UnityEngine.Random.Range(0,notes.Length - 1)], spawnPoint, new Quaternion(0,0,0,0));
        //GameObject newNote = GameObject.Instantiate(tempTest, spawnPoint, new Quaternion(0,0,0,0));

    }

    IEnumerator SpawnNoteTimer()
    {
        if(timer >= maxTimer)
        {
            SpawnNote();
            timer = 0;
            maxTimer = Random.Range(5f,12f);
        }

        timer += 1f * Time.deltaTime;
        yield return new WaitForSecondsRealtime(0.1f);

    }

}
