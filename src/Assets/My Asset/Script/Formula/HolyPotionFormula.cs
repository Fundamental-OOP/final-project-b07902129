using System.Collections;
using System.Collections.Generic;
public class HolyPotionFormula : AFormula {
    public HolyPotionFormula() {
        formulaName = "HolyPotion";
        dropNames = new List<string>(9);
        for (int i = 0; i < 9; i++)
            dropNames.Add(string.Empty);
        dropNames[0] = "HolyWater";
        dropNames[2] = "Sap";
        dropNames[4] = "Sap";
        dropNames[6] = "Sap";
        dropNames[8] = "Sap";
    }
}