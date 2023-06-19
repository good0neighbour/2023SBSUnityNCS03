using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForRotate : MonoBehaviour
{
    [SerializeField]
    float mAngle = 720f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.up, mAngle * Time.deltaTime, Space.World);
    }
}
