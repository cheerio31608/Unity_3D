using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform
    public Vector3 offset;   // 카메라의 오프셋 위치

    void Start()
    {
        // 초기 오프셋 값을 플레이어와 카메라의 초기 위치 차이로 설정
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {

        // 플레이어의 현재 회전 값을 사용하여 카메라의 위치 계산
        float desiredAngle = player.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = player.position + rotation * offset;

        // 카메라가 항상 플레이어를 바라보도록 설정
        //transform.LookAt(player);
    }
}
