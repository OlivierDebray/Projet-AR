using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentStepText : MonoBehaviour
{
    
    public Text currentStepText;
    public Button prevStepBtn;
    public Button nextStepBtn;

    // Start is called before the first frame update
    void Start()
    {
        prevStepBtn.onClick.AddListener(() => {
            if (GlobalVariables.currentStep > 1) {
                GlobalVariables.ManageStep(GlobalVariables.currentStep - 1);
                // GlobalVariables.currentStep--;
            }
        });
        nextStepBtn.onClick.AddListener(() => {
            if (GlobalVariables.currentStep < GlobalVariables.currentProcedure.StepList.steps.Count) {
                GlobalVariables.ManageStep(GlobalVariables.currentStep + 1);
                // GlobalVariables.currentStep++;
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        currentStepText.text = "Etape actuelle : " + GlobalVariables.currentStep.ToString();
    }
}
