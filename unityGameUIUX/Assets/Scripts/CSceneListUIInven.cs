using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSceneListUIInven : MonoBehaviour
{
    [SerializeField]
    CDxItemInventory mInven = null;

    // Start is called before the first frame update
    void Start()
    {
        CItemData t = null;
        for (int ti = 0; ti < GameManager.Instance.ItemNum; ++ti)
        {
            t = new CItemData();
            t.mId = 0;
            t.mName = "Red Box";
            t.mDesc = "The item you've collected earlier.";
            t.mCritialRatio = 100;
            t.mRscId = 0;

            CGameDataMgr.GetInst().AddItemToInven(t);
        }
        
        //UI±¸Ãà
        mInven.BuildRyu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
