using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlant : MonoBehaviour
{
    // Plant color RGB: 0, 140, 49
    public GameObject plant;
    Transform plantDimensions;
    /*public Vector3 plantGrow;
    public Vector3 plantWilt;*/

    SpriteRenderer plantSpriteRenderer;
    float plantRed;
    float plantGreen;
    float plantBlue;

    Vector3 plantRisePos;
    
    public GameObject plantPiecePrefab;
    GameObject currentPlantPiece;

    PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        plant = GameObject.Find("Plant");
        plantDimensions = GameObject.Find("Plant").transform;
        /*plantGrow = Vector3.up;
        plantWilt = Vector3.down;*/

        plantRisePos = plant.transform.position;

        currentPlantPiece = plant;
        
        playerHealth = GameObject.Find("HealthBar").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        //Line for testing
        //GrowOrWilt(0.5f, plantGrow);
        //GrowSprite();
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

        currentPlantPiece = plantPiece;
        plantRisePos = plantPiece.transform.position;
    }

    public void WiltSprite()
    {
        //WIP: Do not use rn. Need a way to keep track of previous plant piece below the one that will be destroyed.
        //Destroy(currentPlantPiece.gameObject);

        //Function will now change color of the sprite
    }

}
