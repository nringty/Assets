using UnityEngine;
using System.Collections;
//using System.Collections.Generic;
 
public class GraphInstantia : MonoBehaviour
{

    public GameObject Cube;
    private Vector3 cubeLoc = new Vector3(0f, 0.5f, -5f);

    public float initGrowSpeed = 5f;

    private float growSpeed;

    public float growAcceleration = 0.2f;
    public float growDecellerationPoint = 0.4f;
    public float allowError = 0.001f;

    float[] values = { 10, 5, 4, 9, 12, 1, 7 };
    float[] initGrowSpeeds;// = { 10, 20, 40 };

    void Start()
    {
        DisplayGraph(values);
        initGrowSpeeds = values;
    }

    void Update()
    {
        for (int i = 0; i < values.Length; i++)
        {
            string cubeName = "Cube " + i.ToString();
            GameObject GO = GameObject.Find(cubeName);

            if (GO.transform.localScale.y <= (values[i] - allowError))
            {
                float cubeHeight = GO.transform.localScale.y;
                float growSpeed = initGrowSpeeds[i];

                if (cubeHeight >= (growDecellerationPoint * values[i]))
                {
                    growSpeed = initGrowSpeeds[i] - initGrowSpeeds[i] * (1 - ((cubeHeight - values[i]) /
                        (growDecellerationPoint * values[i] - values[i])));
                }

                float prevCubeHeight = GO.transform.localScale.y;
                GO.transform.localScale += new Vector3(0f, growSpeed, 0f) * Time.deltaTime;
                float newCubeHeight = GO.transform.localScale.y;
                GO.transform.position += Vector3.up * (newCubeHeight - prevCubeHeight) / 2;
            }
        }
    }

    void DisplayGraph(float[] values)
    {
        Vector3 cubeLocInitPos = cubeLoc;
        for (int i = 0; i < values.Length; i++)
        {
            cubeLoc = cubeLocInitPos + Vector3.right * 2 * i;
            GameObject newBar = Instantiate(Cube, cubeLoc, Quaternion.identity) as GameObject;
            Transform tf = newBar.GetComponent<Transform>();
            Debug.Log(cubeLoc.ToString());
            Debug.Log("{0}");

            newBar.name = "Cube " + i.ToString();
        }
    }
}