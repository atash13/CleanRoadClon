using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yenikontrol : MonoBehaviour
{
    public static yenikontrol instance;
    public float torque = 500;
    public float breaktorque =1000;
    public WheelCollider[] wheelColliders;
    public Transform[] wheelTransforms;
    private Vector3 wheelposition, dragdistance;
    private Quaternion wheelrotation;
    public float DeltaX, DeltaY, horizontalinput, currentSteerAngle, maxSteerAngle, Speed, MaxSpeed, sayac;
    public float originalsteer = 0.0f;
    private Touch firsttouch;
    public Rigidbody rb;
    public GameObject car1, car2, car3;
    public Text win, lose;
    public Button next, retry;


    private void Start()
    {
        MaxSpeed = 80;
        sayac = 0;
    }
    private void Update()
    {
        for (int i = 0; i< wheelColliders.Length; i++)
        {
            if(Speed < MaxSpeed)
            {
                wheelColliders[i].brakeTorque = 0;
                wheelColliders[i].motorTorque = torque;
            }
            if(Speed == MaxSpeed)
            {
                wheelColliders[i].brakeTorque = 0;
                wheelColliders[i].motorTorque = 0;
            }
            if(Speed > MaxSpeed)
            {
                wheelColliders[i].brakeTorque = breaktorque;
                wheelColliders[i].motorTorque = 0;
            }
            
            if (Input.touchCount > 0)
            {

                firsttouch = Input.GetTouch(0);
               

            }
        }
        updatewheels();
        HandleSteering();
        
        
        Speed = rb.velocity.sqrMagnitude;
        if(sayac > 100 && Speed < 0.02)
        {
            
            lose.gameObject.SetActive(true);
            retry.gameObject.SetActive(true);
        }
    }
    private void FixedUpdate()
    {
        if(Input.touchCount >0)
        {
            Touch touch = Input.GetTouch(0);
            if(Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                dragdistance = touch.deltaPosition;
                
            }
        }
        sayac ++;
    }

    public void updatewheels()
    {
        for (int i=0; i< wheelColliders.Length; i++)
        {
            wheelColliders[i].GetWorldPose(out wheelposition, out wheelrotation);
            wheelTransforms[i].transform.rotation = wheelrotation;
            wheelTransforms[i].transform.position = wheelposition;
        }
    }
    private void HandleSteering()
    {

        currentSteerAngle = maxSteerAngle * (dragdistance.x/50);
        if (currentSteerAngle <= 12 && currentSteerAngle > -12)
        {
            wheelColliders[0].steerAngle = currentSteerAngle;
            wheelColliders[1].steerAngle = currentSteerAngle;
        }
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "kar")
        {
            // Destroy(other.gameObject);
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "kapi1")
        {
            car1.GetComponent<AI>().basla = true;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "kapi2")
        {
            car2.GetComponent<AI>().basla = true;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "kapi3")
        {
            car3.GetComponent<AI>().basla = true;
            other.gameObject.SetActive(false);
        }
        if(other.gameObject.tag == "finish")
        {
            other.gameObject.SetActive(false);
            MaxSpeed = 0;
            win.gameObject.SetActive(true);
            next.gameObject.SetActive(true);
        }
    }
}
