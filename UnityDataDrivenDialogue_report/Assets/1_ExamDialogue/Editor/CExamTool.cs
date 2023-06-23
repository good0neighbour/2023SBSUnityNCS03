using System.Collections;
using System.Collections.Generic;

using UnityEditor;

using UnityEngine;

using System;
using System.IO;
using System.Xml;


public class CExamTool : EditorWindow
{
    //'N���� ���'�� �����ϴ� �ڷᱸ��
    List<CDialogueInfo> mDialogueInfos = null;

    //���ο� ��� ī��Ʈ�� ����
    int mCurCount = 0;

    [MenuItem("CExamEditor/Show CExamTool")]
    public static void ShowRyu()
    {
        Debug.Log("CExamEditor.ShowRyu");

        //reflection����: �����߿� �ش� Ÿ�Կ� ���� ������ ��� �����̴�.
        //              typeof �����߿� �ش� Ÿ�Կ� ���� ������ ��� ������
        EditorWindow.GetWindow(typeof(CExamTool));

        //����Ƽ ������ ����
        EditorApplication.update();
    }

    private void OnEnable()
    {
        Debug.Log("CExamTool.OnEnable");

        if (null == mDialogueInfos)
        {
            //�ڷᱸ���� ����
            mDialogueInfos = new List<CDialogueInfo>();
        }

    }
    private void OnGUI()
    {
        //edit ui
        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("edit...", EditorStyles.helpBox);

        GUILayout.Space(10);
        //��� �߰� �޴�
        if (GUILayout.Button("Add a Dialogue", GUILayout.Width(100f), GUILayout.Height(50f)))
        {
            //���ο� ��� ����
            CDialogueInfo tInfo = null;
            tInfo = new CDialogueInfo();
            tInfo.mId = mCurCount;
            tInfo.mDialogue = $"{mCurCount.ToString()}��° ��ȭ�Դϴ�.";

            //�ڷᱸ���� �߰�
            mDialogueInfos.Add(tInfo);

            ++mCurCount;
        }
        GUILayout.Space(2);
        if (GUILayout.Button("NEW", GUILayout.Width(100f), GUILayout.Height(50f)))
        {
            //�޸𸮿� �ִ� ��� ������ ��� �����Ѵ�
            for (int ti = 0; ti < mDialogueInfos.Count; ++ti)
            {
                mDialogueInfos[ti] = null;
            }
            mDialogueInfos.Clear();

            //����Ƽ ������ ����
            EditorApplication.update();
        }
        GUILayout.Space(2);
        if (GUILayout.Button("Load From File", GUILayout.Width(100f), GUILayout.Height(50f)))
        {
            LoadFromFile("Assets/Resources/dialogue_list.xml");

            //����Ƽ ������ ����
            EditorApplication.update();
        }
        GUILayout.Space(2);
        if (GUILayout.Button("Save To File", GUILayout.Width(100f), GUILayout.Height(50f)))
        {
            //�� Tool������ ������ ����� ������ ���̴�
            //'����' �������� �ٷ� ���̱� ������
            //          i) '���'�� �� ����Ͽ���
            //          ii) 'Ȯ����'�� ����Ͽ���.
            SaveToFile("Assets/Resources/dialogue_list.xml");

            //�ּµ����ͺ��̽��� ����
            AssetDatabase.Refresh();
            //����Ƽ�� �ּ������� �����ϴ� �����ͺ��̽� ������ ������ �ִ�.
            //Library������ ArtifactDB, SourceAssetDB�� �� �ֿ��� �����ʹ�.
            // �� �� ������ �����ϴ� ��ü�� �Ǵ� Ŭ������ AssetDataBase��.

            //���⼭�� ������ ���� ����� Assets������ �ξ����Ƿ�
            //������ ����Ʈ�Ǿ� �ּ�ȭ�� �Ǿ��ٰ� �����Ѵ�.
            //�׷��� AssetDatabase�� �������־���.


            //����Ƽ ������ ����
            EditorApplication.update();
        }



        EditorGUILayout.EndVertical();



        //diplay UI
        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("DIALOGUE S", EditorStyles.helpBox);

        GUILayout.Space(10);

        //N���� ���
        for (int ti = 0; ti < mDialogueInfos.Count; ++ti)
        {
            //display id
            EditorGUILayout.LabelField(mDialogueInfos[ti].mId.ToString(), EditorStyles.helpBox);
            //display and edit dialogue
            mDialogueInfos[ti].mDialogue = EditorGUILayout.TextField(mDialogueInfos[ti].mDialogue);
        }


        EditorGUILayout.EndVertical();
    }

