using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Michsky.UI.ModernUIPack
{
    public class Tag : MonoBehaviour
    {
        public string tagName;
        public string Icon;
        public string color;

        public TextMeshProUGUI itemText;

        private DropDownTag dropTag;

        public TagManager manager;

        public Image IMAGE;
        public Color COLOR;

        private void Start()
        {
            itemText.text = tagName;
            manager = FindObjectOfType<TagManager>();
            dropTag = FindObjectOfType<DropDownTag>();
            CheckData();
        }
        public void CheckData()
        {
            manager = FindObjectOfType<TagManager>();
            itemText.text = tagName;
            CheckIcon();
            CheckColor();
        }
        public void DeleteItem()
        {
            manager.DeleteItem(this);
            dropTag.CheckList();
            Destroy(this.gameObject);
        }
        public void SetObjectInfo(string Name, string icon, string color)
        {
            this.tagName = Name;
            this.Icon = icon;
            this.color = color;
            CheckData();
        }
        public void CheckIcon()
        {
            if(Icon == "Star")
            {
                IMAGE.sprite = manager.Star;
                return;
            }
            else if(Icon == "Dollar")
            {
                IMAGE.sprite = manager.Dollar;
                return;
            }
            else if (Icon == "Card")
            {
                IMAGE.sprite = manager.Card;
                return;
            }
            else if (Icon == "Bell")
            {
                IMAGE.sprite = manager.Bell;
                return;
            }
            else if (Icon == "Phone")
            {
                IMAGE.sprite = manager.Phone;
                return;
            }
            else if (Icon == "Computer")
            {
                IMAGE.sprite = manager.Computer;
                return;
            }
            else if (Icon == "Music")
            {
                IMAGE.sprite = manager.Music;
                return;
            }
            else if (Icon == "Message")
            {
                IMAGE.sprite = manager.Message;
                return;
            }
            else if (Icon == "Eye")
            {
                IMAGE.sprite = manager.Eye;
                return;
            }
            else if (Icon == "Heart")
            {
                IMAGE.sprite = manager.Heart;
                return;
            }
            else if (Icon == "World")
            {
                IMAGE.sprite = manager.World;
                return;
            }
            else if (Icon == "Map")
            {
                IMAGE.sprite = manager.Map;
                return;
            }
            else if (Icon == "Cloud")
            {
                IMAGE.sprite = manager.Cloud;
                return;
            }
            else if (Icon == "Mail")
            {
                IMAGE.sprite = manager.Mail;
                return;
            }
            else if (Icon == "Photo")
            {
                IMAGE.sprite = manager.Photo;
                return;
            }
            else if (Icon == "Camera")
            {
                IMAGE.sprite = manager.Camera;
                return;
            }
            else
            {
                return;
            }
        }
        public void CheckColor()
        {
            if (color == "Black")
            {
                itemText.color = manager.Black;
                COLOR = manager.Black;
                return;
            }
            else if (color == "Red")
            {
                itemText.color = manager.Red;
                COLOR = manager.Red;
                return;
            }
            else if (color == "Grey")
            {
                itemText.color = manager.Grey;
                COLOR = manager.Grey;
                return;
            }
            else if (color == "Blue")
            {
                itemText.color = manager.Blue;
                COLOR = manager.Blue;
                return;
            }
            else if (color == "Cyan")
            {
                itemText.color = manager.Cyan;
                COLOR = manager.Cyan;
                return;
            }
            else if (color == "Green")
            {
                itemText.color = manager.Green;
                COLOR = manager.Green;
                return;
            }
            else if (color == "Magenta")
            {
                itemText.color = manager.Magenta;
                COLOR = manager.Magenta;
                return;
            }
            else if (color == "Yellow")
            {
                itemText.color = manager.Yellow;
                COLOR = manager.Yellow;
                return;
            }
            else
            {
                itemText.color = manager.Default;
                COLOR = manager.Default;
            }
        }
    }
}
