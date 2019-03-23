using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Card")]
    public class Card : ScriptableObject
    {
        public string cardName;
        //maybe not
        public Sprite art;
        public string cardDetail;
        public string cardFlavor;
        //maybe not
        public string artist;
    }
}
