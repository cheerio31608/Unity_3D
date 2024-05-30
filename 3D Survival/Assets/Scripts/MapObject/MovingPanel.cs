using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPanel : MonoBehaviour
{
    public float moveSpeed;
    private bool changeDirection = false;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PanelMovement();
    }


    private void PanelMovement()
    {
        if(!changeDirection)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            if(gameObject.transform.position.x < -6) changeDirection = true;
        }
        else
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            if (gameObject.transform.position.x > 12) changeDirection = false;
        }
    }

    // �÷��̾ ���ǿ� �����ϴ� ����
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    // �÷��̾ ���ǿ��� ������ �� �θ�-�ڽ� ���踦 ����
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
