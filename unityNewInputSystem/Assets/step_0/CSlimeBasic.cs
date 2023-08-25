using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CSlimeBasic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void DoMove()
    //{
    //    Debug.Log("DoMove");
    //}

    //public void DoFire()
    //{
    //    Debug.Log("DoFire");
    //}


    Vector3 mVelocity = Vector3.zero;

    public void DoMove(InputAction.CallbackContext tContext)
    {
        if (tContext.phase == InputActionPhase.Performed)
        {
            Debug.Log("DoMove");
            //Vector2타입의 데이터를 얻는다. 이것은 액션에서 ControlType으로 설정한 것이다.
            Vector2 tVector2 = tContext.ReadValue<Vector2>();

            Debug.Log($"CSlimeBasic.DoMove: {tVector2.ToString()}");
            //입력에 의한 속도 산출
            mVelocity.z = tVector2.y;
            mVelocity.x = tVector2.x;
            mVelocity = mVelocity.normalized;
            mVelocity = mVelocity * 1f;//1유닛씩 이동
            //해당 속도로 이동
            this.transform.Translate(mVelocity, Space.World);
        }

    }

    public void DoFire(InputAction.CallbackContext tContext)
    {
        if (tContext.phase == InputActionPhase.Performed)
        {
            Debug.Log("DoFire");
        }
    }


}
