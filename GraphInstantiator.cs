using UnityEngine;
using System.Collections;
//using System.Collections.Generic;

public class GraphInstantiator : MonoBehaviour
{
    //Declare Game Objects to be set by user
    public GameObject Cube;
    public GameObject Text;
    public GameObject xText;

    //Declare and Set Scale Value - This is set so that the objects dont appear to large
    public float scaleVal= .01f;
    public float containerScaleVal = .01f;
    private Vector3 cubeLoc = new Vector3(0f, 0.5f, 0f);
    private Vector3 textLoc = new Vector3(-.08024438f, -.07971092f, 0f); //.74f
    private Vector3 xtextLoc = new Vector3(-.08784437f, -.076f, 0f); //.74f
    public string GraphTitle;
    public string XAxisTitle;
    public string YAxisTitle;

    public float initGrowSpeed = 5f;

    private float growSpeed;

    public float growAcceleration = 0.2f;
    public float growDecellerationPoint = 0.4f;
    public float allowError = 0.001f;

    private float[] values = { 1000, 500, 400, 900, 1200, 200, 700 }; //X-Axis
    float[] NewValues;
    private string[] textLabel = { "Red", "Yellow", "BLue", "Cyan", "Green", "Gray", "Magenta" }; //Y-Axis Labels
    private float MaxValue;

    float[] initGrowSpeeds;// = { 10, 20, 40 };

    //Set BarGraph Colors
    private Color[] ObjectColor = { Color.red,  Color.yellow, Color.blue, Color.cyan, Color.green, Color.gray, Color.magenta, Color.grey };

    //Set Material
    public Material transparentMat;
    //private Color currentColor;
    //private Material materialColored;


    void Start()
    {
        //Set New Values
        float[] NewValues = SetNewValues();

        //Display and Construct Graph
        DisplayGraph(NewValues);

        initGrowSpeeds = NewValues;
    }

    // Function to set Scale to value so that Values dont make cube too High or too Short (New Vaules to be set beetbeen 1 and 10)
    public float[] SetNewValues()
    {
        MaxValue = Mathf.Max(values);
        NewValues = new float[values.Length];
        for (int i = 0; i < values.Length; i++)
        {         
            NewValues[i] = (values[i] / MaxValue)*10;
        }
        return NewValues;
    }

    void Update()
    {
        float CurPerCentage = 0;
        for (int i = 0; i < NewValues.Length; i++)
        {
            // Create Additional Cube Objects and X,Y Axis Labels
            string cubeName = "Cube" + i.ToString();
            string textName = "Text" + i.ToString();
            string xtextName = "xText" + i.ToString();

            //string xTextVal = (i + 1).ToString();

            // Find Declared Game Object Cube and Text Labels
            GameObject GO = GameObject.Find(cubeName);
            GameObject GOText = GameObject.Find(textName);

            GameObject GOCubeContainer = GameObject.Find("Cube");
            float newValue = NewValues[i] * scaleVal;
            float newInitGrowSpeeds = initGrowSpeeds[i] * scaleVal;
            

            if (GO.transform.localScale.y <= (NewValues[i] - allowError))
            {
                float cubeHeight = GO.transform.localScale.y;
                float growSpeed = newInitGrowSpeeds;

                if (cubeHeight >= (growDecellerationPoint * newValue))
                {
                    growSpeed = newInitGrowSpeeds - newInitGrowSpeeds * (1 - ((cubeHeight - newValue) /
                        (growDecellerationPoint * newValue - newValue)));
                }

                float prevCubeHeight = GO.transform.localScale.y;
                GO.transform.localScale += new Vector3(0f, growSpeed, 0f) * Time.deltaTime;
                //GOText.transform.localScale += new Vector3(0f, growSpeed, 0f) * Time.deltaTime;
                float newCubeHeight = GO.transform.localScale.y;
                //float newCubeWidth = GO.transform.localScale.x;
                

                GO.transform.position += Vector3.up * (newCubeHeight - prevCubeHeight) / 2;
                //GOxText.transform.position += Vector3.up * (newCubeHeight - prevCubeHeight) / 2;
                //Change Cube Length
                //GOCubeContainer.transform.localScale = new Vector3((values.Length*2)-2, 15f, 15f);

                //create a new material
                //materialColored = new Material(Shader.Find("Diffuse"));
                //materialColored.color = Color.red; //currentColor = ObjectColor;

                 //ObjectColor[i]; //materialColored;
                //GO.GetComponent<Renderer>().material = transparentMat;
                //GO.color = Color.red;
                //GO.renderer.material.color = Color.red;
            }
            GOText.GetComponent<TextMesh>().text = textLabel[i];
            //GOxText.GetComponent<TextMesh>().text = (i * 2).ToString() + "-";

            string yValue = (Mathf.Max(values) * CurPerCentage / 100).ToString() + "-";
            CurPerCentage += 20;
            if (i <= 5)
            {
                GameObject GOxText = GameObject.Find(xtextName);
                GOxText.GetComponent<TextMesh>().text = yValue;//(i * 2).ToString() + "-";
            }
            
            GO.GetComponent<Renderer>().material.color = ObjectColor[i];
        }
    }

