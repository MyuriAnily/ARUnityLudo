using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARController : MonoBehaviour
{
    public GameObject MyObject;
    public ARRaycastManager RaycastManager;

    private void Update()
    {
        if(Input.touchCount>0 && Input.GetTouch(0).phase==TouchPhase.Began)
        {
            List<ARRaycastHit> touches = new List<ARRaycastHit>();

            RaycastManager.Raycast(Input.GetTouch(0).position,touches, TrackableType.Planes);

            if(touches.Count>0)
                GameObject.Instantiate(MyObject,touches[0].pose.position,touches[0].pose.rotation);
        }
    }
}