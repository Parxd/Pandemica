using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TextScript : MonoBehaviour
{
    int interval = 1;
    float nextTime = 0;
    private string txtDocumentName = Application.streamingAssetsPath + "/Log/" + "Data" + ".txt";
    // Start is called before the first frame update
    void Start()
    {
        File.WriteAllText(txtDocumentName, string.Empty);
        Directory.CreateDirectory(Application.streamingAssetsPath + "/Log/");
        File.WriteAllText(txtDocumentName, "Susceptible,Infected,Recovered\n");
    }

    // Update is called once per frame
    void Update()
    {
        string susceptibles = GetComponent<ManagerScript>().susceptiblePopulation.ToString();
        string infecteds = GetComponent<ManagerScript>().infectedPopulation.ToString();
        string recovereds = GetComponent<ManagerScript>().recoveredPopulation.ToString();
        if (Time.time >= nextTime)
        {
            File.AppendAllText(txtDocumentName, susceptibles + "," + infecteds + "," + recovereds + "\n");
            nextTime += interval;
        }
    }
}
