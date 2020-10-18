using UnityEngine;

namespace Michsky.UI.ModernUIPack
{
    public class ColorManager : MonoBehaviour
    {
        public ColorRreturnItem[] items;

        public ColorRreturnItem selected;


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
