﻿using UnityEngine;

namespace Playcraft
{
    public class GetTransformFromArray : MonoBehaviour
    {
        #pragma warning disable 0649
        [SerializeField] Transform[] transforms;
        [SerializeField] TransformEvent Output;
        #pragma warning restore 0649
        
        public void Input(int value)
        {
            Output.Invoke(transforms[value]);
        }
    }
}
