using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPChar : MonoBehaviour
{
    //ĳ������ �̵��� ����ϴ� ������Ʈ
    [SerializeField]
    CharacterController mCharController = null;

    //���� �ӵ�
    Vector3 mVecDir = Vector3.zero;

    //zx��鿡���� �̵�
    [SerializeField]
    float mScarlarSpeed = 0f;   //zx��鿡���� �ӷ�

    //y�࿡���� �̵�
    [SerializeField]
    float GRAVITY = -9.8f;  //�߷°��ӵ�(�ӷ�)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!mCharController)
        {
            return;
        }

        if (mCharController.isGrounded)
        {
            //was...touching ground..when last moving

            //zx��鿡���� �̵�
            float tV = Input.GetAxis("Vertical");   //[-1, 1] �������� ��
            float tH = Input.GetAxis("Horizontal"); //[-1, 1] �������� ��

            //tV�� z�� ��ҷ�, tH�� x�� ��ҷ�, y�� ��Ҵ� �������� ����
            Vector3 tVelocity = new Vector3(tH, 0f, tV);

            //������ǥ������ ���� = TransformDirection(������ǥ������ ����)
            mVecDir = mCharController.transform.TransformDirection(tVelocity);

            //�ӵ� ����
            /*
                ���Ϸ� ������ ����� ���� �ӵ�, ��ġ ���ϱ�

                Azx = 0
                Vzx = Vzx + Azx * t

                Szx = Szx + Vzx * t
            */
            mVecDir = mVecDir * mScarlarSpeed;
        }
        else
        {
            //y�� �߷°��ӵ� �

            //�ӵ� ����
            /*
                ���Ϸ� ������ ����� ���� �ӵ�, ��ġ ���ϱ�

                Ay = GRAVITY
                Vy = Vy + Ay * t
                Sy = Sy + Vy * t
            */

            mVecDir.y = mVecDir.y + GRAVITY * Time.deltaTime;
        }


        //������ �ӵ��� �̵�, �ð���� ����( CharacterController������Ʈ�� ����� �̿� )
        mCharController.Move(mVecDir * Time.deltaTime);
    }
}
