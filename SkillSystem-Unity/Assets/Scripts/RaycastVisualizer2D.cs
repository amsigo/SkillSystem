using UnityEngine;

public class RaycastVisualizer2D : MonoBehaviour
{
    // Raycast�� �߻�� ��ġ�� ������ �����մϴ�.
    public Transform rayOrigin;
    public Vector2 rayDirection = Vector2.right;  // �⺻ ������ ���������� ����
    public float rayDistance = 10f;

    void OnDrawGizmos()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin.position, rayDirection, rayDistance);

        // Raycast�� �浹�� ������ ���� ���
        if (hit.collider != null)
        {
            // Raycast�� �浹�� �������� ������ ������ �ð�ȭ
            Gizmos.color = Color.red;
            Gizmos.DrawLine(rayOrigin.position, hit.point);

            // �浹 ������ �Ķ��� ������ �ð�ȭ
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(hit.point, 0.2f);
        }
        else
        {
            // �浹�� ���ٸ� �⺻ �������� ���̸� �׸��ϴ�
            Gizmos.color = Color.green;
            Gizmos.DrawLine(rayOrigin.position, rayOrigin.position + (Vector3)rayDirection.normalized * rayDistance);
        }
    }
}
