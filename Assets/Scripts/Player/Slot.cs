using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Player
{
    public class Slot : MonoBehaviour, IPointerClickHandler
    {
        public string NameKey;  //Íàçâàíèå îáúåêòà
        public GameObject pref; //Ïðåôàá îáúåêòà
        public ActiveItem ActiveItem;
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
                ActiveItem.clearActive();
            }
        }
    }
}
