using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //https://forum.unity.com/threads/minimap-not-working-with-cam-follow-script-or-cinemachine.1168015/

    public GameObject Target; // the obejct the camera follow 
    private Vector3 Offset; //distance between the camera and the target object

    // Start is called before the first frame update
    void Start()
    {
        //subtracting the target object's position from the camera's position.
        Offset = transform.position - Target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //updates the camera's position every frame
        transform.position = Target.transform.position + Offset;

        //updates the camera's position every frame
        transform.position = Target.transform.position + Offset;


    }


}