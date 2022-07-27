using UnityEngine;

namespace Keys
{
    [CreateAssetMenu(fileName ="ItemData", menuName ="Items")]
    public class KeyInfo : ScriptableObject
    {
        public string KeyName;
        public Sprite _KSprite;
        public GameObject _Pref;
    }
}
