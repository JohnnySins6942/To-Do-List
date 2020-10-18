using UnityEngine;

namespace Michsky.UI.ModernUIPack
{
    public class IconManager : MonoBehaviour
    {
        public IconReturnItem[] items;

        public IconReturnItem selected;


        public void ChangeSelected()
        {
            foreach (var item in items)
            {
                if (item != selected)
                {
                    item.selected = false;
                }
                else
                {
                    item.selected = true;
                }
            }
        }
    }
}
