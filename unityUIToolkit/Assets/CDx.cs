using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//for UI Toolkit
using UnityEngine.UIElements;

public class CDx : MonoBehaviour
{
    //��ũ��Ʈ���� ������ ��ư ��ü�� �غ�
    Button mBtnClose = null;


    //TransitionAnimation�� ������ UI�������
    VisualElement mOneSlot = null;


    // Start is called before the first frame update
    void Start()
    {
        //var tRoot = GetComponent<UIDocument>().rootVisualElement;
        ////�������� ��ư ��ü�� �˻��Ͽ� ��´�
        //mBtnClose = tRoot.Q<Button>("instBtnClose");

        ////����� �ο�����
        //mBtnClose.RegisterCallback<ClickEvent>(OnClickBtnClose);
    }
    //���ӿ�����Ʈ�� Ȱ���� �� ȣ��
    private void OnEnable()
    {
        var tRoot = GetComponent<UIDocument>().rootVisualElement;
        //�������� ��ư ��ü�� �˻��Ͽ� ��´�
        mBtnClose = tRoot.Q<Button>("instBtnClose");

        //����� �ο�����
        //�ݹ��Լ� ��� <-- �ڿ��� ���
        mBtnClose.RegisterCallback<ClickEvent>(OnClickBtnClose);

        Debug.Log("OnEnable");


        mOneSlot = tRoot.Q<VisualElement>("instOneSlot");

        Invoke("OnApear", 0.1f);
    }
    void OnApear()
    {
        mOneSlot.AddToClassList("dxHide");
    }



    //���ӿ�����Ʈ�� ��Ȱ���� �� ȣ��
    private void OnDisable()
    {
        //�ݹ��Լ� ��� ���� <-- ����� �ڿ��� ����
        mBtnClose.UnregisterCallback<ClickEvent>(OnClickBtnClose);

        Debug.Log("OnDisable");
    }

    void OnClickBtnClose(ClickEvent t)
    {
        if (mBtnClose != null)
        {
            mOneSlot.RemoveFromClassList("dxHide");
            mOneSlot.AddToClassList("dxShow");

            //Ʈ������ �ִϸ��̼��� ���� ������ ȣ���� �Լ� ���
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
