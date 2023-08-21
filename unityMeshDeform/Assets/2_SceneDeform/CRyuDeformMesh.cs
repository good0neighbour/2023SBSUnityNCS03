using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRyuDeformMesh : MonoBehaviour
{
    MeshFilter mMeshFilter = null;

    //���� �޽�(������ ����)�� �����Ͽ� ���ο� �޽�(������ ����)�� �����
    //�̸� �޽� ���Ϳ� �����Ͽ�
    //'�޽� ����(������ ��ġ �̵�)'�� ǥ���� ���̴�
    Vector3[] mOriginVerts = null;  //���ӿ�����Ʈ�� �޽��� ���� ������ ����
    Vector3[] mNewVerts = null;     //������ ���� ���Ӱ� ������� �޽��� ������ ����

    Matrix4x4 mMatrix = Matrix4x4.identity; //�̵���ȯ�� �����ϱ� ���� ��ȯ���


    //���� �߻��ϴ� ���� ������Ʈ
    [SerializeField]
    GameObject mpForceObj = null;


    private void OnGUI()
    {
        //������ ������ �̵���ȯ�� '�����ϰ� �׽�Ʈ'�غ���.
        if (GUI.Button(new Rect(0f, 0f, 100f, 100f), "Test Translate\nAnyVertices"))
        {
            mMeshFilter = this.GetComponent<MeshFilter>();

            mOriginVerts = mMeshFilter.mesh.vertices;//�޽����ͷκ��� ������ ������ ��´�

            //���� ������ ������ŭ ���ο� ������ ������ Ȯ���Ѵ�.
            mNewVerts = new Vector3[mOriginVerts.Length];

            //������ ������ �����ϴ� ������ �����غ���.

            Matrix4x4 tM = Matrix4x4.identity;
            //(1,0,0)offset���� �̵���ȯ ���
            tM.SetTRS(Vector3.right, Quaternion.identity, Vector3.one);

            for (int ti = 0; ti < mOriginVerts.Length; ++ti)
            {
                if (mOriginVerts[ti].z >= 0.5f)
                {
                    //�̵���ȯ
                    mMatrix = tM;
                }
                else
                {
                    //�������
                    mMatrix = Matrix4x4.identity;
                }
                //�຤�� ���� ����� ����
                mNewVerts[ti] = mMatrix.MultiplyPoint3x4(mOriginVerts[ti]);
            }
            //���Ӱ� ���� ����� ���ο� ���� �����͸� �޽��� ����
            mMeshFilter.mesh.vertices = mNewVerts;
        }

        //force�� �����Ͽ� ����
        if (GUI.Button(new Rect(200f, 0f, 100f, 100f), "Apply Force"))
        {
            mMeshFilter = this.GetComponent<MeshFilter>();

            mOriginVerts = mMeshFilter.mesh.vertices;
            mNewVerts = new Vector3[mOriginVerts.Length];

            Matrix4x4 tM = Matrix4x4.identity;

            for (int ti = 0; ti < mOriginVerts.Length; ++ti)
            {
                //---- ������ ������ ������ ���� ���� ----
                //������ ũ���� ������ ���� = �������� - ��������
                Vector3 tA = mpForceObj.transform.position;     //��������: force ������Ʈ�� �߽��� ��ġ ����
                Vector3 tB = mOriginVerts[ti];                  //��������: �޽��� ������ ����

                //force object �߽�����ġ�� �޽��� ������ ���� ������ �Ÿ�
                float tDistance = Vector3.Distance(tB, tA);
                Vector3 tVectorTrans = tB - tA; //������ ������ ��ġ�� force�߻�(�߽���--->������ ����) ����

                float tRadius = mpForceObj.gameObject.GetComponent<SphereCollider>().radius;
                float tPower = tRadius * 2f * mpForceObj.gameObject.transform.lossyScale.x;
                float tScalar = (1f / tVectorTrans.magnitude) * tPower;//���� �޴� ���� �ݺ�ʽ�Ŵ, �� ����
                //<--�ָ� ������ ���� ���� ���� �� ����

                //-- ������ ������ ���� ���� --
                tM.SetTRS(tVectorTrans.normalized * tScalar, Quaternion.identity, Vector3.one);
                mMatrix = tM;
                mNewVerts[ti] = mMatrix.MultiplyPoint3x4(mOriginVerts[ti]);
            }

            //���Ӱ� ���� ����� ���ο� ���� �����͸� �޽��� ����
            mMeshFilter.mesh.vertices = mNewVerts;
        }

        //force�� �����Ͽ� ����
        if (GUI.Button(new Rect(300f, 0f, 100f, 100f), "Apply Force Back"))
        {
            mMeshFilter = this.GetComponent<MeshFilter>();

            mOriginVerts = mMeshFilter.mesh.vertices;
            mNewVerts = new Vector3[mOriginVerts.Length];

            Matrix4x4 tM = Matrix4x4.identity;

            for (int ti = 0; ti < mOriginVerts.Length; ++ti)
            {
                //---- ������ ������ ������ ���� ���� ----
                //������ ũ���� ������ ���� = �������� - ��������
                Vector3 tA = mpForceObj.transform.position;     //��������: force ������Ʈ�� �߽��� ��ġ ����
                Vector3 tB = mOriginVerts[ti];                  //��������: �޽��� ������ ����

                //force object �߽�����ġ�� �޽��� ������ ���� ������ �Ÿ�
                float tDistance = Vector3.Distance(tB, tA);
                Vector3 tVectorTrans = tA - tB; //������ ������ ��ġ�� force����(�߽���--->������ ����) ����

                float tRadius = mpForceObj.gameObject.GetComponent<SphereCollider>().radius;
                float tPower = tRadius * 2f * mpForceObj.gameObject.transform.lossyScale.x;
                float tScalar = (1f / tVectorTrans.magnitude) * tPower;//���� �޴� ���� �ݺ�ʽ�Ŵ, �� ����
                //<--�ָ� ������ ���� ���� ���� �� ����

                //-- ������ ������ ���� ���� --
                tM.SetTRS(tVectorTrans.normalized * tScalar, Quaternion.identity, Vector3.one);
                mMatrix = tM;
                mNewVerts[ti] = mMatrix.MultiplyPoint3x4(mOriginVerts[ti]);
            }

            //���Ӱ� ���� ����� ���ο� ���� �����͸� �޽��� ����
            mMeshFilter.mesh.vertices = mNewVerts;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
