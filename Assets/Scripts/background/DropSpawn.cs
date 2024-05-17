using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawn : MonoBehaviour
{
    public int i = 1, j = 1;

    public GameObject drop;

    public AudioSource audioSource;
    public AudioClip plum;
    private Vector3 startingPosition;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = gameObject.transform.position;
        audioSource = gameObject.GetComponent(typeof(AudioSource)) as AudioSource;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (i == 30 || i == 348 || i == 777)
        {
            //GameObject.Instantiate(drop);
            MoveSomwhere();
            float volume = Random.value * 0.07f + 0.03f;
            audioSource.PlayOneShot(plum, volume);

        }
        if (j == 120 || j == 750 || j == 200)
        {
            //GameObject.Instantiate(drop);
            MoveSomwhere();
            float volume = Random.value * 0.05f + 0.04f;
            audioSource.PlayOneShot(plum, volume);

        }

        i++;
        j++;


        if (i > 1260)
        {
            i = 1;
        }
        if (j >= 999)
        {
            j = 1;
        }
    }

    private void MoveSomwhere()
    {
        float newX = startingPosition.x + (Random.Range(-2.0f, 2.0f));
        float newZ = startingPosition.z + (Random.Range(-2.0f, 2.0f));
        Vector3 newPosition = new Vector3(newX, gameObject.transform.position.y, newZ);
        gameObject.transform.position = newPosition;
    }
}
