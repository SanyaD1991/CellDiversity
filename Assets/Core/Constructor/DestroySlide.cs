using Core.Managers;
using UnityEngine;

namespace Core.Constructor
{
    public class DestroySlide : MonoBehaviour
    {
        public void OnRemove()
        {
            NavigationManager navigation = FindObjectOfType<NavigationManager>();
            if (navigation != null) navigation.RemoveSlide();
        }
        public void OnHome()
        {
            NavigationManager navigation = FindObjectOfType<NavigationManager>();
            if (navigation != null) navigation.HomeSlide();
        }
    }
}
