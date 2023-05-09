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
    }
}
