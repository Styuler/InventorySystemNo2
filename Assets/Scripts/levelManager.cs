using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour, IPointerDownHandler
{ 
        public string sceneName;
        private float clickCoolDown;
        
        void Awake()
        {
            
            clickCoolDown = 5;
        }
    
        
    
        public void OnPointerDown(PointerEventData eventData)
        {
            SceneManager.LoadScene(sceneName);
            
        }
}
