using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
    public class ColorRreturnItem : MonoBehaviour
{
    public string returnString;
    private TagManager manager;
    private Image image;
        public Color originalColor;
    public bool selected;
        public ColorManager colorManager;
    private void Start()
    {
        manager = FindObjectOfType<TagManager>();
        image = GetComponent<Image>();
    }
        private void OnEnable()
        {
            colorManager = FindObjectOfType<ColorManager>();
        }
        public void SelectColor()
        {
                selected = true;
                manager.ColorValue = returnString;
                colorManager.selected = this;
                colorManager.ChangeSelected();
        }
        private void Update()
        {
            if(selected)
            {
                image.color = new Color(1, 1, 1, .7f);
            }
            else
            {
                image.color = originalColor;   
            }
        }
    } 
}
