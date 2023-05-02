using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFxFadeIn : MonoBehaviour
{
    void OnHide()
    {
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("OnHide", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
