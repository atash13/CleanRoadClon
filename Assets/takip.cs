using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takip : MonoBehaviour
{

    public Transform CarTransform;
    public GameObject Player;
    public void LateUpdate()
    {
        if (Player.GetComponent<yenikontrol>().Speed > 0.2f)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(CarTransform.position.x, CarTransform.position.y, CarTransform.position.z - 15), 0.1f);
        }
        else
        {
            this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(this.transform.position.x, this.transform.position.y, CarTransform.position.z - 0), 0.1f);
        }
    }
}
