using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

namespace Michsky.UI.ModernUIPack
{
    public class TagManager : MonoBehaviour
    {
        public Transform content;
        public GameObject addPanel;
        public Button createButton;
        public GameObject checklistItemPrefab;

        string filePath;

        public TMP_InputField nameInput;
        public string ColorValue;
        public string iconValue;
        public List<Tag> checklistObjects = new List<Tag>();

        public Manager manager;

        //Icons
        public Sprite Star;
        public Sprite Dollar;
        public Sprite Card;
        public Sprite Bell;
        public Sprite Phone;
        public Sprite Computer;
        public Sprite Music;
        public Sprite Message;
        public Sprite Eye;
        public Sprite Heart;
        public Sprite World;
        public Sprite Map;
        public Sprite Cloud;
        public Sprite Mail;
        public Sprite Photo;
        public Sprite Camera;

        //colors
        public Color Red;
        public Color Black;
        public Color Grey;
        public Color Blue;
        public Color Cyan;
        public Color Green;
        public Color Magenta;
        public Color Yellow;
        public Color Default;
        public class tagItem
        {
            public string Name;
            public string Icon;
            public string color;

            public tagItem(string TagName, string icon, string Color)
            {
                this.Name = TagName;
                this.Icon = icon;
                this.color = Color;
            }
        }
        private void Start()
        {
            filePath = Application.persistentDataPath + "/Tags.txt";

            LoadJSONData();
            createButton.onClick.AddListener(delegate { CreateCheckListItem(nameInput.text, iconValue,ColorValue, false ); });
            manager = FindObjectOfType<Manager>();
        }
        private void OnEnable()
        {
            iconValue = null;
            ColorValue = null;
        }
        public void SwitchMode(int mode)
        {
            switch (mode)
            {
                case 0:
                    addPanel.SetActive(false);
                    break;
                case 1:
                    addPanel.SetActive(true);
                    break;
            }
        }
        void CreateCheckListItem(string Name, string icon, string color, bool loading = false)
        {
                GameObject item = Instantiate(checklistItemPrefab);

                item.transform.SetParent(content.transform, false);
                Tag itemObject = item.GetComponent<Tag>();

                itemObject.SetObjectInfo(Name, icon, color);
            checklistObjects.Add(itemObject);

                if (!loading)
                {
                    SaveJSONData();
                    SwitchMode(0);
                }
        }
        public void DeleteItem(Tag item)
        {
            checklistObjects.Remove(item);
            SaveJSONData();
        }

        public void SaveJSONData()
        {
            string contents = "";
            for (int i = 0; i < checklistObjects.Count; i++)
            {
                tagItem temp = new tagItem(checklistObjects[i].tagName, checklistObjects[i].Icon, checklistObjects[i].color);
                contents += JsonUtility.ToJson(temp) + "\n";
            }
            File.WriteAllText(filePath, contents);
        }
        void LoadJSONData()
        {
            if (File.Exists(filePath))
            {
                string contents = File.ReadAllText(filePath);

                string[] splitContents = contents.Split('\n');

                foreach (string content in splitContents)
                {
                    if (content.Trim() != "")
                    {
                        tagItem temp = JsonUtility.FromJson<tagItem>(content);
                        CreateCheckListItem(temp.Name, temp.Icon, temp.color, true);
                    }
                }
            }
            else
            {
                Debug.Log("NO FILE!!!");
            }
        }
        private void OnApplicationQuit()
        {
            SaveJSONData();
        }
    }
}
