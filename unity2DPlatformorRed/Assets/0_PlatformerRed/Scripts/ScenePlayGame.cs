using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePlayGame : MonoBehaviour
{
    [SerializeField]
    CActor PFRed = null;


    // Start is called before the first frame update
    void Start()
    {
        //���ΰ� ĳ���� ����
        Instantiate<CActor>(PFRed, Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
