using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public string NameKey;//Название объекта
    public GameObject pref;//Префаб объекта
    public ActiveItem ActiveItem;
    private void Start()
    {
       
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId == -1) 
        {
            ActiveItem.setActiveItem(GetComponent<Image>().sprite, NameKey);
        }
        if (eventData.pointerId == -2) 
        {
            NameKey = "";
            Instantiate(pref, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y-1, Camera.main.transform.position.z), Quaternion.identity);
            pref = null;
            GetComponent<Image>().sprite = null;
        }
    }
}
