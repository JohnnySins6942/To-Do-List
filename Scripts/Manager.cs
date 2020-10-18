using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

namespace Michsky.UI.ModernUIPack 
{
    public class Manager : MonoBehaviour
    {
        public Transform content;
        public Transform UrgentTransform;
        public GameObject addPanel;
        public Button createButton;
        public GameObject checklistItemPrefab;

        public bool changed = true;

        string filePath;
        string urgentfilePath; 

        public TMP_InputField nameInput;
        public TMP_InputField typeInput;
        public CustomDropdown dropdown;
        public List<CheckList> checklistObjects = new List<CheckList>();
        public List<CheckList> urgentObjects = new List<CheckList>();
        public string urgencyReturn;

        public CustomDropdown DROPDOWN;
        public GameObject addpanel;

        private bool hasSet = false; 

        public CheckList selectedchecklist;

        public Toggle urgent;

        //Info
        public GameObject DataPanel;
        public InputField nameText;
        public InputField AdditionNotesText;
        public Text Tag;
        public Toggle completed;
        public bool isEditing; 
        
        public class CheckListItem
        {
            public string objName;
            public string type;
            public int index;
            public string Urgency;
            public bool completed;
            public bool urgent; 

            public CheckListItem(string name, string type, string urgency, bool completed, int index, bool urgent)
            {
                this.objName = name;
                this.type = type;
                this.index = index;
                this.completed = completed;
                this.urgent = urgent;
                this.Urgency = urgency;
            }
        }
        private void Start()
        {
            filePath = Application.persistentDataPath + "/checklist.txt";
            urgentfilePath = Application.persistentDataPath + "/Urgent.txt";

            LoadJSONData();
            LoadUrgentJSONData();
            createButton.onClick.AddListener(delegate { CreateCheckListItem(nameInput.text, typeInput.text, DROPDOWN.dropdownItems[DROPDOWN.selectedItemIndex].itemName, false, changed); });
        }
        private void Update()
        {
            if(addpanel.activeSelf && !hasSet) 
            {
                DROPDOWN = FindObjectOfType<CustomDropdown>();
                hasSet = false;
            }
            if(!addPanel.activeSelf && hasSet)
            {
                hasSet = false;
            }
        }
        public void EditMode()
        {
            print(isEditing);
            if (isEditing)
            {
                isEditing = false;
                return;
            }
            if (!isEditing)
            {
                isEditing = true;
            }
        }

