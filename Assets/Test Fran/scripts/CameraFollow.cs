using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Vector3 targetCamPos;
    Vector3 targetTemp;

    public Transform target;
    public float smoothing = 5f;

   Vector3 offset;
    Quaternion targetAngle;

   void start(){
       offset = transform.position - target.position;

    }

   private void FixedUpdate(){

        targetTemp = new Vector3(target.position.x, target.position.y+5, target.position.z-5);

        targetCamPos = targetTemp + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);

        targetAngle = Quaternion.Euler(45, 0, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetAngle, Time.deltaTime * 5);
    }
}
