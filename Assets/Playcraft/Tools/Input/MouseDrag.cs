﻿using UnityEngine;

namespace Playcraft
{
    public class MouseDrag : MonoBehaviour
    {
        #pragma warning disable 0649
        [SerializeField] float xDragSensitivity = 1f;
        [SerializeField] float yDragSensitivity = 1f;
        [SerializeField] Vector2Event OutputMouseDelta;
        #pragma warning restore 0649
        
        bool active;
        float lastMouseY;
        float mouseYDelta;
        float lastMouseX;
        float mouseXDelta;
        
        public void SetActive(bool value) 
        { 
            active = value;
            
            if (active)
            {
                lastMouseX = Input.mousePosition.x;
                lastMouseY = Input.mousePosition.y;
            }
            else
            {
                mouseXDelta = 0;
                mouseYDelta = 0;
            }
        }
        
        private void Update()
        {
            if (active)
            {
                mouseXDelta = Input.mousePosition.x - lastMouseX;
                mouseYDelta = Input.mousePosition.y - lastMouseY;
                lastMouseX = Input.mousePosition.x;
                lastMouseY = Input.mousePosition.y;
            }
            
            var mouseDelta = new Vector2(mouseXDelta * xDragSensitivity, mouseYDelta * yDragSensitivity);
            OutputMouseDelta.Invoke(mouseDelta);
        }
    }
}