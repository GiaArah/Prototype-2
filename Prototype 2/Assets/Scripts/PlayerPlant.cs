using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlant : MonoBehaviour
{
    public GameObject plant;
    public Transform plantDimensions;
    public Vector3 plantGrow;
    public Vector3 plantWilt;

    Vector3 plantRisePos;

    public GameObject plantPiecePrefab;

    // Start is called before the first frame update
    void Start()
    {
        plant = GameObject.Find("Plant");
        plantDimensions = GameObject.Find("Plant").transform;
        plantGrow = Vector3.up;
        plantWilt = Vector3.down;

        plantRisePos = plant.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Line for testing
        //GrowOrWilt(0.5f, plantGrow);
        GrowSprite();
    }

    //Vector3 direction should be positive for growth, negative for wilt
    //Downside: The sprite will scale both ways anyway
    public void GrowOrWilt(float amount, Vector3 direction)
    {
        plantDimensions.localScale += direction * amount;
    }

    public void GrowSprite()
    {
        GameObject plantPiece = (GameObject)Instantiate(plantPiecePrefab, plantRisePos + new Vector3(0.0f, 6.0f, 0.0f), Quaternion.identity);

        plantRisePos = plantPiece.transform.position;
    }

}
