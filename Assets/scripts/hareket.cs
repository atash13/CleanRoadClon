using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hareket : MonoBehaviour
{
    private float DeltaX, DeltaY;
    public Rigidbody rb;
    void Update()
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
                // horizontalinput
                    break;
              //  case TouchPhase.Ended:
                 //   rb.velocity = Vector2.zero;
                   // break;


            }
        }
    }
}
