using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCont : MonoBehaviour
{
    public Transform Car;
     

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, Car.transform.position, 0.3f);//.lerp ile daha yumuşak takip yapıyorum 
     
    }
}
