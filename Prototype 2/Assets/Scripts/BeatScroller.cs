using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{

    public float beatTempo;

    public bool hasStarted;

    public GameObject[] notes;
    public int[] notePosition;

    private List<GameObject> allNotes = new List<GameObject>();

    public int waitTime;

    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f;
        waitTime = 3;
        //Instantiate(notes[UnityEngine.Random.Range(0,notes.Length)], new Vector3(notePosition[UnityEngine.Random.Range(0,notePosition.Length)], 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(hasStarted)
        {
            // transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
            GenerateNotes();
            ScrollNotes();
        }
    }

    public void GenerateNotes()
    {
        GameObject newNote = Instantiate(notes[UnityEngine.Random.Range(0,notes.Length)], new Vector3(notePosition[UnityEngine.Random.Range(0,notePosition.Length)], 6, 0), Quaternion.identity);
        allNotes.Add(newNote);
    }

    public void ScrollNotes()
    {
        foreach(GameObject thisNote in allNotes)
        {
            if(thisNote != null)
            {
                thisNote.transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
            }
        }
    }

}
