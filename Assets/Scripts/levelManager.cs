using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour, IPointerDownHandler
{ 
        [SerializeField] private string sceneName;
        [SerializeField] private string menuName;
        private float clickCoolDown;
        
        void Awake()
        {
            
            clickCoolDown = 5;
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene(menuName);
            }
        }


        public void OnPointerDown(PointerEventData eventData)
        {
            SceneManager.LoadScene(sceneName);
            
        }
}
