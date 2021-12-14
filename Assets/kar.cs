using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kar : MonoBehaviour
{
    public GameObject ykar;
    // Start is called before the first frame update
    void Start()
    {
        for( int i=1; i< 83; i++)
        {
            float a = i;
            Instantiate(ykar, new Vector3(2.78f, 0.15f, (a + 57.0f)),Quaternion.identity);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
