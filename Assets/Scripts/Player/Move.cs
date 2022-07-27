using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private inventory invent;

    [SerializeField]
    private float speed = 5f;//�������� ���������
    Vector3 velocity = Vector3.zero;
    private Rigidbody rb;//�������������� ���������� ���������� 
   
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();//��������� ������ ���������� Rigidbody
        invent = GetComponent<inventory>();
    }

    void Update()
    {
        float xMov = Input.GetAxisRaw("Horizontal");//��������� ������ �������������� ���
        float zMov = Input.GetAxisRaw("Vertical");//��������� ������ ������������ ���
        Vector3 _moveH = transform.right * xMov;//�������� �� ��� �
        Vector3 _moveW = transform.forward * zMov;//�������� �� ��� y
        velocity = (_moveH + _moveW).normalized * speed;// ������ �������� 
    }

    private void FixedUpdate()
    {
      
        if (velocity != Vector3.zero && invent.inventoryActive == false) 
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);        
        }
    }
}
