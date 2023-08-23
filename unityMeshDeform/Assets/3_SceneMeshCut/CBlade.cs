using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBlade : MonoBehaviour
{
    public GameObject mpVictim = null;



    // Start is called before the first frame update
    void Start()
    {
        MeshCut.Cut(mpVictim, Vector3.zero, Vector3.right, null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
