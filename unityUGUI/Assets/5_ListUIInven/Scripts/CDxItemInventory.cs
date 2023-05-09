using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDxItemInventory : MonoBehaviour
{

    [SerializeField]
    CListItems mpListItems = null;  //����ƮUI


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
        //activeInHierarchy ���̾��Ű �󿡼� Ȱ�� ����
        return this.gameObject.activeInHierarchy;
    }

}
