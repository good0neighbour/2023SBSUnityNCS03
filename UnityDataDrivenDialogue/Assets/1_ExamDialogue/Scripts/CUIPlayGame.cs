using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIPlayGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //�ּ��̹Ƿ� Ȯ���ڴ� ǥ������ �ʴ´�
        CDataMgr.GetInst().LoadDialogueInfos("dialogue_list");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
