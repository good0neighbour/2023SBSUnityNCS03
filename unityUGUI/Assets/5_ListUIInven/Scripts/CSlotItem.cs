using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class CSlotItem : MonoBehaviour
{
    //본질적인 아이템 데이터, document
    private CItemData mItemData = null;

    //눈에 보이는 UI구성요소, view
    //[SerializeField] 속성은 유니티에서 제공하고 있다.
    //public이 아니지만 직렬화를 적용하여 유니티 에디터 상에 노출시키는 역할을 한다.
    [SerializeField]
    private Image mImgItem = null;

    [SerializeField]
    private TMPro.TMP_Text mTxtName = null;

    [SerializeField]
    private TMPro.TMP_Text mTxtDesc = null;

    [SerializeField]
    private Button mBtnUse = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuildRyu()
    {
        //clean


        //build
        if (null != mItemData)
        {
            mTxtName.text = mItemData.mName;
            mTxtDesc.text = mItemData.mDesc;

            //mImgItem.sprite = 
        }

    }
}
