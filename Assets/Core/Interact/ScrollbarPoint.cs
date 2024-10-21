using Core.Constructor;
using System.Drawing;
using System.Reflection;
using UnityEngine;

namespace Core.Interact
{
    public class ScrollbarPoint : MonoBehaviour
    {
        [SerializeField] StyleInit point;
        [SerializeField] CheckPanel check;
        private StyleInit[] points;
        public void InitScrollbar(int count)
        {
            points = new StyleInit[count];
            for (int i = 0; i < count; i++)
            {
                points[i] = Instantiate(point, transform);
                points[i].gameObject.SetActive(true);
                if (i == 0) points[i].Activate();
               
            }
            check.Init();
        }

        public void Check(int count)
        {
            check.Check(count);
        }
    }
}
