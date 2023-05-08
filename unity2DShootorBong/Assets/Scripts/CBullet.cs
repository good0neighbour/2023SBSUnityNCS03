using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //5초 후에 삭제
        Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
