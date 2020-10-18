using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Michsky.UI.ModernUIPack
{
    public class CheckList : MonoBehaviour
    {
        public string objName;
        public string type;
        public int index;
        public string Tag;
        public bool completed;

        public bool urgency;

        public TextMeshProUGUI itemText;

        public Manager manager;

        public Image image;
        public Image icon;
        public TagManager tagsmanager;
        private Animator anim;

        private void Start()
        {
            itemText.text = objName;
            manager = FindObjectOfType<Manager>();
            tagsmanager = FindObjectOfType<TagManager>();
            anim = GetComponent<Animator>();
        }
        void Update()
        {
            CheckCompleted();

        }
        void CheckCompleted()
        {
            if (completed)
            {
                itemText.fontStyle = FontStyles.Strikethrough;
                GetComponent<Toggle>().isOn = true;
                image.fillAmount = 100;
            }
            else
            {
                image.fillAmount = 0;
                itemText.fontStyle &= ~FontStyles.Strikethrough;
            }
        }
        private void LateUpdate()
        {
            CheckTag();
            if(manager.isEditing)
            {
                anim.SetBool("IsEditing", true);
            }
            if (manager.isEditing == false)
            {
                anim.SetBool("IsEditing", false);
            }
        }
        public void CheckTag()
        {
            foreach (var item in tagsmanager.checklistObjects)
            {
                if (Tag == item.tagName)
                {
                    icon.enabled = true;
                    item.CheckData();
                    itemText.color = item.COLOR;
                    icon.sprite = item.IMAGE.sprite;
                    return;
                }
                else{
                    itemText.color = new Color(1, 1, 1, 1);
                }
            }
        }
        public void DisplayData()
        {
            manager.DisplayData(objName,this, type, completed, Tag);
        }
        public void DeleteItem()
        {
            manager.DeleteItem(this);
            Destroy(this.gameObject);
        }
        public void SetObjectInfo(string name, string type, string Tag, bool completed, int index, bool urgent)
        {
            this.objName = name;
            this.type = type;
            this.index = index;
            this.Tag = Tag;
            this.urgency = urgent;
            this.completed = completed;
            itemText.text = objName;
        }
    }
}
