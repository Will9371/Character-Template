﻿using UnityEngine;
using UnityEngine.SceneManagement;

namespace Playcraft
{
    public class SceneController : MonoBehaviour
    {
        public void SetScene(string name)
        {
            SceneManager.LoadScene(name);
        }

        public void ResetScene()
        {
            Scene scene = SceneManager.GetActiveScene();
            SetScene(scene.name);
        }
    }
}

