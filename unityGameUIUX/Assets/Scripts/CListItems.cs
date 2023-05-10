using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CListItems : MonoBehaviour
{
    //prefab link
    [SerializeField]
    private CSlotItem PFSlotItem = null;


    //임의의 N개의 슬롯을 담아둘 가변배열
    // <-- 실행 중에 배열의 크기 조정이 가능하다라는 이유로 이 자료구조를 선택했다.
    private List<CSlotItem> mListSlots = new List<CSlotItem>();


    //자신을 포함한 게임오브젝트
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
        //가장 간단한 구현을 가정한다
        //clean
        //슬롯을 클리어
        foreach (var t in mListSlots)
        {
            Destroy(t.gameObject);
        }

        mListSlots.Clear(); //가변배열의 원소를 클리어



        //build
        //자료구조를 넘긴다
        BuildSlotsWithDicItemInven(CGameDataMgr.GetInst().mDicItemInventory);
    }

    //아이템의 자료구조를 매개변수로 받아 UI(view)를 구축한다
    void BuildSlotsWithDicItemInven(SortedDictionary<string, List<CItemData>> tDic)
    {



        //임의의 슬롯을 담을 지역변수
        CSlotItem tSlot = null;

        //임의의 슬롯의 RectTransform
        RectTransform tSlotRectT = null;
        //하나의 슬롯 너비, 높이를 구해둠
        float tW = 1.0f;
        float tH = 1.0f;    //앵커 등이 펼쳐져 width, height 값이 0으로 설정되어 오류가 나는 경우를 방지
        tW = ((RectTransform)(PFSlotItem.transform)).sizeDelta.x;
        tH = ((RectTransform)(PFSlotItem.transform)).sizeDelta.y;

        int ti = 0; //순번을 지정할 인덱스
        //필요한 slot ui를 생성
        foreach (var t in tDic)
        {
            //아이템이 있는지 검사
            if (t.Value.Count > 0)
            {
                tSlot = null;
                //슬롯을 동적으로 생성
                //위치 기준은 소유자 List UI
                tSlot = Instantiate<CSlotItem>(PFSlotItem, this.transform.position, Quaternion.identity);

                //변환 계층 구조상 부모가 누구인지 설정한다.
                tSlot.transform.SetParent(this.transform);

                //slot ui의 외관을 설정
                tSlotRectT = null;
                tSlotRectT = (RectTransform)tSlot.transform;    //UI구성요소므로 RectTransform으로 다뤄야한다
                tSlotRectT.anchoredPosition = new Vector2(0f, 0f - ti * tH);    //위치 지정 left, top을 시작점으로 하여 y축 하방으로 달리도록 함
                tSlotRectT.sizeDelta = new Vector2(tW, tH); //동적생성된 슬롯의 너비, 높이 지정

                tSlot.transform.localScale = Vector3.one;   //크기는 각각의 축별로 1


                //data를 설정
                tSlot.SetItemData(t.Value[0]);  //같은 동류의 아이템이라면 모두 같다고 가정되어 있으므로 첫번째 아이템 정보를 얻어옴
                tSlot.SetItemCount(t.Value.Count);
                //가변배열의 원소의 개수를 세어 아이템 개수를 얻는다

                tSlot.SetList(this);    //소유자 설정

                mListSlots.Add(tSlot);  //만들어진 slot ui를 가변배열에 추가

                ++ti;   //순번 증가
            }
        }

        //instListItems의 높이 설정
        RectTransform tListRectT = null;
        tListRectT = this.transform as RectTransform; //이렇게도 형변환 가능
        //이 부분에서는 이미 ti에 슬롯 개수가 카운트되어 있으므로
        //아래와 같이 리스트의 높이를 구한다.
        tListRectT.sizeDelta = new Vector2(tW, tH * ti);

        //외관을 구성하는 작업이 모두 끝났음으로
        //slot ui의 구성을 구축한다
        foreach(var t in mListSlots)
        {
            t.BuildRyu();
        }
    }
}
