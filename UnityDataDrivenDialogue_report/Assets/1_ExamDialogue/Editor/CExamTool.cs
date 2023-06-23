using System.Collections;
using System.Collections.Generic;

using UnityEditor;

using UnityEngine;

using System;
using System.IO;
using System.Xml;


public class CExamTool : EditorWindow
{
    //'N개의 대사'를 관리하는 자료구조
    List<CDialogueInfo> mDialogueInfos = null;

    //새로운 대사 카운트용 변수
    int mCurCount = 0;

    [MenuItem("CExamEditor/Show CExamTool")]
    public static void ShowRyu()
    {
        Debug.Log("CExamEditor.ShowRyu");

        //reflection문법: 실행중에 해당 타입에 대한 정보를 얻는 문법이다.
        //              typeof 실행중에 해당 타입에 대한 정보를 얻는 연산자
        EditorWindow.GetWindow(typeof(CExamTool));

        //유니티 에디터 갱신
        EditorApplication.update();
    }

    private void OnEnable()
    {
        Debug.Log("CExamTool.OnEnable");

        if (null == mDialogueInfos)
        {
            //자료구조를 생성
            mDialogueInfos = new List<CDialogueInfo>();
        }

    }
    private void OnGUI()
    {
        //edit ui
        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("edit...", EditorStyles.helpBox);

        GUILayout.Space(10);
        //대사 추가 메뉴
        if (GUILayout.Button("Add a Dialogue", GUILayout.Width(100f), GUILayout.Height(50f)))
        {
            //새로운 대사 정보
            CDialogueInfo tInfo = null;
            tInfo = new CDialogueInfo();
            tInfo.mId = mCurCount;
            tInfo.mDialogue = $"{mCurCount.ToString()}번째 대화입니다.";

            //자료구조에 추가
            mDialogueInfos.Add(tInfo);

            ++mCurCount;
        }
        GUILayout.Space(2);
        if (GUILayout.Button("NEW", GUILayout.Width(100f), GUILayout.Height(50f)))
        {
            //메모리에 있는 대사 정보를 모두 삭제한다
            for (int ti = 0; ti < mDialogueInfos.Count; ++ti)
            {
                mDialogueInfos[ti] = null;
            }
            mDialogueInfos.Clear();

            //유니티 에디터 갱신
            EditorApplication.update();
        }
        GUILayout.Space(2);
        if (GUILayout.Button("Load From File", GUILayout.Width(100f), GUILayout.Height(50f)))
        {
            LoadFromFile("Assets/Resources/dialogue_list.xml");

            //유니티 에디터 갱신
            EditorApplication.update();
        }
        GUILayout.Space(2);
        if (GUILayout.Button("Save To File", GUILayout.Width(100f), GUILayout.Height(50f)))
        {
            //이 Tool에서는 파일을 만들어 저장할 것이다
            //'파일' 개념으로 다룰 것이기 때문에
            //          i) '경로'를 다 명시하였고
            //          ii) '확장자'도 명시하였다.
            SaveToFile("Assets/Resources/dialogue_list.xml");

            //애셋데이터베이스를 갱신
            AssetDatabase.Refresh();
            //유니티는 애셋정보를 관리하는 데이터베이스 개념을 가지고 있다.
            //Library폴더에 ArtifactDB, SourceAssetDB가 그 주요한 데이터다.
            // 이 두 가지를 관리하는 주체가 되는 클래스가 AssetDataBase다.

            //여기서는 파일을 새로 만들어 Assets폴더에 두었으므로
            //파일이 입포트되어 애셋화가 되었다고 가정한다.
            //그래서 AssetDatabase를 갱신해주었다.


            //유니티 에디터 갱신
            EditorApplication.update();
        }



        EditorGUILayout.EndVertical();



        //diplay UI
        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("DIALOGUE S", EditorStyles.helpBox);

        GUILayout.Space(10);

        //N개의 대사
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
            //파일이 존재하지 않으면
            //로드 실패

            Debug.Log("faliure, Load from file");

            return;
        }

        //파일이 존재한다
        XmlDocument tDoc = new XmlDocument();
        tDoc.Load(tFileName);

        XmlElement tElementRoot = tDoc["DialogueInfoList"];


        int ti = 0; //카운트용 변수
        int tCount = tElementRoot.ChildNodes.Count;  //xml의 노드에 총 대사 개수

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


    //대사정보를 xml 파일로 저장한다
    void SaveToFile(string tFileName)
    {
        //---파일을 만든다---
        //파일에 쓰기할 데이터를 '흐르는 데이터'개념으로 다루기 위한 클래스
        StreamWriter tStreamWriter = null;

        //System.IO
        FileInfo tFileInfo = new FileInfo(tFileName);
        if (tFileInfo.Exists)
        {
            //파일이 존재하면, 지우고 새로 만든다
            tFileInfo.Delete();
            tStreamWriter = tFileInfo.CreateText();
        }
        else
        {
            //파일이 존재하지 않으면, 새로 만든다
            tStreamWriter = tFileInfo.CreateText();
        }
        tStreamWriter.Close();

        //---xml형태로 저장한다---
        XmlDocument tDoc = new XmlDocument();   //XML문서객체 생성
        XmlElement tElementRoot = tDoc.CreateElement("DialogueInfoList"); //루트 노드 생성
        tDoc.AppendChild(tElementRoot); //문서에 루트노드 추가

        int ti = 0; //카운트용 변수
        int tCount = mDialogueInfos.Count;  //총 대사 개수

        CDialogueInfo tInfo = null;
        XmlElement tElement_0 = null;
        //xml형식으로 계층구조를 만듦
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

        tDoc.Save(tFileName);   //XmlDocument의 기능을 이용하여 파일로 저장

    }
}
