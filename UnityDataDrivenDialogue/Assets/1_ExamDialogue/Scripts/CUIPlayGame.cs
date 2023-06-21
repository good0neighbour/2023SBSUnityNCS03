using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIPlayGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //애셋이므로 확장자는 표기하지 않는다
        CDataMgr.GetInst().LoadDialogueInfos("dialogue_list");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
