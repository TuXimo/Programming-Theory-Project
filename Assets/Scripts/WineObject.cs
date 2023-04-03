using System.Collections;
using UnityEngine;

public class WineObject : BedroomObject
{   
    protected override void ObjectStartAction()
    {
        objectRb.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
    }

    protected override void SaySomething()
    {
        print($"My name is {gameObject.name}, the best wine");
    }
}
