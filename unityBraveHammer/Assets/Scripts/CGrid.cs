using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGrid : MonoBehaviour
{
    public CSlime PFSlime = null;

    private CSlime mpCurrentSlime = null;

    // Start is called before the first frame update
    void Start()
    {
        //������ �� ���� ���� ����
        mpCurrentSlime = Instantiate<CSlime>(PFSlime, Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
