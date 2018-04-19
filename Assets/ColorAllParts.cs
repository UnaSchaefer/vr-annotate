using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAllParts : MonoBehaviour {

    private Component[] allRenderer;
    public Material mat;
	// Use this for initialization
	void Start () {
        allRenderer = GetComponentsInChildren<Renderer>();

        foreach (Renderer rnd in allRenderer)
        {
            rnd.material = mat;   
        }
        //Material mat = new Material(Shader.Find("Standard"));
        //Material mat = new Material(Shader.Find("test"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}