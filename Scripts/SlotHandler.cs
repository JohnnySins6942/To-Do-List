using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Michsky.UI.ModernUIPack
{
    public class SlotHandler : MonoBehaviour, IDropHandler
    {
        public Manager manager;
        public bool urgent;
        public void OnDrop(PointerEventData eventData)
        {
            if (manager.isEditing)
            {
                if (eventData.pointerDrag != null && eventData.pointerDrag.transform.gameObject.GetComponent<CheckList>() != null)
                {
                    var data = eventData.pointerDrag.transform.gameObject.GetComponent<CheckList>();
                    if (data.urgency == false)
                    {
                        if (!urgent)
                        {
                            manager.CreateCheckListItem(data.objName, data.type, data.Tag, data.completed, false);

                            foreach (var item in manager.checklistObjects)
                            {
                                if (item == data)
                                {
                                    manager.DeleteItem(data);
                                    Destroy(data.gameObject);
                                }
                            }
                        }
                        else
                        {
                            manager.CreateCheckListItem(data.objName, data.type, data.Tag, data.completed, true);

                            foreach (var item in manager.checklistObjects)
                            {
                                if (item == data)
                                {
                                    manager.DeleteItem(data);
                                    Destroy(data.gameObject);
                                }
                            }
                        }
                    }
                    else if (data.urgency == true)
                    {
                        if (urgent)
                        {
                            manager.CreateCheckListItem(data.objName, data.type, data.Tag, data.completed, true);

                            foreach (var item in manager.urgentObjects)
                            {
                                if (item == data)
                                {
                                    manager.DeleteItem(data);
                                    Destroy(data.gameObject);
                                }
                            }
                        }

                        else
                        {
                            manager.CreateCheckListItem(data.objName, data.type, data.Tag, data.completed, false);

                            foreach (var item in manager.urgentObjects)
                            {
                                if (item == data)
                                {
                                    manager.DeleteItem(data);
                                    Destroy(data.gameObject);
                                }
                            }
                        }
                    }
                }
            }
        }
    } 
}
