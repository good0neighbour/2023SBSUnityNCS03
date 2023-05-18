using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//for UI Toolkit
using UnityEngine.UIElements;

public class CUIDocPlatGame : MonoBehaviour
{
    //��ũ��Ʈ���� ������ ��ư ��ü�� �غ�
    Button mBtnTest = null;


    [SerializeField]
    GameObject mDx = null;

    //��ũ��Ʈ���� ������ ��ü�� �غ�
    VisualElement mBg = null;

    // Start is called before the first frame update
    void Start()
    {
        //uxml������ �ֻ�ܷ�Ʈ�� ��´�. �̰��� uxml������ �߻�ȭ�س��� ���̴�.
        var tRoot = GetComponent<UIDocument>().rootVisualElement;
        //�������� ��ư ��ü�� �˻��Ͽ� ��´�
        mBtnTest = tRoot.Q<Button>("instBtnTest");

        //�������� ��ü�� �˻��Ͽ� ��´�
        mBg = tRoot.Q<VisualElement>("bg");

        //����� �ο�����
        mBtnTest.RegisterCallback<ClickEvent>(OnClickBtnTest);
    }

    void OnClickBtnTest(ClickEvent t)
    {
        if (mBtnTest != null)
        {
            //Debug.Log("CUIDocPlayGame.OnClickBtnTest");

            //�ش� UIDocument���ӿ�����Ʈ�� ��Ȱ��ȭ�غ���
            //this.gameObject.SetActive(false);


            //mBg�� ���ü��� �������� (���⼭�� �Ⱥ��̰� �Ѵ� )
            //mBg.style.display = DisplayStyle.None;

            //��ȭ���� show
            mDx.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
