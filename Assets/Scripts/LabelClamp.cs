using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelClamp : MonoBehaviour
{
    [SerializeField] GameObject objectToClampOn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Camera.main.WorldToScreenPoint(objectToClampOn.transform.position);
    }
}
