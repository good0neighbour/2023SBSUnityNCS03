using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameUnit : MonoBehaviour
{
    [SerializeField, CGameUnitInfoAttribute]
    public CGameUnitInfo mUnitInfo = null;

    [SerializeField, CGameUnitInfoAttribute]
    public CGameUnitInfo[] mUnitInfos = null;

    [SerializeField]
    float mRyu = 3.14f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
