using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatoonsHandler : MonoBehaviour
{
    public Dropdown SelectPlatoon;
    public GameObject toggle;
    public static Platoon SelectedPlatoon;



    public void OnChangePlatoonDropdown()
    {
        SelectedPlatoon = PlatoonsManager.GetPlatoon(SelectPlatoon.captionText.text);
    }

    // Start is called before the first frame update
    void Start()
    {
        PlatoonsManager.LoadPlatoons();
        PlatoonsManager.Platoons.Sort();
        SelectPlatoon.options.Clear();
        foreach(Platoon platoon in PlatoonsManager.Platoons)
        {
            SelectPlatoon.options.Add(new Dropdown.OptionData(platoon.NamePlatoon));
        }
        SelectPlatoon.options.Add(new Dropdown.OptionData("123"));
        SelectPlatoon.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void View()
    {
        toggle.SetActive(true);
    }

    public void Click()
    {
        Invoke("View", 9.5f);
    }
}
