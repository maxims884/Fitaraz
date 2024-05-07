using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Destrictible : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obj;
    public GameObject parentObj;
    public int n;

    public GameObject DestroyObj()
    {
        GameObject newObj;
        newObj = Instantiate(obj,  parentObj.transform);
        newObj.transform.position = transform.position;
        Destroy(gameObject);
        return newObj;
    }

}
