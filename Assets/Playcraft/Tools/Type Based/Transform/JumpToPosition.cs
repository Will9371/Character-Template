﻿using UnityEngine;

namespace Playcraft
{
    public class JumpToPosition : MonoBehaviour
    {
        public void SetPosition(Transform location)
        {
            transform.position = location.position;
        }
    }
}