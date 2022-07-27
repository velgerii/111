using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class ActiveItem : MonoBehaviour
    {
        public string KeyName;

        public void setActiveItem(Sprite _sprite, string _KeyName) 
        {
            GetComponent<Image>().sprite = _sprite;
            KeyName = _KeyName;
        }

        public void clearActive() 
        {
            GetComponent<Image>().sprite = null;
            KeyName = "";
        }
    }
}
