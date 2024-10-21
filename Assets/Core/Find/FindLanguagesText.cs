using Core.Constructor;
using UnityEngine;

namespace Core.Find
{
    public class FindLanguagesText : MonoBehaviour
    {
        public void FindText(int value)
        {
            PlayerPrefsContainer.SetLanguages(value);
            StyleInit[] buttonInit = FindObjectsOfType<StyleInit>();
            LanguagesInit[] textInits = FindObjectsOfType<LanguagesInit>();

            foreach (var text in textInits)
            {
               if(text !=null) text.Init();
            }
        }
    }
}
