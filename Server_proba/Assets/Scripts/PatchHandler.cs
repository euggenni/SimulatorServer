using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using SFB;

public class PatchHandler : MonoBehaviour
{
    public InputField PatchSaveInputField; //поле с текстом сохранения пути

    public void OpenDialog() //запускает меню выбора пути
    {
        //var path = StandaloneFileBrowser.SaveFilePanel("", "", "", "txt");
        var path = StandaloneFileBrowser.OpenFolderPanel("", "", false);
        PatchSaveInputField.text = path[0];
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
