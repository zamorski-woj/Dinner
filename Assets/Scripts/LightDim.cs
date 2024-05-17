using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDim : MonoBehaviour
{
    public int i = 1, j = 1;
    public Light[] lights;
    private GameObject bulb, textOne, textTwo;
    private Color oldColor1, oldColor2;
    // Start is called before the first frame update
    void Start()
    {
        lights = FindObjectsOfType<Light>();
        bulb = gameObject;
        textOne = GameObject.Find("Logo");
        textTwo = GameObject.Find("SugarText");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (i == 100 || i == 500 || i == 770)
        {
            StartCoroutine(MultipleBlink(0.00001f, 3));
        }
        if (j == 10 || j == 30 || j == 69)
        {
            StartCoroutine(MultipleBlink(0.000005f, 2));
        }

        i++;
        j++;


        if (i > 1000)
        {
            i = 1;
        }
        if (j >= 123)
        {
            j = 1;
        }
    }

    IEnumerator MultipleBlink(float t = 0.00002f, int decrease = 4, int howMany = 2)
    {
        int blinksLeft = howMany;
        while (blinksLeft > 0)
        {
            StartCoroutine(Blink(t, decrease));
            yield return new WaitForSeconds(t);
            blinksLeft--;
        }
    }

    IEnumerator Blink(float t = 0.00005f, int decrease = 4)
    {
        foreach (Light l in lights)
        {
            if (l.type == LightType.Directional)
            {
                float newInte = l.intensity / decrease;
                l.intensity = newInte;
            }
            else
            {
                if (l.gameObject.CompareTag("EternalLight"))
                { }
                else
                {
                    float newInte = l.intensity / 999;
                    l.intensity = newInte;
                }
            }
        }
       // oldColor1 = DarkenText(textOne, decrease);
       // oldColor2 = DarkenText(textTwo, decrease);

        //textOne.SetActive(false);
        // textTwo.SetActive(false);

        yield return new WaitForSeconds(t);

        foreach (Light l in lights)
        {
            if (l.type == LightType.Directional)
            {
                float newInte = l.intensity * decrease;
                l.intensity = newInte;
            }
            else
            {
                if (l.gameObject.CompareTag("EternalLight"))
                {
                }
                else
                {
                    float newInte = l.intensity * 999;
                    l.intensity = newInte;
                }

            }
            //float newRan=l.range*decrease;
            //l.range=newRan;
           // LightenText(textOne, decrease);
           // LightenText(textTwo, decrease);

        }
        //textOne.SetActive(true);
        /// textTwo.SetActive(true);

    }

    private void LightenText(GameObject text, int decrease)
    {
        Color newColor;
        newColor = Color.white * text.GetComponent<TextMesh>().color;
       
        text.GetComponent<TextMesh>().color = newColor;
    }

    private Color DarkenText(GameObject text, float decrease)
    {
        Color oldColor = text.GetComponent<TextMesh>().color;
        Color newColor;
        newColor = Color.black * text.GetComponent<TextMesh>().color;
      
        text.GetComponent<TextMesh>().color = newColor;
        return oldColor;
    }

    public void Darkness()
    {
        foreach (Light l in lights)
        {
            float newInte = 0;
            l.intensity = newInte;

        }
        //textOne.SetActive(false);
        //textTwo.SetActive(false);
       // DarkenText(textOne, 100);
       // DarkenText(textTwo, 100);

        bulb.SetActive(false);
    }
}
