using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlant : MonoBehaviour
{
    public GameObject plant;
    public Transform plantDimensions;
    public Vector3 plantScale;

    // Start is called before the first frame update
    void Start()
    {
        plant = GameObject.Find("Plant");
        plantDimensions = GameObject.Find("Plant").transform;
        plantScale = Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        //Line for testing
        //GrowOrWilt(0.5f, plantScale);
    }

    //Vector3 direction should be positive for growth, negative for wilt
    public void GrowOrWilt(float amount, Vector3 direction)
    {
        plantDimensions.localScale += direction * amount;
    }

}
