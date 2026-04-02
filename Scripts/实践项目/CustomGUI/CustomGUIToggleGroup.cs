using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CustomGUIToggleGroup : MonoBehaviour
{
    public CustomGUIToggle[] toggles;
    private CustomGUIToggle frountToggle;

    private void Start()
    {
        toggles = this.GetComponentsInChildren<CustomGUIToggle>();
        foreach(var toggle in toggles)
        {
            toggle.changeEvent += (value) =>
            {
                if (value)
                {
                    for (int i = 0; i < toggles.Length; i++)
                    {
                        toggles[i].IsSelelct = false;
                    }
                    toggle.IsSelelct = true;
                    frountToggle = toggle;
                }
                else if (toggle == frountToggle) 
                {
                    toggle.IsSelelct = true;
                }
            };
        }
    }
}
