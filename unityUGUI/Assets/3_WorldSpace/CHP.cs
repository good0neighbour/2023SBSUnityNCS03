using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3.forward (0, 0, 1)
        //vs
        //���ӿ�����Ʈ�� ����
        this.transform.forward = Camera.main.transform.forward;
    }
}
