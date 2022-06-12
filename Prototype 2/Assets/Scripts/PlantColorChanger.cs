using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantColorChanger : MonoBehaviour
{
    GameObject[] plantPieces;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePlantColor()
    {
        // Track all instances of plant fragment prefabs

        plantPieces = GameObject.FindGameObjectsWithTag("Plant Fragment");

        foreach(GameObject plantPiece in plantPieces)
        {
            plantPiece.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f);
        }
    }
}
