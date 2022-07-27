using UnityEngine;

namespace Player
{
    public class MouseLook1 : MonoBehaviour
    {
        public GameObject PCamera;
        private float _rotationSpeed = 1.0f;
        private float maxVert = 45.0f;
        private float _minVert = -45.0f;

        private float _rotationVert = 0f;
        private float _rotationX = 0f;


        private Inventory _inv;

        private void Start()
        {
            _inv = GetComponent<Inventory>();
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null) 
            {
                rb.freezeRotation = true;
            }
        }

        private void Update()
        {
            if (_inv.inventoryActive == false) 
            {
                _rotationVert -= Input.GetAxis("Mouse Y") * _rotationSpeed;
                _rotationVert = Mathf.Clamp(_rotationVert, _minVert, maxVert);
                _rotationX += Input.GetAxis("Mouse X") * _rotationSpeed;
                transform.localEulerAngles = new Vector3(0, _rotationX, 0);
                PCamera.transform.localEulerAngles = new Vector3(_rotationVert, 0, 0);
            }   
        }
    }
}
