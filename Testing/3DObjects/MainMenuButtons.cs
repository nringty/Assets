using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour {

    public GameObject Dragonfly;
    public GameObject Ant;
    public GameObject Car;
    public GameObject Plane;
    public GameObject Earth;
    public GameObject Architecture;
    public GameObject Videos;
    public GameObject Education;
    public GameObject Presentation;
    public GameObject BarGraph;
    public GameObject Hospital;
    public GameObject Settings;
    

    // Use this for initialization
    void Start() {
        //bool test = Dragonfly.activeSelf;
        //Dragonfly.SetActive(true);
        //bool test1 = Dragonfly.activeSelf;

    }

    // Update is called once per frame
    //void Update () {

    //}
    private void btnToggle(GameObject GameObj, Button btn)
    {
        var newColor = btn.colors;
        if (GameObj.activeSelf == false)
        {
            newColor.normalColor = Color.gray;
            GameObj.SetActive(true);
            //cb.highlightedColor = Color.gray;
        }
        else
        {
            newColor.normalColor = Color.white;
            GameObj.SetActive(false);
            //cb.highlightedColor = Color.white;
        }
        btn.colors = newColor;

    }
    // Open Dragonfly Model
    public void OpenDrogonfly()
    {
        //Dragonfly.SetActive(true);
        Button btn = GameObject.Find("Button (2)").GetComponent<Button>();
        btnToggle(Dragonfly, btn);
    }
    public void OpenAnt()
    {
        Button btn = GameObject.Find("Button (1)").GetComponent<Button>();
        btnToggle(Ant, btn);
    }
    public void OpenCar()
    {
        Button btn = GameObject.Find("Button (3)").GetComponent<Button>();
        btnToggle(Car, btn); 
    }
    public void OpenPlane()
    {
        Button btn = GameObject.Find("Button (4)").GetComponent<Button>();
        btnToggle(Plane, btn);
    }
    public void OpenEarth()
    {
        Button btn = GameObject.Find("Button (5)").GetComponent<Button>();
        btnToggle(Earth, btn);
    }
    public void OpenArchitecture()
    {
        Button btn = GameObject.Find("Button (6)").GetComponent<Button>();
        btnToggle(Architecture, btn);
    }
    public void OpenVideos()
    {
        Button btn = GameObject.Find("Button (7)").GetComponent<Button>();
        btnToggle(Videos, btn);
    }
    public void OpenEducation()
    {
        Button btn = GameObject.Find("Button (8)").GetComponent<Button>();
        btnToggle(Education, btn);
    }
    public void OpenPresentation()
    {
        Button btn = GameObject.Find("Button (9)").GetComponent<Button>();
        btnToggle(Presentation, btn);
    }
    public void OpenBarGraph()
    {
        Button btn = GameObject.Find("Button (10)").GetComponent<Button>();
        btnToggle(BarGraph, btn);
    }
    public void OpenHospital()
    {
        Button btn = GameObject.Find("Button (11)").GetComponent<Button>();
        btnToggle(Hospital, btn);
    }
    public void OpenSettings()
    {
        Button btn = GameObject.Find("Button (12)").GetComponent<Button>();
        btnToggle(Settings, btn);
    }
}
