using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayer : MonoBehaviour
{
    public CUIInvenOneSlot mUIInven = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray tRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit tHit;

            if (Physics.Raycast(tRay, out tHit, Mathf.Infinity))
            {
                if (tHit.collider.CompareTag("tagItem"))
                {
                    Debug.Log("<color='red'>Aqcuire Item</color>");

                    CItemInfo tInfo = tHit.collider.GetComponent<CItem>().mInfo;
                    if (null != tInfo)
                    {
                        Debug.Log($"item info: id: {tInfo.mId.ToString()}, name: {tInfo.mName}, img index: {tInfo.mImgRscId}");

                        //===아이템 획득===
                        //실제데이터Document갱신
                        CRyuMgr.GetInst().mInventory.Add(tInfo);
                        //UI갱신(View)
                        mUIInven.BuidUI();

                        //월드상에 아이템 제거
                        Destroy(tHit.collider.gameObject);
                        //================
                    }

                }
            }
        }
    }
}
