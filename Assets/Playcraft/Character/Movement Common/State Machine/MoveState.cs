﻿using UnityEngine;

namespace Playcraft
{
    [CreateAssetMenu(menuName = "Character/Move State Machine/State")]
    public class MoveState : ScriptableObject
    {
        public AnimatedMoveState animations;
        
        public bool disableSpeedControl;
        public float moveSpeed;
    }
}