    void DisplayGraph(float[] NewValues)
    {
        GameObject GOstart = GameObject.Find("Cube0");
        cubeLoc = new Vector3(GOstart.transform.position.x, GOstart.transform.position.y, GOstart.transform.position.z);
        GameObject GOxtext = GameObject.Find("xText0");
        Vector3 cubeLocInitPos = cubeLoc;
        Vector3 textLocInitPos = textLoc;
        Vector3 xtextLocInitPos = new Vector3(GOxtext.transform.position.x, GOxtext.transform.position.y, GOxtext.transform.position.z);
        //Vector3 xtextLocInitPos = xtextLoc;
        GameObject MetaCanvas = GameObject.Find("BarGraphGameObject");

        for (int i = 1; i < NewValues.Length; i++)
        {
            cubeLoc = cubeLocInitPos + Vector3.right * (scaleVal *2) * i;
            textLoc = textLocInitPos + Vector3.right * (scaleVal * 2) * i;
            //xtextLoc = xtextLocInitPos + Vector3.up * (scaleVal * 2) * i;
            GameObject newBar = Instantiate(Cube, cubeLoc, Quaternion.identity) as GameObject;
            GameObject newText = Instantiate(Text, textLoc, Quaternion.identity) as GameObject;
            //GameObject newxText = Instantiate(xText, xtextLoc, Quaternion.identity) as GameObject;
            //newText.transform.localScale = new Vector3(scaleVal, scaleVal, scaleVal);

            newBar.transform.SetParent(MetaCanvas.transform);
            newText.transform.SetParent(MetaCanvas.transform);
            //newxText.transform.SetParent(MetaCanvas.transform);

            Transform tf = newBar.GetComponent<Transform>();
            Debug.Log(cubeLoc.ToString());
            Debug.Log("{0}");

            newBar.name = "Cube" + i.ToString();
            newText.name = "Text" + i.ToString();
            //newxText.name = "xText" + i.ToString();
            newBar.GetComponent<Renderer>().material = transparentMat;
            //newBar.GetComponent<Renderer>().material.color = ObjectColor[i];
            //newBar.gameObject.GetComponentInChildren
        }
        for (int i = 1; i <= 5; i++)
        {
            xtextLoc = xtextLocInitPos + Vector3.up * (scaleVal * 2) * i;
            GameObject newxText = Instantiate(xText, xtextLoc, Quaternion.identity) as GameObject;
            newxText.transform.SetParent(MetaCanvas.transform);
            newxText.name = "xText" + i.ToString();
        }
        GameObject BarGraphTitle = GameObject.Find("Title");
        GameObject BarGraphXTitle = GameObject.Find("Label X Axis");
        GameObject BarGraphYTitle = GameObject.Find("Label Y Axis");
        BarGraphTitle.GetComponent<TextMesh>().text = GraphTitle;
        BarGraphXTitle.GetComponent<TextMesh>().text = XAxisTitle;
        BarGraphYTitle.GetComponent<TextMesh>().text = YAxisTitle;
        //GameObject MetaCanvas1 = GameObject.Find("MetaCanvasBarChart");
        //MetaCanvas1.transform.localScale = new Vector3(containerScaleVal, containerScaleVal, containerScaleVal);
    }
}