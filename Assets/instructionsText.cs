using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class instructionsText : MonoBehaviour
{
    
    public Text instructions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        instructions.text = GlobalVariables.currentProcedure.StepList.steps[GlobalVariables.currentStep - 1].instructions;
    }
}
