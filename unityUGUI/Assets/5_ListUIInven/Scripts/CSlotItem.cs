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





    //자신이 속한 소유자 List UI
    CListItems mList = null;

    //아이템의 개수
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
            //개수도 표시
            string t = $"{mItemData.mName} x {mItemCount.ToString()}";
            //mTxtName.text = mItemData.mName;
            mTxtName.text = t;
            mTxtDesc.text = mItemData.mDesc;

            //mImgItem.sprite = 
        }

    }

    //자신이 속한 소유자를 지정한다.
    public void SetList(CListItems tList)
    {
        mList = tList;
    }

    //아이템 정보 얻기
    public CItemData GetItemData()
    {
        return mItemData;
    }

    //아이템 정보 설정
    public void SetItemData(CItemData t)
    {
        mItemData = t;
    }

    //아이템의 개수 설정
    public void SetItemCount(int tCount)
    {
        mItemCount = tCount;
    }

    //버튼 클릭 시 행할 동작 이벤트 핸들러
    public void OnClickBtnUse()
    {
        //해당 아이템 정보를 넘겨 처리를 '위임'한다
        mList.DoUseItem(mItemData);
    }



}
