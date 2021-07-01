using System.Collections;
using System.Collections.Generic;
public class PickaxeFormula : AFormula {
    public PickaxeFormula() {
        formulaName = "Pickaxe";
        dropNames = new List<string>(9);
        for (int i = 0; i < 9; i++)
            dropNames.Add(string.Empty);
        dropNames[0] = "Wood";
        dropNames[1] = "Wood";
        dropNames[4] = "Wood";
        dropNames[7] = "Wood";
        dropNames[8] = "Wood";
    }
}