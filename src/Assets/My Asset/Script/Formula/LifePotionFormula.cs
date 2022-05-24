using System.Collections;
using System.Collections.Generic;
public class LifePotionFormula : AFormula {
    public LifePotionFormula() {
        formulaName = "LifePotion";
        dropNames = new List<string>(9);
        for (int i = 0; i < 9; i++)
            dropNames.Add(string.Empty);
        dropNames[0] = "HolyWater";
        dropNames[2] = "blob";
        dropNames[4] = "blob";
        dropNames[6] = "blob";
        dropNames[8] = "blob";
    }
}