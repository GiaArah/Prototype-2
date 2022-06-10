using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlant : MonoBehaviour
{
    public GameObject plant;

    // Start is called before the first frame update
    void Start()
    {
        plant = GameObject.Find("Plant");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
