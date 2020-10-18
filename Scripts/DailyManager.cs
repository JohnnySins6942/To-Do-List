using System;
using UnityEngine;
using UnityEngine.UI;


namespace Michsky.UI.ModernUIPack
{
    public class DailyManager : MonoBehaviour
    {
        private bool TaskBarisOpen;

        public GameObject taskBar;

        public Animator animate;

        public GameObject DayPanelInfo;

        public Manager manager;

        public GameObject TagPanel;
        public GameObject HomePanel;
        public GameObject AlarmPanel;
        public GameObject ShopPanel;

        public GameObject CloseAlarmPanel;

        private AnimatedIconHandler icon;

        private void Start()
        {
            TaskBarisOpen = false;
            icon = FindObjectOfType<AnimatedIconHandler>();
        }
        public void OpenAlarms()
        {
            CloseAlarmPanel.SetActive(true);
        }
        public void Navigate(int page)
        {
            switch (page)
            {
                case 0:
                    TagPanel.SetActive(false);
                    AlarmPanel.SetActive(false);
                    HomePanel.SetActive(true);
                    icon.isClicked = true;
                    icon.ClickEvent();
                    OpenTaskBar();
                    break;
                case 1:
                    TagPanel.SetActive(false);
                    AlarmPanel.SetActive(false);
                    HomePanel.SetActive(false);
                    icon.isClicked = true;
                    icon.ClickEvent();
                    OpenTaskBar();
                    break;
                case 2:
                    TagPanel.SetActive(true);
                    AlarmPanel.SetActive(false);
                    HomePanel.SetActive(false);
                    icon.isClicked = true;
                    icon.ClickEvent();
                    OpenTaskBar();
                    break;
                case 3:
                    TagPanel.SetActive(false);
                    AlarmPanel.SetActive(true);
                    HomePanel.SetActive(false);
                    icon.isClicked = true;
                    icon.ClickEvent();
                    OpenTaskBar();
                    break;
                case 4:
                    TagPanel.SetActive(false);
                    AlarmPanel.SetActive(false);
                    HomePanel.SetActive(false);
                    icon.isClicked = true;
                    icon.ClickEvent();
                    OpenTaskBar();
                    break;
            }
        }

        public void FirstTimeSequence()
        {
            PlayerPrefs.SetInt("hasPlayed", 1);
        }
        public void CloseSetAlarm()
        {
            AlarmPanel.SetActive(false);
        }
        public void OpenTaskBar()
        {
            if (TaskBarisOpen)
            {
                taskBar.SetActive(false);
                TaskBarisOpen = false;
                return;
            }
            if (!TaskBarisOpen)
            {
                taskBar.SetActive(true);
                TaskBarisOpen = true;
                return;
            }
        }
     

    }
}