using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
	public	AudioSource audioSource;
	public AudioClip plum;
    // Start is called before the first frame update
    void Start()
    {
      audioSource=gameObject.GetComponent(typeof(AudioSource)) as AudioSource;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	
	
	private void OnTriggerEnter(Collider other)
    {
				Debug.Log("drip");

		if (other.gameObject.CompareTag("Finish"))
		{
			float volume = Random.value * 100;
			audioSource.PlayOneShot(plum, volume);
						GameObject.Destroy(gameObject);

			
		}
	}
}
