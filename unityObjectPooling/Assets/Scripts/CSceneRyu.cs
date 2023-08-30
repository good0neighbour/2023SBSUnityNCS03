using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSceneRyu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CRyuMgr.GetInst().CreateRyu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 150, 50), "New Unit"))
        {
            CUnit tUnit = CRyuMgr.GetInst().NewUnit();

            Vector3 tVector = Vector3.zero;
            tVector.x = Random.Range(0f, 5f);
            tVector.y = Random.Range(0f, 5f);
            tVector.z = Random.Range(0f, 5f);
            tUnit.transform.position = tVector;
        }
    }
}
