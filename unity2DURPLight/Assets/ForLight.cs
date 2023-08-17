using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForLight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Twinkle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Twinkle()
    {
        for(; ; )
        {
            yield return new WaitForSeconds(0.1f);

            float t = Mathf.Sin(Time.realtimeSinceStartup * 5f);
            t = Mathf.SmoothStep(1.0f, 2.0f, t);

            this.transform.localScale = Vector3.one * t;
        }
    }
}
