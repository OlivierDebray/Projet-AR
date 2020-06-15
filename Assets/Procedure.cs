using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

public class Procedure {
    public string title { get; set; }
    public int numberOfSteps { get; set; }
    // public Dictionary<string, ProcedureStep> steps { get; set; }
    [XmlElement("step_list")]
    public StepList StepList;
}

public class StepList {
    public StepList() {steps = new List<Step>();}
    [XmlElement("step")]
    public List<Step> steps { get; set; }
}

public class Step {
    [XmlElement("id")]
    public int id { get; set; }
    [XmlElement("instruction")]
    public string instructions { get; set; }
    [XmlElement("offsetX")]
    public int offsetX { get; set; }
    [XmlElement("offsetY")]
    public int offsetY { get; set; }
    [XmlElement("offsetZ")]
    public int offsetZ { get; set; }
}