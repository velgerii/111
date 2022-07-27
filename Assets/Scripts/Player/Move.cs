using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private inventory invent;

    [SerializeField]
    private float speed = 5f;//Скорость персонажа
    Vector3 velocity = Vector3.zero;
    private Rigidbody rb;//Инициальизация переменный компонента 
   
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();//Получение данных компонента Rigidbody
        invent = GetComponent<inventory>();
    }

    void Update()
    {
        float xMov = Input.GetAxisRaw("Horizontal");//Получение данных горизонтальной оси
        float zMov = Input.GetAxisRaw("Vertical");//Получение данных вертикальной оси
        Vector3 _moveH = transform.right * xMov;//Смещение по оси х
        Vector3 _moveW = transform.forward * zMov;//Смещение по оси y
        velocity = (_moveH + _moveW).normalized * speed;// Вектор смещения 
    }

    private void FixedUpdate()
    {
      
        if (velocity != Vector3.zero && invent.inventoryActive == false) 
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);        
        }
    }
}
