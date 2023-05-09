using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CListItems : MonoBehaviour
{
    //prefab link
    [SerializeField]
    private CSlotItem PFSlotItem = null;


    //������ N���� ������ ��Ƶ� �����迭
    // <-- ���� �߿� �迭�� ũ�� ������ �����ϴٶ�� ������ �� �ڷᱸ���� �����ߴ�.
    private List<CSlotItem> mListSlots = new List<CSlotItem>();


    //�ڽ��� ������ ���ӿ�����Ʈ
    CDxItemInventory mpDxItemInventory = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDxItemInventory(CDxItemInventory t)
    {
        mpDxItemInventory = t;
    }

    public void BuildRyu()
    {
        //���� ������ ������ �����Ѵ�
        //clean
        //������ Ŭ����
        foreach (var t in mListSlots)
        {
            Destroy(t.gameObject);
        }

        mListSlots.Clear(); //�����迭�� ���Ҹ� Ŭ����



        //build
    }
}
