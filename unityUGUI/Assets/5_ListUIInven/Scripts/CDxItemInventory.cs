using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CDxItemInventory : MonoBehaviour
{

    [SerializeField]
    CListItems mpListItems = null;  //리스트UI


    //선택한 아이템 정보 표시
    [SerializeField]
    private TMPro.TMP_Text mTxtNameSelect = null;

    [SerializeField]
    private TMPro.TMP_Text mTxtDescSelect = null;


    // Start is called before the first frame update
    void Start()
    {
        mpListItems.SetDxItemInventory(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuildRyu()
    {
        mpListItems.BuildRyu();
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
    public bool IsShow()
    {
        //activeInHierarchy 하이어라키 상에서 활성 여부
        return this.gameObject.activeInHierarchy;
    }


    public void DoUseItem(CItemData tItemData)
    {
        Debug.Log("<color='red'>DxItemInventory.DoUseItem</color>");

        mTxtNameSelect.text = tItemData.mName;
        mTxtDescSelect.text = tItemData.mDesc;
    }

}
