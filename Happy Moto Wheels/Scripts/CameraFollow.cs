using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerCar;
    
    void FixedUpdate()
    {
        transform.position = new Vector3(playerCar.position.x, playerCar.position.y, transform.position.z);
    }
}
