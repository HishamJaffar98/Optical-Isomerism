using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCanvasLabelClamp : MonoBehaviour
{
    [SerializeField] Transform objectToClampTo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(objectToClampTo.position.x-0.1f, objectToClampTo.position.y-0.1f, objectToClampTo.position.z - 0.63f); ;
    }
}
