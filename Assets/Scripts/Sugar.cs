using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sugar : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip wrong;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("diabol").GetComponent(typeof(AudioSource)) as AudioSource;

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("SugarCollision");
        if (other.gameObject.CompareTag("Finish"))
        {
            GameObject.Destroy(gameObject);

            audioSource.PlayOneShot(wrong, 5.0f);
            GameObject can = GameObject.Find("Sugar Can");
            SpawnCan s = can.GetComponent(typeof(SpawnCan)) as SpawnCan;
            s.Close();
        }
    }
}
