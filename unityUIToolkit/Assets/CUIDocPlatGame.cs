using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//for UI Toolkit
using UnityEngine.UIElements;

public class CUIDocPlatGame : MonoBehaviour
{
    //스크립트에서 제어할 버튼 객체를 준비
    Button mBtnTest = null;


    [SerializeField]
    GameObject mDx = null;

    //스크립트에서 제어할 객체를 준비
    VisualElement mBg = null;

    // Start is called before the first frame update
    void Start()
    {
        //uxml문서의 최상단루트를 얻는다. 이것은 uxml문서를 추상화해놓은 것이다.
        var tRoot = GetComponent<UIDocument>().rootVisualElement;
        //문서에서 버튼 객체를 검색하여 얻는다
        mBtnTest = tRoot.Q<Button>("instBtnTest");

        //문서에서 객체를 검색하여 얻는다
        mBg = tRoot.Q<VisualElement>("bg");

        //기능을 부여하자
        mBtnTest.RegisterCallback<ClickEvent>(OnClickBtnTest);
    }

    void OnClickBtnTest(ClickEvent t)
    {
        if (mBtnTest != null)
        {
            //Debug.Log("CUIDocPlayGame.OnClickBtnTest");

            //해당 UIDocument게임오브젝트를 비활성화해본다
            //this.gameObject.SetActive(false);


            //mBg의 가시성을 제어하자 (여기서는 안보이게 한다 )
            //mBg.style.display = DisplayStyle.None;

            //대화상자 show
            mDx.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
