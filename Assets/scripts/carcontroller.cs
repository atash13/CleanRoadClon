using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carcontroller : MonoBehaviour
{
    public WheelCollider Arskasag, Arkasol , Onsol, Onsag;
    
    public float Speedcar, Donmehizi,DeltaX,DeltaY, horizontalinput, maxSteerAngle, currentSteerAngle, originalsteer;
    // public Rigidbody rb;

    private void Awake()
    {
        originalsteer = Onsag.steerAngle ;
    }
    void Update()
    {
       
        

        
        
    }
    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    DeltaX = touchPos.x - transform.position.x;
                    DeltaY = touchPos.y - transform.position.y;
                    break;

                case TouchPhase.Moved:
                    //   rb.MovePosition(new Vector3(touchPos.x-DeltaX, transform.position.y, transform.position.z));
                    horizontalinput = touchPos.x - DeltaX;
                    break;
                case TouchPhase.Ended:
                    horizontalinput = originalsteer;
                    break;


            }
        }
        Arskasag.motorTorque = Speedcar;
        Arkasol.motorTorque = Speedcar;
        HandleSteering();
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "kar")
        {
            Destroy(other.gameObject);
        }
    }
    private void HandleSteering()
    {

        currentSteerAngle =maxSteerAngle * horizontalinput;
        Onsag.steerAngle = currentSteerAngle;
        Onsol.steerAngle = currentSteerAngle;
    }


   
}
