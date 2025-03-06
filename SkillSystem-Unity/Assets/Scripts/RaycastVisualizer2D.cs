using UnityEngine;

public class RaycastVisualizer2D : MonoBehaviour
{
    // Raycast가 발사될 위치와 방향을 설정합니다.
    public Transform rayOrigin;
    public Vector2 rayDirection = Vector2.right;  // 기본 방향을 오른쪽으로 설정
    public float rayDistance = 10f;

    void OnDrawGizmos()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin.position, rayDirection, rayDistance);

        // Raycast가 충돌한 지점이 있을 경우
        if (hit.collider != null)
        {
            // Raycast가 충돌한 지점까지 빨간색 선으로 시각화
            Gizmos.color = Color.red;
            Gizmos.DrawLine(rayOrigin.position, hit.point);

            // 충돌 지점을 파란색 원으로 시각화
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(hit.point, 0.2f);
        }
        else
        {
            // 충돌이 없다면 기본 방향으로 레이를 그립니다
            Gizmos.color = Color.green;
            Gizmos.DrawLine(rayOrigin.position, rayOrigin.position + (Vector3)rayDirection.normalized * rayDistance);
        }
    }
}
