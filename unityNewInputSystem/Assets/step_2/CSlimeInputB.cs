using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSlimeInputB : MonoBehaviour
{
    InputActions_ActionMaps mInputActions = null;

    Vector3 mVelocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        mInputActions = new InputActions_ActionMaps();//<--�ش� ��ǲ�׼��� ��ü�� ����
        mInputActions.ActionMapsSlimeB.DoMoveForwardAxis.Enable();
        //<--�ش� �׼��� Ȱ��ȭ
        mInputActions.ActionMapsSlimeB.DoMoveRotate.Enable();
        //<--�ش� �׼��� Ȱ��ȭ
    }

    // Update is called once per frame
    void Update()
    {
        //�������� �Է�üũ�� ���� Update�� �ۼ�
        float tScalar = mInputActions.ActionMapsSlimeB.DoMoveForwardAxis.ReadValue<float>();

        mVelocity = this.transform.forward;
        mVelocity = mVelocity * tScalar * 10f * Time.deltaTime;//1���־� �̵�
                                                               //�ش� �ӵ��� �̵�
        this.transform.Translate(mVelocity, Space.World);

        //�Է¿� ���� �¿� ��ȸ
        float tScalarRotate = mInputActions.ActionMapsSlimeB.DoMoveRotate.ReadValue<float>();
        this.transform.Rotate(Vector3.up, tScalarRotate * 100f * Time.deltaTime);
    }

    void OnDoFire()
    {
        Debug.Log("CSlimeInputA.OnDoFire");
    }
}
