using System.Collections;
using System.Collections.Generic;
public class DefenseCircleFormula : AFormula {
    public DefenseCircleFormula() {
        formulaName = "DefenseCircle";
        dropNames = new List<string>(9);
        for (int i = 0; i < 9; i++)
            dropNames.Add(string.Empty);
        dropNames[0] = "DarkRock";
        dropNames[1] = "Crystal_Blue";
        dropNames[2] = "Crystal_Blue";
        dropNames[3] = "Crystal_Blue";
        dropNames[4] = "Crystal_Blue";
        dropNames[5] = "Crystal_Blue";
        dropNames[6] = "Crystal_Blue";
        dropNames[7] = "Crystal_Blue";
        dropNames[8] = "Crystal_Blue";
    }
}