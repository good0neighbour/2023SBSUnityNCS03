using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CActor : MonoBehaviour
{
    //������ ��ũ
    [SerializeField]
    CBullet PFBullet = null;



    float mHorizontal = 0f;
    float mVertical = 0f;

    [SerializeField]    //����Ƽ ������ �� ������Ѽ� ���� �����غ��� ���� <--���� �ݺ������� ����
    float tScalarSpeed = 0f;   //�ӷ�
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Input.GetAxis ���ӵ� ������ ��, ���� �Ǵ�(��ȭ�Ǵ�) ���·� ���� ���´�.
        //mHorizontal = Input.GetAxis("Horizontal");  //[-1, 1]
        //mVertical = Input.GetAxis("Vertical");      //[-1, 1]

        //Input.GetAxisRaw �ҿ��ӵ� ���� ���·� ���´�.
        mHorizontal = Input.GetAxisRaw("Horizontal");  //[-1, 1]
        mVertical = Input.GetAxisRaw("Vertical");      //[-1, 1]

        //Debug.Log(mVertical.ToString());

        if (Input.GetKeyUp(KeyCode.Space))
        {
            //źȯ ���� ������Ʈ�� �������� ����
            //��� ���� ���������� ��Ƶ�
            CBullet tBullet = Instantiate<CBullet>(PFBullet, this.transform.position, Quaternion.identity);

            //Physics2D: Unity2D�� ������� �̿�
            //unity������ ���� 1unit�� 1m, mass 1�� 1kg, �ð��� 1sec
            tBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
            //ForceMode2D.Impulse ����� ���� �ش� ������ �������� ��� �ְ� �ʹٸ� �� ��带 ���� �ȴ�
            //  vs ForceMode2D.Force�� 1�ʿ� ������ �ִ� �ɼ��̴�.<-- ���� ���� ����
            //F = ma
        }




        //������ ���� ���ϱ�
        //������ ��Į�� ����, ���ͳ����� ����, ��ī��Ʈ ��
        //������ ũ���� ������ ������ ����
        Vector3 tVelocity = Vector3.right * mHorizontal + Vector3.up * mVertical;
        tVelocity = tVelocity.normalized;   //������ ����ȭ

        //�ð���� ����, ������ǥ�� ����
        this.transform.Translate(tVelocity * tScalarSpeed * Time.deltaTime, Space.Self);

    }
}
