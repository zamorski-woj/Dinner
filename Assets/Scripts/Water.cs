using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Water : MonoBehaviour
{private EyeFollow eyeLeft, eyeRight;
    private AudioSource a, music;
    public AudioClip death;
    public double level = 0.0;
    public double increase = 0.000000001;
    private LightDim lightMaster;
    private GameObject mark, devil;
    private bool died = false;
    private Devil d;
    private Transform mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        Find();
        Application.runInBackground = true;
    }

    void Find()
    {
        devil = GameObject.Find("diabol");
        music = GameObject.Find("Music").GetComponent(typeof(AudioSource)) as AudioSource;

        d = devil.GetComponent(typeof(Devil)) as Devil;
        a = devil.GetComponent(typeof(AudioSource)) as AudioSource;
        lightMaster = GameObject.Find("Sphere").GetComponent(typeof(LightDim)) as LightDim;
        mark = GameObject.Find("end mark");
        eyeLeft = GameObject.Find("EyeLeft").GetComponent(typeof(EyeFollow)) as EyeFollow;
        eyeRight = GameObject.Find("EyeRight").GetComponent(typeof(EyeFollow)) as EyeFollow;
        mainCamera = GameObject.Find("Stare").GetComponent(typeof(Transform)) as Transform;
        //Debug.Log(mainCamera);
    }
    //increase = music/distance delta time

    // Update is called once per frame
    void FixedUpdate()
    {

        gameObject.transform.Translate(0, (float)(increase/10), 0);

        if ((gameObject.transform.position.y >= mark.transform.position.y) && (died == false))
        {
            Death();
        }
    }

    private void Death()
    {
        if(mainCamera == null)
        {
            mainCamera = GameObject.Find("Stare").GetComponent(typeof(Transform)) as Transform;
            //Debug.Log("camera found "+ mainCamera);
        }
        eyeLeft.eyeDestination = mainCamera;
        eyeRight.eyeDestination = mainCamera;

        died = true;
        d.Death();
        a.PlayOneShot(death, 1.0f);
        Debug.Log("He dead! : (");
        lightMaster.Darkness();
        //GameObject.Destroy(devil);
        StartCoroutine(Wait(2000));

    }

    private IEnumerator Wait(int ms)
    {
        yield return new WaitForSeconds(ms/1000);
        Application.Quit();

    }
}







