/*


Audio Source ������Ʈ:
    ������ ����� ������ ������Ʈ
    �Ҹ��� ����

    Spatial Blend
        2D<------->3D
        2D�� �׳� �׻� �鸰��
        3D�� ������ �ش� ������ û���� ��ġ�� ������ �޴´�
            <--������ ũ��, �ָ� �۰� �鸰��


Audio Listener ������Ʈ:
    û���� ����� ������ ������Ʈ
    �Ҹ��� ��´�


===========================================================

AudioMixer�ּ�
: AudioSource�� AudioListener ���̿� ��ġ�Ѵ�.
    <----- AudioSource�� ������ ������ ������ ���ϱ� ���� �ܰ�μ� �غ�Ǿ���.

    <----- N���� group�� �����̴�.
    <----- AudioSource�� group�� ������ �� �ִ�.
    <----- Master Group�� �⺻���� ���õȴ�.
    <----- Group�� Ŀ�����ϰ� �ۼ��� �� �ִ�.
    <----- ��� group�� Master group���� �Ͱ�ȴ�.

group: AudioMixer�� ������Ҵ�.
            ������ ȿ���� �����̴�.

snapshot: ���� AudioMixer�� ��� �׷��� ��� ȿ����
            �����Ͱ��� ����
            �� ���� ����

view: ������ �׷��� ���ü� ���ο� ���� ������.( ������ ���� ����̴� )


====================================
ducking
: �����ؾ��� ������� ���� �� �ٸ� ������� ������ ���̴� ȿ���� ���Ѵ�.

��) �����̼� ������� �����ϱ� ���� ��������� ������ ���δ�.
    �����Ÿ��� ���ڱ� �Ҹ��� �����ϱ� ���� ���Ҹ�ȯ������ ������ ���δ�

*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class memo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
