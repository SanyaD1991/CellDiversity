using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Interact
{
    public class ControlAnimation : MonoBehaviour
    {
        [SerializeField] private Animation animation;       

        public void PlayAnimationl(string name)
        {
           // if (animation.isPlaying) return;
            animation.Play(name);
        }        
    }
}
