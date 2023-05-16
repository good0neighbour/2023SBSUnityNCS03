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
        //주인공 캐릭터 생성
        Instantiate<CActor>(PFRed, Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
