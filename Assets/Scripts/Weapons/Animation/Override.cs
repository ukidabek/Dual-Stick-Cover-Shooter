using System;
using UnityEngine;

namespace BaseGameLogic.Animations
{
    [Serializable]
    public class Override
    {
        [SerializeField] private string animationName = string.Empty;
        public string AnimationName { get => animationName; }

        [SerializeField] private AnimationClip animationClip = null;

        public AnimationClip AnimationClip { get => animationClip; }

        public Override() { }

        public Override(string animationName, AnimationClip animationClip)
        {
            this.animationName = animationName;
            this.animationClip = animationClip;
        }
    }
}