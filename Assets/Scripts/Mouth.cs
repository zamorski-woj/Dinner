using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Mouth : MonoBehaviour
{
    public int pkt = 0;
    private Text textComponent;
    private AudioSource audioSource;
    public AudioClip right, death;
    private SpawnCan spawnCan;
    private GameObject physicalCan;
    private LightDim lightMaster;

    // Start is called before the first frame update
    void Start()
    {
        lightMaster = GameObject.Find("Sphere").GetComponent(typeof(LightDim)) as LightDim;

        physicalCan = GameObject.Find("Sugar Can");
        spawnCan = physicalCan.GetComponent(typeof(SpawnCan)) as SpawnCan;

        audioSource = gameObject.GetComponent(typeof(AudioSource)) as AudioSource;

        if (textComponent == null)
        {
            textComponent = GameObject.Find("TextPoints").GetComponent<Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("MouthCollision");
        if (other.gameObject.CompareTag("Sugar"))
        {
            Destroy(other.gameObject);
            pkt++;
            UpdateText(pkt);
            audioSource.PlayOneShot(right, 5.0f);


            spawnCan.Close();
        }


    }


    void UpdateText(int value)
    {
        textComponent.text = "Sugar eaten: " + value;
    }
}
