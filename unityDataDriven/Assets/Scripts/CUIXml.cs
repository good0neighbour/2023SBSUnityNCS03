using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class CUIXml : MonoBehaviour
{
    //xml������ ����غ���
    public TMPro.TMP_Text mpTxtXml = null;

    public CRyuStageInfoList mStageInfoBundle = null;


    // Start is called before the first frame update
    void Start()
    {
        mStageInfoBundle = new CRyuStageInfoList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //��ư �̺�Ʈ �ڵ鷯 �Լ�
    public void OnClickBtnLoadFromXml()
    {
        LoadFromXmlFile("stage_info_xml");
    }

    //Resources�����κ��� xml���� ������ �����͸� �ε��ϰ� �Ľ��ϴ� �Լ���.
    bool LoadFromXmlFile(string tFileName)
    {
        Debug.Log($"LoadFromXmlFile {tFileName}");

        //xml( '�ؽ�Ʈ ����', �ڱ⸸�� �±׸� ����� �ڱ⸸�� ������ ���� �� �ִ� �Ծ� )�ּ��� �ε��Ѵ�
        TextAsset tTextAsset = null;    //����Ƽ���� �ؽ�Ʈ ������ �ּ��� ���� �����ص� Ŭ����
        tTextAsset = Resources.Load<TextAsset>(tFileName);  //����Ƽ���� �غ��ص� ���� �߿� �ּ��� �ε��� �� �ִ� ����

        if (null == tTextAsset)
        {
            //�ּ� �ε� ����
            return false;
        }

        //�ּ� �ε� ����
        mpTxtXml.text = tTextAsset.text;    //�ε��� ������ ����غ���.



        //xml�����͸� �Ľ��Ѵ�(�뵵�� �°� �ؼ��Ѵ�)


        return true;
    }



}
