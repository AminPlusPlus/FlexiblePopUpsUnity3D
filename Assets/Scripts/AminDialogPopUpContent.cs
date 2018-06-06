using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AminDialogPopUp.Interface;

namespace AminDialogPopUp
{
    public class AminDialogPopUpContent : MonoBehaviour, IAminDialogPopUpTitle, IAminDialogPopUpContent
    {
        #region  Kind Of Singelton
        private static AminDialogPopUpContent _instance;

        public static AminDialogPopUpContent Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<AminDialogPopUpContent>();
                }

                return _instance;
            }
        }

        #endregion

        private PopUpData _popUpData = new PopUpData();
        #region Private Class For Holding Dialog Data

        private class ButtonData
        {
            public string name { get; set; }
            public Action btnAction { get; set; }
        }

        private class ResourceData
        {
            public string amountRes { get; set; }
            public Sprite iconRes { get; set; }
        }

        private class PopUpData
        {
            public string title { get; set; }
            public string bodyMessage { get; set; }
            public Sprite icon { get; set; }
            public List<ButtonData> buttons { get; private set; }
            public List<ResourceData> resources { get; private set; }
            public PopUpData()
            {
                buttons = new List<ButtonData>();
                resources = new List<ResourceData>();
            }
        }
        #endregion
        #region UI Elements 
        [Header("UI Elements")]
        [Space(5)]
        [SerializeField] private Text title;
        [SerializeField] private Text bodyMessage;
        [SerializeField] private Image iconPopUp;
        [SerializeField] private Transform buttonContainer;
        [SerializeField] private Transform resourceContainer;

        [Space(5)]
        [Header("UI Prefabs")]
		[SerializeField] GameObject popUpPrefab;
        [SerializeField] GameObject buttonPrefab;
        [SerializeField] GameObject valuePrefab;

        #endregion
        #region Interfaces Implementations 
        /// <summary>
        /// Set Title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public IAminDialogPopUpContent setTitle(string title)
        {
            _popUpData.title = title;
            return this;
        }
        /// <summary>
        /// Add Button and apply action
        /// </summary>
        /// <param name="text"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public IAminDialogPopUpContent addButton(string text, Action action)
        {
            _popUpData.buttons.Add(new ButtonData
            {
                name = text,
                btnAction = action
            });
            return this;
        }

        /// <summary>
        /// Add Resources value and Icon
        /// </summary>
        /// <param name="value"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public IAminDialogPopUpContent addResources(string value, Sprite icon)
        {
            _popUpData.resources.Add(new ResourceData
            {
                amountRes = value,
                iconRes = icon
            });

            return this;
        }
        /// <summary>
        /// Set Icon of PopUp by Sprite
        /// </summary>
        /// <param name="icon"></param>
        /// <returns></returns>
        public IAminDialogPopUpContent setIcon(Sprite icon)
        {
            _popUpData.icon = icon;
            return this;
        }

        /// <summary>
        /// Add Body Message to PopUp
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public IAminDialogPopUpContent setBodyMessage(string message)
        {
            _popUpData.bodyMessage = message;
            return this;
        }

        /// <summary>
        /// Finally Create PopUp
        /// </summary>
        /// <returns></returns>
        public IAminDialogPopUpContent create()
        {
            // set UI text Title
            title.text = _popUpData.title;
            bodyMessage.text = _popUpData.bodyMessage;

            // cleaning button and recources from Containers
            foreach (Transform btn in buttonContainer.transform)
            {
                Destroy(btn.gameObject);
            }

            foreach (Transform res in resourceContainer.transform)
            {
                Destroy(res.gameObject);
            }

            // setting Icon PopUp
            iconPopUp.sprite = _popUpData.icon;
            bodyMessage.text = _popUpData.bodyMessage;

            //creating button 
            _popUpData.buttons.ForEach(createButton);

            //creating resources
            _popUpData.resources.ForEach(createValue);
			
			// New PopUpData
			_popUpData = new PopUpData();

			// active PopUp
			popUpPrefab.SetActive(true);

            return this;
        }

        #endregion
        #region  Adding Button and Resources to Container

        // Button
        private void createButton(ButtonData buttonData)
        {
            GameObject btn = Instantiate(buttonPrefab);
            btn.transform.SetParent(buttonContainer);
            Button button = btn.GetComponent<Button>();
            Text label = btn.GetComponentInChildren<Text>();
            label.text = buttonData.name;
            button.onClick.AddListener(new UnityEngine.Events.UnityAction(buttonData.btnAction));
        }

        // Resources
        private void createValue(ResourceData valueData)
        {
            GameObject res = Instantiate(valuePrefab);
            res.transform.SetParent(resourceContainer);
            Text label = res.GetComponent<Text>();
            Image iconRes = res.GetComponentInChildren<Image>();
            label.text = valueData.amountRes;
			Debug.Log(iconRes.name);
            iconRes.sprite = valueData.iconRes;
        }

        #endregion


		public void closePopUp()
		{
			popUpPrefab.SetActive(false);
		}
	}
}