        public void ChangeBool()
        {
            changed = urgent.isOn;
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
        public void CreateCheckListItem(string name, string type, string urgency, bool completed, bool urgent, int loadIndex = 0, bool loading = false)
        {
            if(urgency == null)
            {
                urgency = "Default";
            }
            if (!urgent)
            {
                GameObject item = Instantiate(checklistItemPrefab);

                item.transform.SetParent(content.transform, false);
                CheckList itemObject = item.GetComponent<CheckList>();
                int index = loadIndex;
                if (loading)
                    index = checklistObjects.Count;

                itemObject.SetObjectInfo(name, type, urgency, completed, index, urgent);
                checklistObjects.Add(itemObject);
                CheckList temp = itemObject;
                itemObject.GetComponent<Toggle>().onValueChanged.AddListener(delegate { Checkitem(temp); });
            }
            if(urgent)
            {
                GameObject item = Instantiate(checklistItemPrefab);

                item.transform.SetParent(UrgentTransform.transform, false);
                CheckList itemObject = item.GetComponent<CheckList>();
                int index = loadIndex;
                if (loading)
                    index = urgentObjects.Count;

                itemObject.SetObjectInfo(name, type, urgency, completed, index, urgent);
                urgentObjects.Add(itemObject);
                CheckList temp = itemObject;
                itemObject.GetComponent<Toggle>().onValueChanged.AddListener(delegate { Checkitem(temp); });
            }

            if (!loading)
            {
                SaveJSONData();
                SaveUrgentJSONData();
                SwitchMode(0);
            }
        }
        public void DisplayData(string name, CheckList list, string additionNotes, bool COMPLETED, string tag)
        {
            DataPanel.SetActive(true);
            nameText.text = name;
            AdditionNotesText.text = additionNotes;
            completed.isOn = COMPLETED;
            selectedchecklist = list;
            Tag.text = "Tag Used: " + tag;
        }
        public void changeTitle()
        {
            foreach (var item in checklistObjects)
            {
                if(item == selectedchecklist)
                {
                    item.objName = nameText.text;
                    item.SetObjectInfo(item.objName, item.type, item.Tag, item.completed, item.index, item.urgency);
                    SaveJSONData();
                }
            }
            foreach (var item in urgentObjects)
            {
                if (item == selectedchecklist)
                {
                    item.objName = nameText.text;
                    item.SetObjectInfo(item.objName, item.type, item.Tag, item.completed, item.index, item.urgency);
                    SaveUrgentJSONData();
                }
            }
        }
        public void ChangeAdditionalnotes()
        {
            foreach (var item in checklistObjects)
            {
                if (item == selectedchecklist)
                {
                    item.type = AdditionNotesText.text;
                    item.SetObjectInfo(item.objName, item.type, item.Tag, item.completed, item.index, item.urgency);
                    SaveJSONData();
                }
            }
            foreach (var item in urgentObjects)
            {
                if (item == selectedchecklist)
                {
                    item.type = AdditionNotesText.text;
                    item.SetObjectInfo(item.objName, item.type, item.Tag, item.completed, item.index, item.urgency);
                    SaveUrgentJSONData();
                }
            }
        }
        public void changeCompleted()
        {
            foreach (var item in checklistObjects)
            {
                if (item == selectedchecklist)
                {
                    item.completed = completed.isOn;
                    item.SetObjectInfo(item.objName, item.type, item.Tag, item.completed, item.index, item.urgency);
                    SaveJSONData();
                }
            }
            foreach (var item in urgentObjects)
            {
                if (item == selectedchecklist)
                {
                    item.completed = completed.isOn;
                    item.SetObjectInfo(item.objName, item.type, item.Tag, item.completed, item.index, item.urgency);
                    SaveUrgentJSONData();
                }
            }
        }
        public void FinishDisplay()
        {
            DataPanel.SetActive(false);
        }
        void Checkitem(CheckList item)
        {
            //checklistObjects.Remove(item);

            var text = item.GetComponentInChildren<TextMeshProUGUI>();
            text.fontStyle = FontStyles.Strikethrough;
            item.completed = true;
            SaveJSONData();
        }
        public void DeleteItem(CheckList item)
        {
            checklistObjects.Remove(item);
            urgentObjects.Remove(item);
            SaveJSONData();
            SaveUrgentJSONData();
        }
        public void SaveUrgentJSONData()
        {
            string UrgentContents = "";
            for (int i = 0; i < urgentObjects.Count; i++)
            {
                CheckListItem temp = new CheckListItem(urgentObjects[i].objName, urgentObjects[i].type, urgentObjects[i].Tag, urgentObjects[i].completed, urgentObjects[i].index, urgentObjects[i].urgency);
                UrgentContents += JsonUtility.ToJson(temp) + "\n";
            }
            File.WriteAllText(urgentfilePath, UrgentContents);
        }
        public void SaveJSONData()
        {
            string contents = "";
            for (int i = 0; i < checklistObjects.Count; i++)
            {
                CheckListItem temp = new CheckListItem(checklistObjects[i].objName, checklistObjects[i].type, checklistObjects[i].Tag, checklistObjects[i].completed, checklistObjects[i].index, checklistObjects[i].urgency);
                contents += JsonUtility.ToJson(temp) + "\n";
            }
            File.WriteAllText(filePath, contents);
        }
        void LoadUrgentJSONData()
        {
            if (File.Exists(urgentfilePath))
            {
                string content = File.ReadAllText(urgentfilePath);

                string[] splitUrgentContents = content.Split('\n');

                foreach (string UrgentContents in splitUrgentContents)
                {
                    if (UrgentContents.Trim() != "")
                    {
                        CheckListItem temp = JsonUtility.FromJson<CheckListItem>(UrgentContents);
                        CreateCheckListItem(temp.objName, temp.type, temp.Urgency, temp.completed, temp.urgent, temp.index, true);
                    }
                }
            }
            else
            {
                Debug.Log("NO FILE!!!");
            }
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
                        CheckListItem temp = JsonUtility.FromJson<CheckListItem>(content);
                        CreateCheckListItem(temp.objName, temp.type, temp.Urgency,temp.completed, temp.urgent,temp.index, true);
                    }
                }
            }
            else
            {
                Debug.Log("NO FILE!!!");
            }
        }
    }
}
