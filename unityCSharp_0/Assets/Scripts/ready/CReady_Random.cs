using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    난수

*/

//MonoBehaviour를 상속
//MonoBehaviour 게임오브젝트에 부착할 스크립트 컴포넌트는 이 클래스를 상속받아야 한다
public class CReady_Random : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int tDice = 0;

        tDice = DoRollDice();

        Debug.Log("DoRollDice: " + tDice.ToString());
    }

    //Update Method(함수) 패턴이 적용된 것이다
    //  한 프레임에 일어나는 게임오브젝트의 동작을 함수로 만들어 놓은 것

    // Update is called once per frame
    void Update()
    {
        
    }

    public int DoRollDice()
    {
        int tResult = 0;
        //UnityEngine에 Random클래스
        tResult = Random.Range(1, 6 + 1);

        return tResult;
    }


}
