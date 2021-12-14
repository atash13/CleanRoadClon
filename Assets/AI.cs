using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public static AI instance ;
    NavMeshAgent agent;
    public Transform Target;
    public float saniye;
    public bool basla;
    public GameObject Kapi;

    // Start is called before the first frame update
    void Start()
    {
        basla = false;
        saniye = 0;
        agent = GetComponent<NavMeshAgent>();
        Kapi.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
        saniye++;
        if (basla == true)
        {
            agent.destination = Target.position;
        }
        
    }

   
}
