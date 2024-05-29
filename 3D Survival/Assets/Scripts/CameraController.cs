using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // �÷��̾��� Transform
    public Vector3 offset;   // ī�޶��� ������ ��ġ

    void Start()
    {
        // �ʱ� ������ ���� �÷��̾�� ī�޶��� �ʱ� ��ġ ���̷� ����
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {

        // �÷��̾��� ���� ȸ�� ���� ����Ͽ� ī�޶��� ��ġ ���
        float desiredAngle = player.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = player.position + rotation * offset;

        // ī�޶� �׻� �÷��̾ �ٶ󺸵��� ����
        //transform.LookAt(player);
    }
}
