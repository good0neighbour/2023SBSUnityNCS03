using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CActor : MonoBehaviour
{
    [SerializeField]
    private float mSpeedmult = 0.1f;

    [SerializeField]
    private float mRotateSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float tH = Input.GetAxis("Horizontal");
        float tV = Input.GetAxis("Vertical");
        float tD = transform.eulerAngles.y;

        transform.position += new Vector3(Mathf.Sin(tD * Mathf.PI / 180.0f), 0.0f, Mathf.Cos(tD * Mathf.PI / 180.0f)) * tV * mSpeedmult;
        transform.Rotate(0.0f, tH * tV * mRotateSpeed, 0.0f);
    }
}
