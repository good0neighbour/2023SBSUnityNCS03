using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CDxItemInventory : MonoBehaviour
{
    [SerializeField]
    CListItems mpListItems = null;  //리스트UI

    [SerializeField]
    TMP_Text mNumOfItems = null;


    // Start is called before the first frame update
    void Start()
    {
        mpListItems.SetDxItemInventory(this);
        mNumOfItems.text = $"The Number of Items: {GameManager.Instance.ItemNum.ToString()}";
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
}
