using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack {
    public class IconReturnItem : MonoBehaviour
    {
        public string returnString;
        private TagManager manager;
        private Image image;
        public bool selected;
        public IconManager iconManager;
        public Color color;
        private void Start()
        {
            manager = FindObjectOfType<TagManager>();
            image = GetComponent<Image>();
        }
        private void OnEnable()
        {
            iconManager = FindObjectOfType<IconManager>();
        }
        public void SelectColor()
        {
                image.color = new Color(1, 1, 1, 1);
                manager.iconValue = returnString;
                selected = true;
                iconManager.selected = this;
                iconManager.ChangeSelected();   
        }

        private void Update()
        {
            if (selected)
            {
                image.color = new Color(1, 1, 1, .7f);
            }
            else
            {
                image.color = color;
            }
        }
    } 
}
