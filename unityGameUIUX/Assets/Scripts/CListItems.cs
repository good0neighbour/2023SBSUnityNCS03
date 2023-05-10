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
        //�ڷᱸ���� �ѱ��
        BuildSlotsWithDicItemInven(CGameDataMgr.GetInst().mDicItemInventory);
    }

    //�������� �ڷᱸ���� �Ű������� �޾� UI(view)�� �����Ѵ�
    void BuildSlotsWithDicItemInven(SortedDictionary<string, List<CItemData>> tDic)
    {



        //������ ������ ���� ��������
        CSlotItem tSlot = null;

        //������ ������ RectTransform
        RectTransform tSlotRectT = null;
        //�ϳ��� ���� �ʺ�, ���̸� ���ص�
        float tW = 1.0f;
        float tH = 1.0f;    //��Ŀ ���� ������ width, height ���� 0���� �����Ǿ� ������ ���� ��츦 ����
        tW = ((RectTransform)(PFSlotItem.transform)).sizeDelta.x;
        tH = ((RectTransform)(PFSlotItem.transform)).sizeDelta.y;

        int ti = 0; //������ ������ �ε���
        //�ʿ��� slot ui�� ����
        foreach (var t in tDic)
        {
            //�������� �ִ��� �˻�
            if (t.Value.Count > 0)
            {
                tSlot = null;
                //������ �������� ����
                //��ġ ������ ������ List UI
                tSlot = Instantiate<CSlotItem>(PFSlotItem, this.transform.position, Quaternion.identity);

                //��ȯ ���� ������ �θ� �������� �����Ѵ�.
                tSlot.transform.SetParent(this.transform);

                //slot ui�� �ܰ��� ����
                tSlotRectT = null;
                tSlotRectT = (RectTransform)tSlot.transform;    //UI������ҹǷ� RectTransform���� �ٷ���Ѵ�
                tSlotRectT.anchoredPosition = new Vector2(0f, 0f - ti * tH);    //��ġ ���� left, top�� ���������� �Ͽ� y�� �Ϲ����� �޸����� ��
                tSlotRectT.sizeDelta = new Vector2(tW, tH); //���������� ������ �ʺ�, ���� ����

                tSlot.transform.localScale = Vector3.one;   //ũ��� ������ �ະ�� 1


                //data�� ����
                tSlot.SetItemData(t.Value[0]);  //���� ������ �������̶�� ��� ���ٰ� �����Ǿ� �����Ƿ� ù��° ������ ������ ����
                tSlot.SetItemCount(t.Value.Count);
                //�����迭�� ������ ������ ���� ������ ������ ��´�

                tSlot.SetList(this);    //������ ����

                mListSlots.Add(tSlot);  //������� slot ui�� �����迭�� �߰�

                ++ti;   //���� ����
            }
        }

        //instListItems�� ���� ����
        RectTransform tListRectT = null;
        tListRectT = this.transform as RectTransform; //�̷��Ե� ����ȯ ����
        //�� �κп����� �̹� ti�� ���� ������ ī��Ʈ�Ǿ� �����Ƿ�
        //�Ʒ��� ���� ����Ʈ�� ���̸� ���Ѵ�.
        tListRectT.sizeDelta = new Vector2(tW, tH * ti);

        //�ܰ��� �����ϴ� �۾��� ��� ����������
        //slot ui�� ������ �����Ѵ�
        foreach(var t in mListSlots)
        {
            t.BuildRyu();
        }
    }
}
