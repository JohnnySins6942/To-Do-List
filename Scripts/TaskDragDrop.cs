using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
namespace Michsky.UI.ModernUIPack
{
    public class TaskDragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Canvas canvas;
        private RectTransform rectTransform;
        public CanvasGroup canvasGroup;
        private Manager manager;
        public float requiredHold;

        private float pointerDownTimer;

        public bool isPressed;
        void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
            canvas = FindObjectOfType<Canvas>();
            manager = FindObjectOfType<Manager>();
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            if (manager.isEditing)
            {
                canvasGroup.alpha = .6f;
                canvasGroup.blocksRaycasts = false;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (manager.isEditing)
            {
                rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (manager.isEditing)
            {
                manager.EditMode();
                print("cool");
                canvasGroup.alpha = 1f;
                canvasGroup.blocksRaycasts = true;
                if (eventData.pointerDrag.transform.gameObject.tag != "Tag")
                {
                    var data = eventData.pointerDrag.transform.gameObject.GetComponent<CheckList>();
                    manager.CreateCheckListItem(data.objName, data.type, data.Tag, data.completed, data.urgency);

                    foreach (var item in manager.checklistObjects)
                    {
                        if (item == data)
                        {
                            manager.DeleteItem(data);
                            Destroy(data.gameObject);
                        }
                    }
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

        public void OnPointerDown(PointerEventData eventData)
        {
            isPressed = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isPressed = false;
        }
        void Update()
        {
            if(isPressed)
            {
                pointerDownTimer += Time.deltaTime;
                if(pointerDownTimer>= requiredHold && !manager.isEditing)
                {
                    manager.EditMode();

                    Reset();
                }
            }
            if(!isPressed && manager.isEditing)
            {
                manager.EditMode();
            }
        }
        private void Reset()
        {
            isPressed = false;
            pointerDownTimer = 0;
        }
    }
}