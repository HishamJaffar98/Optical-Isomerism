using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Sign(transform.localScale.x)==1)
        {
            transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
        }
        else
        {
            transform.Rotate(0f, -(rotationSpeed * Time.deltaTime), 0f);
        }
        
    }
}
