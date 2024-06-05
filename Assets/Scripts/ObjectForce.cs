using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectForce : MonoBehaviour
{
    public void OnHit()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward * 300f);
        GetComponent<Rigidbody>().AddTorque(800f,0f,0f);
    }
}
