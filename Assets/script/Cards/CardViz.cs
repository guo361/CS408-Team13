using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace SA
{
    public class CardViz : MonoBehaviour
    {
        public Text title;
        public Text detail;
        public Text flavor;
        public Text artist;
        public Image art;

        public Card card;

        private void Start()
        {
            LoadCard(card);
        }

        public void LoadCard(Card c)
        {
            if(c == null)
            {
                return;
            }
            card = c;
            title.text = c.cardName;
            detail.text = c.cardDetail;

            if (string.IsNullOrEmpty(c.cardFlavor))
            {
                flavor.gameObject.SetActive(false);
            }
            else {
                flavor.gameObject.SetActive(true);
                flavor.text = c.cardFlavor;
            }

            artist.text = c.artist;
            art.sprite = c.art;
        }
     
    }
}
