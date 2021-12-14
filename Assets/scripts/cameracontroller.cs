using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    public Transform CarTransform;
    public void LateUpdate()
    {
        this.transform.position =Vector3.Lerp(this.transform.position, new Vector3(this.transform.position.x,this.transform.position.y,CarTransform.position.z-20),0.7f);
    }
}
