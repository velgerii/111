using System.Collections;
using System.Collections.Generic;
using Doors;
using Keys;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class Inventory : MonoBehaviour
    {
        private Camera mainCamera;           //Ññûëêà íà ãëàâíóþ êàìåðó
        public bool inventoryActive = false; //Ïåðåìåííàÿ îòâå÷àþùàÿ çà ïðîâåðêó àêòèâíîñòè èíâåíåòàðÿ
        [SerializeField]
        private Transform InventoryPanel; //Ïàíåëü èíâåíòàðÿ
        [SerializeField]
        private float _rayDistance = 3f; //Äëèííà ëó÷à âçàèìîäåéñòâèÿ ïðåäìåòîâ
        [SerializeField]
        private List<Slot> InventSlots = new List<Slot>(); //Ëèñò àêòûâíûõ ñëîòîâ
        private ActiveItem _active;

        void Start()
        {
            for (int i = 0; i < InventoryPanel.childCount; i++) 
            {
                if (InventoryPanel.GetChild(i).GetComponent<Slot>() != null) 
                {
                    InventSlots.Add(InventoryPanel.GetChild(i).GetComponent<Slot>());
                }
                if (InventoryPanel.GetChild(i).GetComponent<ActiveItem>() != null) 
                {
                    _active = InventoryPanel.GetChild(i).GetComponent<ActiveItem>();
                }
            }
            mainCamera = Camera.main;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab)) 
            {
                inventoryActive = !inventoryActive;
                if (inventoryActive == true) 
                {
                    Cursor.lockState = CursorLockMode.None;
                }
                if (inventoryActive == false)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, _rayDistance))  
            {
                if (hit.collider.gameObject.tag == "Key" && Input.GetKeyDown(KeyCode.E)) 
                {
                    addItem(hit);
                }
                if (hit.collider.gameObject.tag == "Door" && Input.GetKeyDown(KeyCode.E)) 
                {
                    OpenDoor(hit);
                }
            }
        }
        private void addItem(RaycastHit _hit) 
        {
            KeyScript _scriptKey = _hit.collider.gameObject.GetComponent<KeyScript>();
            var SO = Resources.LoadAll<KeyInfo>("");
            foreach (Slot _slot in InventSlots) 
            {
                if (_slot.NameKey == "") 
                {
                    foreach (KeyInfo TKey in SO) 
                    {
                        if (TKey.KeyName == _scriptKey.NameKey) 
                        {
                            _slot.NameKey = _scriptKey.NameKey;
                            _slot.pref = TKey._Pref;
                            _slot.GetComponent<Image>().sprite = TKey._KSprite;
                            Destroy(_hit.collider.gameObject);
                            break;
                        }
                    }     
                    break;
                }
            } 
        }
        public void OpenDoor(RaycastHit hit) 
        {
            Door dr = hit.collider.GetComponent<Door>();
            if (dr.NameKey == _active.KeyName)
            {
                Debug.Log("Åáàòü ìîëîäåö");
                hit.collider.gameObject.GetComponent<Renderer>().material.color = new Color(0, 255, 0, 255);
                _active.clearActive();
                foreach (Slot _slot in InventSlots)
                {
                    if (_slot.NameKey == dr.NameKey) 
                    {
                        _slot.NameKey = "";
                        _slot.pref = null;
                        _slot.GetComponent<Image>().sprite = null;
                    }
                }
            }
            else 
            {
            
                Color MainCol = hit.collider.gameObject.GetComponent<Renderer>().material.color;

                _active.clearActive();
                StartCoroutine( WaitCollor(hit,MainCol));

            
            }
        }
        IEnumerator WaitCollor(RaycastHit hit, Color MainCol) 
        {
            hit.collider.gameObject.GetComponent<Renderer>().material.color = new Color(255, 0, 0, 255);
            yield return new WaitForSeconds(0.5f);
            hit.collider.gameObject.GetComponent<Renderer>().material.color = MainCol;
        
        }
    }
}
