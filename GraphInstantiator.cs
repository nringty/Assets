using UnityEngine;
using System.Collections;
//using System.Collections.Generic;

public class GraphInstantiator : MonoBehaviour
{

    public GameObject Cube;
    public GameObject Text;
    public GameObject xText;
    public float scaleVal= .01f;
    public float containerScaleVal = .01f;
    private Vector3 cubeLoc = new Vector3(0f, 0.5f, 0f);
    private Vector3 textLoc = new Vector3(-.08024438f, -.07971092f, .74f);
    private Vector3 xtextLoc = new Vector3(-.08784437f, -.08010092f, .74f);

    public float initGrowSpeed = 5f;

    private float growSpeed;

    public float growAcceleration = 0.2f;
    public float growDecellerationPoint = 0.4f;
    public float allowError = 0.001f;

    private float[] values = { 10, 5, 4, 9, 12, 2, 7 };
    private string[] textLabel = { "text 1", "text 2", "text 3", "text 4", "text 5", "text 6", "text 7" };


    float[] initGrowSpeeds;// = { 10, 20, 40 };


    private Color[] ObjectColor = { Color.red,  Color.yellow, Color.blue, Color.cyan, Color.green, Color.gray, Color.magenta, Color.grey };

    public Material transparentMat;
    //private Color currentColor;
    //private Material materialColored;


    void Start()
    {
        DisplayGraph(values);
        initGrowSpeeds = values;
    }

    void Update()
    {
        for (int i = 0; i < values.Length; i++)
        {
            string cubeName = "Cube" + i.ToString();
            string textName = "Text" + i.ToString();
            string xtextName = "xText" + i.ToString();
            //string xTextVal = (i + 1).ToString();
            GameObject GO = GameObject.Find(cubeName);
            GameObject GOText = GameObject.Find(textName);
            GameObject GOxText = GameObject.Find(xtextName);
            GameObject GOCubeContainer = GameObject.Find("Cube");
            float newValue = values[i] * scaleVal;
            float newInitGrowSpeeds = initGrowSpeeds[i] * scaleVal;

            if (GO.transform.localScale.y <= (newValue - allowError))
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
            GOxText.GetComponent<TextMesh>().text = (i * 2).ToString() + "-";
            GO.GetComponent<Renderer>().material.color = ObjectColor[i];
        }
    }

    void DisplayGraph(float[] values)
    {
        GameObject GOstart = GameObject.Find("Cube0");
        cubeLoc = new Vector3(GOstart.transform.position.x, GOstart.transform.position.y, GOstart.transform.position.z);
        Vector3 cubeLocInitPos = cubeLoc;
        Vector3 textLocInitPos = textLoc;
        Vector3 xtextLocInitPos = xtextLoc;
        GameObject MetaCanvas = GameObject.Find("BarGraphGameObject");

        for (int i = 1; i < values.Length; i++)
        {
            cubeLoc = cubeLocInitPos + Vector3.right * (scaleVal *2) * i;
            textLoc = textLocInitPos + Vector3.right * (scaleVal * 2) * i;
            xtextLoc = xtextLocInitPos + Vector3.up * (scaleVal * 2) * i;
            GameObject newBar = Instantiate(Cube, cubeLoc, Quaternion.identity) as GameObject;
            GameObject newText = Instantiate(Text, textLoc, Quaternion.identity) as GameObject;
            GameObject newxText = Instantiate(xText, xtextLoc, Quaternion.identity) as GameObject;
            //newText.transform.localScale = new Vector3(scaleVal, scaleVal, scaleVal);

            newBar.transform.SetParent(MetaCanvas.transform);
            newText.transform.SetParent(MetaCanvas.transform);
            newxText.transform.SetParent(MetaCanvas.transform);

            Transform tf = newBar.GetComponent<Transform>();
            Debug.Log(cubeLoc.ToString());
            Debug.Log("{0}");

            newBar.name = "Cube" + i.ToString();
            newText.name = "Text" + i.ToString();
            newxText.name = "xText" + i.ToString();
            newBar.GetComponent<Renderer>().material = transparentMat;
            //newBar.GetComponent<Renderer>().material.color = ObjectColor[i];
            //newBar.gameObject.GetComponentInChildren
        }
        //GameObject MetaCanvas1 = GameObject.Find("MetaCanvasBarChart");
        //MetaCanvas1.transform.localScale = new Vector3(containerScaleVal, containerScaleVal, containerScaleVal);
    }
}