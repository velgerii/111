using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook1 : MonoBehaviour
{
    public GameObject PCamera;
    private float _rotationSpeed = 1.0f;//—корость вращени€ камеры
    private float maxVert = 45.0f;//ћаксимальнове вертикальное значение камеры
    private float minvert = -45.0f;//ћинимальное вертикальное значение камеры

    private float _rotationVert= 0f;//ѕеременна€ отображающа€ текущее вертикальное положение камеры
    float _rotationX = 0f;


    inventory inv;

    void Start()
    {
        inv = GetComponent<inventory>();
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null) 
        {
            rb.freezeRotation = true;
        }
    }
    
    void Update()
    {
        if (inv.inventoryActive == false) 
        {
            _rotationVert -= Input.GetAxis("Mouse Y") * _rotationSpeed;
            _rotationVert = Mathf.Clamp(_rotationVert, minvert, maxVert);//ќграничение угла пововорота камеры (вертикаль)
            _rotationX += Input.GetAxis("Mouse X") * _rotationSpeed;
            transform.localEulerAngles = new Vector3(0, _rotationX, 0);
            PCamera.transform.localEulerAngles = new Vector3(_rotationVert, 0, 0);
        }   
    }
}
