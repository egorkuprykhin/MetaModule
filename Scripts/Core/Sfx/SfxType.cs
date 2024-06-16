using UnityEngine;

namespace Core.Sfx
{
    [CreateAssetMenu(fileName = "Sfx")]
    public class SfxType : ScriptableObject
    {
        public AudioClip AudioClip;
    }
}