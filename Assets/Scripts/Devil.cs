using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Devil : MonoBehaviour
{
	
	public LightDim l;
	public GameObject eyeL, eyeR;
    private Camera c;
    public bool alive = true;
    // Start is called before the first frame update
    void Start()
    {
       l = GameObject.Find("Sphere").GetComponent(typeof(LightDim)) as LightDim; 
        c = GameObject.Find("Camera").GetComponent(typeof(Camera)) as Camera;
        // eyeL = GameObject.Find("Sphere");
        // eyeL = GameObject.Find("Sphere");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

public void Death()
{
        alive = false;
	//l.Darkness();
	//c
	//GameObject.Destroy(gameObject);
}



}
