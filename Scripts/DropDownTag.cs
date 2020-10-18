using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Michsky.UI.ModernUIPack
{
    public class DropDownTag : MonoBehaviour
    {
        public CustomDropdown dropdown;
        public TagManager manager;
        public Manager MANAGER;
        public UnityEvent RETURNITEM;

        public GameObject AddPanel;
        private bool hasSet = false;
        public CustomDropdown.Item YAY;
        private void Start()
        {
            manager = FindObjectOfType<TagManager>();
            MANAGER = FindObjectOfType<Manager>();
            StartCoroutine(Delay());
        }
        public void CheckList()
        {
            StartCoroutine(Delay());
        }
        public IEnumerator Delay()
        {
            if (AddPanel.activeSelf)
            {
                yield return new WaitForSeconds(1f);
                dropdown.dropdownItems.Clear();
                dropdown.dropdownItems.Add(YAY);
                foreach (var item in manager.checklistObjects)
                {
                    var COOL = new CustomDropdown.Item();
                    item.CheckData();

                    COOL.itemName = item.tagName;
                    COOL.itemIcon = item.IMAGE.sprite;
                    COOL.tag = item;
                    COOL.OnItemSelection = RETURNITEM;
                    dropdown.dropdownItems.Add(COOL);
                }

                dropdown.SetStuff();
            }
        }
        private void Update()
        {
            if(AddPanel.activeSelf && !hasSet)
            {
                StartCoroutine(Delay());
                hasSet = true;
            }
            if(!AddPanel.activeSelf && hasSet)
            {
                hasSet = false;
            }

        }

    }
}
