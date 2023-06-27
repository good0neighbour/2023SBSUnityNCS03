using UnityEngine;

public class CFollowCamera : MonoBehaviour
{
    [SerializeField] private Vector3 mPositionOffset = Vector3.zero;
    [SerializeField] private Vector3 mLookAtOffset = Vector3.zero;
    [SerializeField] private Transform mActor = null;

    private void Update()
    {
        // 카메라 위치
        transform.localPosition = mActor.localPosition + mActor.rotation * mPositionOffset;

        // 카메라 회전
        Vector3 tGap = mActor.localPosition + mLookAtOffset - transform.localPosition;
        Vector3 tRadian = new Vector3(Mathf.Atan(tGap.y / tGap.z), Mathf.Atan(tGap.z / tGap.x), Mathf.Atan(tGap.y / tGap.x));
        transform.localRotation = Quaternion.Euler(tRadian / Mathf.PI * 180f);
    }
}
