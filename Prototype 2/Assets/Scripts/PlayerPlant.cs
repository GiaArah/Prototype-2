using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlant : MonoBehaviour
{
    public GameObject plant;
    public Transform plantDimensions;
    public Vector3 plantGrow;
    public Vector3 plantWilt;

    // Start is called before the first frame update
    void Start()
    {
        plant = GameObject.Find("Plant");
        plantDimensions = GameObject.Find("Plant").transform;
        plantGrow = Vector3.up;
        plantWilt = Vector3.down;
    }

    // Update is called once per frame
    void Update()
    {
        //Line for testing
        GrowOrWilt(0.5f, plantGrow);
    }

    //Vector3 direction should be positive for growth, negative for wilt
    public void GrowOrWilt(float amount, Vector3 direction)
    {
        plantDimensions.localScale += direction * amount;
    }

}
