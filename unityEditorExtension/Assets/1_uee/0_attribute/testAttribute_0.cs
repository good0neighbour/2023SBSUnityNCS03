using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��� ����Ƽ���� �����ϴ� attribute�� ���캸��.

public class testAttribute_0 : MonoBehaviour
{
    [Range(1, 10)]
    public int mNumber_0 = 1;
    
    [Range(1, 5)]
    public float mNumber_1 = 1.0f;
    
    [Range(1, 2)]
    public double mNumber_2 = 1.0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
