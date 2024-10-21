using Core.Constructor;
using UnityEngine;

namespace Core.Interact
{
    public class CheckPanel : MonoBehaviour
    {
        [SerializeField] private StyleInit[] itemStyles;

        private StyleInit activeItem;

        private void Awake()
        {
            foreach (var item in itemStyles) 
            {
                if (item.IsActive)
                {
                    activeItem = item;
                    break;
                }
            }
        }

        public void Init()
        {
            itemStyles = transform.GetComponentsInChildren<StyleInit>();
            activeItem = itemStyles[0];
        }

        public void Check(int id)
        {
            activeItem.Deactivate();
            itemStyles[id].Activate();
            activeItem = itemStyles[id];
        }
    }
}