    void LoadFromFile(string tFileName)
    {
        FileInfo tFileInfo = new FileInfo(tFileName);
        if (false == tFileInfo.Exists)
        {
            //������ �������� ������
            //�ε� ����

            Debug.Log("faliure, Load from file");

            return;
        }

        //������ �����Ѵ�
        XmlDocument tDoc = new XmlDocument();
        tDoc.Load(tFileName);

        XmlElement tElementRoot = tDoc["DialogueInfoList"];


        int ti = 0; //ī��Ʈ�� ����
        int tCount = tElementRoot.ChildNodes.Count;  //xml�� ��忡 �� ��� ����

        CDialogueInfo tInfo = null;
        XmlElement tElement_0 = null;

        for (ti = 0; ti < tCount; ++ti)
        {
            tElement_0 = null;
            tElement_0 = tElementRoot.ChildNodes[ti] as XmlElement;

            tInfo = null;
            tInfo = new CDialogueInfo();

            tInfo.mId = System.Convert.ToInt32(tElement_0.ChildNodes[0].InnerText);
            tInfo.mDialogue = tElement_0.ChildNodes[1].InnerText;

            mDialogueInfos.Add(tInfo);
        }
    }


    //��������� xml ���Ϸ� �����Ѵ�
    void SaveToFile(string tFileName)
    {
        //---������ �����---
        //���Ͽ� ������ �����͸� '�帣�� ������'�������� �ٷ�� ���� Ŭ����
        StreamWriter tStreamWriter = null;

        //System.IO
        FileInfo tFileInfo = new FileInfo(tFileName);
        if (tFileInfo.Exists)
        {
            //������ �����ϸ�, ����� ���� �����
            tFileInfo.Delete();
            tStreamWriter = tFileInfo.CreateText();
        }
        else
        {
            //������ �������� ������, ���� �����
            tStreamWriter = tFileInfo.CreateText();
        }
        tStreamWriter.Close();

        //---xml���·� �����Ѵ�---
        XmlDocument tDoc = new XmlDocument();   //XML������ü ����
        XmlElement tElementRoot = tDoc.CreateElement("DialogueInfoList"); //��Ʈ ��� ����
        tDoc.AppendChild(tElementRoot); //������ ��Ʈ��� �߰�

        int ti = 0; //ī��Ʈ�� ����
        int tCount = mDialogueInfos.Count;  //�� ��� ����

        CDialogueInfo tInfo = null;
        XmlElement tElement_0 = null;
        //xml�������� ���������� ����
        for (ti = 0; ti < tCount; ++ti)
        {
            tInfo = mDialogueInfos[ti];

            XmlElement tElement = tDoc.CreateElement("DialogueInfo");

            tElement_0 = null;
            tElement_0 = tDoc.CreateElement("mId");
            tElement_0.InnerText = tInfo.mId.ToString();
            tElement.AppendChild(tElement_0);

            tElement_0 = null;
            tElement_0 = tDoc.CreateElement("mDialogue");
            tElement_0.InnerText = tInfo.mDialogue;
            tElement.AppendChild(tElement_0);

            tElementRoot.AppendChild(tElement);
        }

        tDoc.Save(tFileName);   //XmlDocument�� ����� �̿��Ͽ� ���Ϸ� ����

    }
}
