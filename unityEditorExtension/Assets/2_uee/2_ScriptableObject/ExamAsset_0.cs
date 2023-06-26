using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    ScriptableObject 클래스는
    '독자적인 사용자 정의 Asset을 작성'할 수 있는 클래스다.

    <-- 유니티에서 제공하므로 당연히 Serialize기능은 가지고 있다.


    만드는 방법:
    ScriptableObject를 상속받은 클래스로 스크립트를 작성하고
    이 클래스에 CreateAssetMenu속성을 적용하여 만들었다.
*/

[CreateAssetMenu(menuName = "Example/Create ExamAsset_0")]
public class ExamAsset_0 : ScriptableObject///<--상속
{
    public int mA = 777;
}
