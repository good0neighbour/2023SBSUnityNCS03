using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class CSlotItem : MonoBehaviour
{
    //�������� ������ ������, document
    private CItemData mItemData = null;

    //���� ���̴� UI�������, view
    //[SerializeField] �Ӽ��� ����Ƽ���� �����ϰ� �ִ�.
    //public�� �ƴ����� ����ȭ�� �����Ͽ� ����Ƽ ������ �� �����Ű�� ������ �Ѵ�.
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
