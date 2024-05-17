using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCan : MonoBehaviour
{
    public Animator a;
    public bool open = false;
    public GameObject cube;
    private Devil d;
    //public GameObject spawn;

    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<Animator>();
        d= GameObject.Find("diabol").GetComponent(typeof(Devil)) as Devil;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))//GetKeyDown("space"))
        {
            if(d==null)
            {
                d = GameObject.Find("diabol").GetComponent(typeof(Devil)) as Devil;
            }
            

            if (open == false && d.alive && IsRepeating(a, "Bucket Close")) 
            {
                Spawn();
                Open();
            }
        }
    }


    public void Close()
    {
        a.SetBool("toOpen", false);
        a.SetBool("toClose", true);
        open = false;

    }

    public void Open()
    {
        a.SetBool("toOpen", true);
        a.SetBool("toClose", false);
        open = true;
    }


    public void Spawn(double delay = 0.0)
    {
        GameObject spawn = GameObject.Find("SpawnPoint");
        GameObject.Instantiate(cube, new Vector3(spawn.transform.position.x, spawn.transform.position.y, spawn.transform.position.z), Quaternion.identity);// new Vector3(1.068932f, 0.7547233f, -1.284f), Quaternion.identity);


    }
    bool IsPlaying(Animator anim, string stateName = "BucketClosing", int layer = 0)
    {
        if (anim.GetCurrentAnimatorStateInfo(layer).IsName(stateName) &&
                anim.GetCurrentAnimatorStateInfo(layer).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }
    bool IsRepeating(Animator anim, string stateName = "BucketClosing", int layer = 0)
    {
        if (anim.GetCurrentAnimatorStateInfo(layer).IsName(stateName))
            return true;
        else
            return false;
    }
}
