using System.Collections;
using System.Collections.Generic;
public class LightSaverFormula : AFormula {
    public LightSaverFormula() {
        formulaName = "LightSaver";
        dropNames = new List<string>(9);
        for (int i = 0; i < 9; i++)
            dropNames.Add(string.Empty);
        dropNames[0] = "Crystal_Blue";
        dropNames[2] = "Crystal_Yellow";
        dropNames[4] = "Crystal_Yellow";
        dropNames[6] = "Crystal_Yellow";
        dropNames[8] = "Crystal_Yellow";
    }
}