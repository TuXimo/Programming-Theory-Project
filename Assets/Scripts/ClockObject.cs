using System;
using System.Collections;
using UnityEngine;

public class ClockObject : BedroomObject
{
   

    protected override void ObjectStartAction()
    {
        float force = 50;
        objectRb.AddForce(Vector3.up * force * Time.deltaTime);
    }

    protected override void SaySomething()
    {
        print("I'm the Clock");
    }
}
