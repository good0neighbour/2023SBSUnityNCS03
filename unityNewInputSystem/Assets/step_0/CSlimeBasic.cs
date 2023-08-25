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
            //Vector2Ÿ���� �����͸� ��´�. �̰��� �׼ǿ��� ControlType���� ������ ���̴�.
            Vector2 tVector2 = tContext.ReadValue<Vector2>();

            Debug.Log($"CSlimeBasic.DoMove: {tVector2.ToString()}");
            //�Է¿� ���� �ӵ� ����
            mVelocity.z = tVector2.y;
            mVelocity.x = tVector2.x;
            mVelocity = mVelocity.normalized;
            mVelocity = mVelocity * 1f;//1���־� �̵�
            //�ش� �ӵ��� �̵�
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
