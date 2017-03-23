using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

    [SerializeField]
    private int Value;
    [SerializeField]
    private float flashCoolDown;
    private float flashCounter;
    private bool flashBool;
    public int value { get; set; }

	// Use this for initialization
	void Start () {
        flashBool = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if(flashCounter >= 0)
        {
            flashCounter -= Time.deltaTime;
        }
	}

    void Destroy()
    {

    }

    public void flash(float intensity)
    {
        if(flashCounter < 0)
        {
            flashCounter = flashCoolDown;
            Material material = GetComponent<Renderer>().material;
            if(!flashBool)
            {
                material.SetColor("_EmissionColor", new Color(intensity, intensity, intensity));
                flashBool = true;
            } else
            {
                material.SetColor("_EmissionColor", new Color(0, 0, 0));
                flashBool = false;
            }
        }
    }

    public void resetFlashing()
    {
        GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0, 0, 0));
        flashBool = false;
    }
}
