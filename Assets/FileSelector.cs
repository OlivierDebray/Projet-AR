using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class FileSelector : MonoBehaviour
{

    public Dropdown fileSelector;

    public GameObject instructionsText;
    public GameObject currentStepText;
    public GameObject prevStepBtn;
    public GameObject nextStepBtn;

    // Start is called before the first frame update
    void Start()
    {
        char[] separators = {'\\', '/'};
        Dictionary<string, string> xmlNamesAndPaths = new Dictionary<string, string>();

        List<string> options = new List<string> ();
        Debug.Log(Application.persistentDataPath);
        foreach (string filePath in Directory.GetFiles(Application.persistentDataPath + "/Procedures", "*.xml"))
        {
            // Procedure procedure = DeserializeObject(filePath);
            string name = filePath.Remove(0, filePath.LastIndexOfAny(separators) + 1);
            options.Add(name);
            xmlNamesAndPaths.Add(name, filePath);
        }
        fileSelector.AddOptions(options);

        fileSelector.onValueChanged.AddListener((value) => {
            GlobalVariables.currentProcedureIndex = value;
            if (value == 0) {
                instructionsText.SetActive(false);
                currentStepText.SetActive(false);
                prevStepBtn.SetActive(false);
                nextStepBtn.SetActive(false);
                GlobalVariables.currentProcedure = null;
                GlobalVariables.lastOffset = new Vector3(-999, -999, -999);
            } else {
                instructionsText.SetActive(true);
                currentStepText.SetActive(true);
                prevStepBtn.SetActive(true);
                nextStepBtn.SetActive(true);
                GlobalVariables.currentProcedure = DeserializeObject(xmlNamesAndPaths[fileSelector.options[value].text]);
                GlobalVariables.ManageStep(1);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Procedure DeserializeObject(string filename)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Procedure));

        Procedure procedure;

        using (Stream reader = new FileStream(filename, FileMode.Open))
        {
            procedure = (Procedure)serializer.Deserialize(reader);
        }

        // Debug.Log(
        // procedure.title + "\t" +
        // procedure.numberOfSteps + "\t" +
        // procedure.StepList.steps[0].instructions + "\t"   
        // );

        return procedure;
    }
}
