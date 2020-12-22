using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualRotator : MonoBehaviour
{
    [SerializeField] GameObject objectToRotate;
    [SerializeField] float rotationSpeed = 100f;
    bool dragging = false;
    Rigidbody rb;
    void Start()
    {
        rb = objectToRotate.GetComponent<Rigidbody>();
    }


    void OnMouseDrag()
    {
        dragging = true;
    }
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }
    }

    private void FixedUpdate()
    {
       if(dragging && Input.touchCount>0)
        {
            Touch firstTouch = Input.GetTouch(0);
            float x = firstTouch.deltaPosition.x * rotationSpeed * Time.fixedDeltaTime;
            float y = firstTouch.deltaPosition.y * rotationSpeed * Time.fixedDeltaTime;

            rb.AddTorque(Vector3.down * x);
            rb.AddTorque(Vector3.right * y);
        }
        
    }
}
