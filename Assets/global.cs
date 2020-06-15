using UnityEngine;

public static class GlobalVariables {
    public static int currentStep = 1;
    public static int currentProcedureIndex = 0;
    public static Procedure currentProcedure = null;

    public static Vector3 lastOffset = new Vector3(-999, -999, -999);

    public static void ManageStep(int targetStep) {
        if (!(lastOffset.x == -999 && lastOffset.y == -999 && lastOffset.z == -999)) {
            CancelLastOffset();
        }
        currentStep = targetStep;
        Debug.Log("New step : " + targetStep);
        ManageOffset();
    }

    public static void ManageOffset() {
        Step step = currentProcedure.StepList.steps[GlobalVariables.currentStep - 1];

        GameObject[] objects = GameObject.FindGameObjectsWithTag("ARModel");
        for(int i = 0 ; i < objects.Length ; i++) {
            Vector3 originalPosition = objects[i].transform.position;
            objects[i].transform.position = new Vector3(
                originalPosition.x + step.offsetX,
                originalPosition.y + step.offsetY,
                originalPosition.z + step.offsetZ
            );
            Debug.Log("offset : " + step.offsetX + " , " + step.offsetY + " , " + step.offsetZ);
            Debug.Log("New position : " + objects[i].transform.position.ToString());
        }

        lastOffset = new Vector3(step.offsetX, step.offsetY, step.offsetZ);
    }

    public static void CancelLastOffset() {
        Step step = currentProcedure.StepList.steps[GlobalVariables.currentStep - 1];

        GameObject[] objects = GameObject.FindGameObjectsWithTag("ARModel");
        for(int i = 0 ; i < objects.Length ; i++) {
            Vector3 originalPosition = objects[i].transform.position;
            objects[i].transform.position = new Vector3(
                originalPosition.x - step.offsetX,
                originalPosition.y - step.offsetY,
                originalPosition.z - step.offsetZ
            );
        }
    }
}