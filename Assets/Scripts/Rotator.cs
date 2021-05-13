using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    ///start
    void Start()
    {
        
    }
    ///update
    void Update()
    {
        transform.Rotate(0, 0, 45f * Time.deltaTime);
    }
    ///trigger
    void OnTriggerEnter(Collider collider) 
     {
         if(collider.gameObject.tag == "Player")
         {
             // destroy this object
             Destroy(this.gameObject);
         }
     }
}
