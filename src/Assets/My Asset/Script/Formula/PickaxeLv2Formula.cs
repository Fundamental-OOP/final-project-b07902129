using System.Collections;
using System.Collections.Generic;
public class PickaxeLv2Formula : AFormula {
    public PickaxeLv2Formula() {
        formulaName = "PickaxeLv2";
        dropNames = new List<string>(9);
        for (int i = 0; i < 9; i++)
            dropNames.Add(string.Empty);
        dropNames[0] = "Pickaxe";
        dropNames[1] = "Crystal_Purple";
        dropNames[7] = "Crystal_Purple";
        dropNames[8] = "Crystal_Purple";
    }
}