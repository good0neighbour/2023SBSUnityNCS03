using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//for UI Toolkit
using UnityEngine.UIElements;

public class CDx : MonoBehaviour
{
    //스크립트에서 제어할 버튼 객체를 준비
    Button mBtnClose = null;


    //TransitionAnimation을 적용할 UI구성요소
    VisualElement mOneSlot = null;


    // Start is called before the first frame update
    void Start()
    {
        //var tRoot = GetComponent<UIDocument>().rootVisualElement;
        ////문서에서 버튼 객체를 검색하여 얻는다
        //mBtnClose = tRoot.Q<Button>("instBtnClose");

        ////기능을 부여하자
        //mBtnClose.RegisterCallback<ClickEvent>(OnClickBtnClose);
    }
    //게임오브젝트가 활성될 때 호출
    private void OnEnable()
    {
        var tRoot = GetComponent<UIDocument>().rootVisualElement;
        //문서에서 버튼 객체를 검색하여 얻는다
        mBtnClose = tRoot.Q<Button>("instBtnClose");

        //기능을 부여하자
        //콜백함수 등록 <-- 자원을 사용
        mBtnClose.RegisterCallback<ClickEvent>(OnClickBtnClose);

        Debug.Log("OnEnable");


        mOneSlot = tRoot.Q<VisualElement>("instOneSlot");

        Invoke("OnApear", 0.1f);
    }
    void OnApear()
    {
        mOneSlot.AddToClassList("dxHide");
    }



    //게임오브젝트가 비활성될 때 호출
    private void OnDisable()
    {
        //콜백함수 등록 해제 <-- 사용한 자원을 해제
        mBtnClose.UnregisterCallback<ClickEvent>(OnClickBtnClose);

        Debug.Log("OnDisable");
    }

    void OnClickBtnClose(ClickEvent t)
    {
        if (mBtnClose != null)
        {
            mOneSlot.RemoveFromClassList("dxHide");
            mOneSlot.AddToClassList("dxShow");

            //트랜지션 애니메이션의 종료 시점에 호출할 함수 등록
            mOneSlot.RegisterCallback<TransitionEndEvent>(OnEndAni);
        }
    }

    void OnEndAni(TransitionEndEvent t)
    {
        this.gameObject.SetActive(false);

        mOneSlot.UnregisterCallback<TransitionEndEvent>(OnEndAni);
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
