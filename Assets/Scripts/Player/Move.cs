using UnityEngine;

namespace Player
{
    public class Move : MonoBehaviour
    {
        private Inventory invent;

        [SerializeField]
        private float speed = 5f; //Ñêîðîñòü ïåðñîíàæà
        Vector3 velocity = Vector3.zero;
        private Rigidbody rb; //Èíèöèàëüèçàöèÿ ïåðåìåííûé êîìïîíåíòà 
   
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            rb = GetComponent<Rigidbody>(); //Ïîëó÷åíèå äàííûõ êîìïîíåíòà Rigidbody
            invent = GetComponent<Inventory>();
        }

        void Update()
        {
            float xMov = Input.GetAxisRaw("Horizontal");     //Ïîëó÷åíèå äàííûõ ãîðèçîíòàëüíîé îñè
            float zMov = Input.GetAxisRaw("Vertical");       //Ïîëó÷åíèå äàííûõ âåðòèêàëüíîé îñè
            Vector3 _moveH = transform.right * xMov;         //Ñìåùåíèå ïî îñè õ
            Vector3 _moveW = transform.forward * zMov;       //Ñìåùåíèå ïî îñè y
            velocity = (_moveH + _moveW).normalized * speed; // Âåêòîð ñìåùåíèÿ 
        }

        private void FixedUpdate()
        {
      
            if (velocity != Vector3.zero && invent.inventoryActive == false) 
            {
                rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);        
            }
        }
    }
}
