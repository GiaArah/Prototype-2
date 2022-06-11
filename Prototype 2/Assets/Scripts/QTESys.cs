using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QTESys : MonoBehaviour
{
    public GameObject DisplayBox;
    public GameObject Passbox;
    public int QTEGen;
    public int WaitingForKey;
    public int CorrectKey;
    public int CountingDown;

    
    ScoreCounter score;
    PlayerHealth health;
    PlayerPlant plant;

    void Start()
    {
        score = GameObject.Find("Canvas").GetComponent<ScoreCounter>();
        health = GameObject.Find("HealthBar").GetComponent<PlayerHealth>();
        plant = GameObject.Find("Plant").GetComponent<PlayerPlant>();
    }

    // Update is called once per frame
    void Update()
    {
        if(WaitingForKey == 0)
        {
            QTEGen = Random.Range (1,4);
            CountingDown = 1;
            StartCoroutine (CountDown());

            if(QTEGen == 1)
            {
                WaitingForKey = 1;
                DisplayBox.GetComponent<TextMeshProUGUI>().text = "[E]";
            }
            if(QTEGen == 2)
            {
                WaitingForKey = 1;
                DisplayBox.GetComponent<TextMeshProUGUI>().text = "[R]";
            }
            if(QTEGen == 3)
            {
                WaitingForKey = 1;
                DisplayBox.GetComponent<TextMeshProUGUI>().text = "[T]";
            }
        }
    

        if(QTEGen == 1)
        {
            if(Input.anyKeyDown)
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }

        if(QTEGen == 2)
        {
            if(Input.anyKeyDown)
            {
                if(Input.GetKeyDown(KeyCode.R))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }

        if(QTEGen == 3)
        {
            if(Input.anyKeyDown)
            {
                if(Input.GetKeyDown(KeyCode.T))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
    }

    IEnumerator KeyPressing()
    {
        QTEGen = 4;
        if(CorrectKey == 1)
        {
            CountingDown = 2;
            Passbox.GetComponent<TextMeshProUGUI>().text = "PASS";

            ScoreCounter.instance.AddPoint();
            plant.GrowSprite();

            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            Passbox.GetComponent<TextMeshProUGUI>().text = "";
            DisplayBox.GetComponent<TextMeshProUGUI>().text = "";
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown = 1;
        }
        if(CorrectKey == 2)
        {
            CountingDown = 2;
            Passbox.GetComponent<TextMeshProUGUI>().text = "FAIL";

            health.TakeDamage();

            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            Passbox.GetComponent<TextMeshProUGUI>().text = "";
            DisplayBox.GetComponent<TextMeshProUGUI>().text = "";
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown = 1;
        }
    }

    IEnumerator CountDown ()
    {
        yield return new WaitForSeconds(3.5f);
        if(CountingDown == 1)
        {
            QTEGen = 4;
            CountingDown = 2;
            Passbox.GetComponent<TextMeshProUGUI>().text = "FAIL TOO LONG";

            health.TakeDamage();

            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            Passbox.GetComponent<TextMeshProUGUI>().text = "";
            DisplayBox.GetComponent<TextMeshProUGUI>().text = "";
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown = 1;
        }
    }


}

