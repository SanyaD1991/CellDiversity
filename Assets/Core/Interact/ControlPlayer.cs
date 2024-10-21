using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Core.Interact
{
    public class ControlPlayer : MonoBehaviour
    {
        [SerializeField] private VideoPlayer videoPlayer;
        [SerializeField] private Slider videoSlider;
        [SerializeField] private UnityEvent OnTheEnd;
        private bool isUpdatingSlider;
        private void Start()
        {            
            videoSlider.maxValue = (float)videoPlayer.length;
            videoPlayer.loopPointReached += End;
            videoSlider.onValueChanged.AddListener(OnSliderValueChanged);          

        }
        private void Update()
        {
            if (videoPlayer.isPlaying)
            {
                isUpdatingSlider = true;              
                videoSlider.value = (float)videoPlayer.time;
                isUpdatingSlider = false;
            }
        }

      

        private void End(VideoPlayer vp)
        {
            isUpdatingSlider = true;
            videoSlider.value = 0;
            OnTheEnd?.Invoke();
            isUpdatingSlider = false;
        }

        void OnSliderValueChanged(float value)
        {
            if (!isUpdatingSlider) videoPlayer.time = value;        
        }
    }
}
