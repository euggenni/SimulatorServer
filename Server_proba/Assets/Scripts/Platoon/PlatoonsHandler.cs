using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatoonsHandler : MonoBehaviour
{
    public Dropdown SelectPlatoon;
    public static Platoon SelectedPlatoon;
    public static List<Student> Students = new List<Student>();

    public void OnChangePlatoonDropdown()
    {
        SelectedPlatoon = PlatoonsManager.GetPlatoon(SelectPlatoon.captionText.text);
        Students = SelectedPlatoon.Students;
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
}
