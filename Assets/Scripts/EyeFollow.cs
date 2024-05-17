using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeFollow : MonoBehaviour
{
    public GameObject spoon;
    public Transform eyeDestination;
    // Start is called before the first frame update
    void Start()
    {
        spoon = GameObject.Find("Brush");
        eyeDestination = spoon.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(eyeDestination);
    }
}
