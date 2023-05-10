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





    //�ڽ��� ���� ������ List UI
    CListItems mList = null;

    //�������� ����
    int mItemCount = 0;


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
            //������ ǥ��
            string t = $"{mItemData.mName} x {mItemCount.ToString()}";
            //mTxtName.text = mItemData.mName;
            mTxtName.text = t;
            mTxtDesc.text = mItemData.mDesc;

            //mImgItem.sprite = 
        }

    }

    //�ڽ��� ���� �����ڸ� �����Ѵ�.
    public void SetList(CListItems tList)
    {
        mList = tList;
    }

    //������ ���� ���
    public CItemData GetItemData()
    {
        return mItemData;
    }

    //������ ���� ����
    public void SetItemData(CItemData t)
    {
        mItemData = t;
    }

    //�������� ���� ����
    public void SetItemCount(int tCount)
    {
        mItemCount = tCount;
    }

    //��ư Ŭ�� �� ���� ���� �̺�Ʈ �ڵ鷯
    public void OnClickBtnUse()
    {
        //�ش� ������ ������ �Ѱ� ó���� '����'�Ѵ�
        mList.DoUseItem(mItemData);
    }



}
