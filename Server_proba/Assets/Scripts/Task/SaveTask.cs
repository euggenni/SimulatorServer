using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTask : MonoBehaviour {
    public RectTransform prefab;
    public RectTransform content;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void saveTask()
    {
        var instanse = Instantiate(prefab.gameObject) as GameObject;
        instanse.transform.SetParent(content, false);
    }
}
