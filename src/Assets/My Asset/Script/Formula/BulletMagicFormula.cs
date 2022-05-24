using System.Collections;
using System.Collections.Generic;
public class BulletMagicFormula : AFormula {
    public BulletMagicFormula() {
        formulaName = "BulletMagic";
        dropNames = new List<string>(9);
        for (int i = 0; i < 9; i++)
            dropNames.Add(string.Empty);
        dropNames[0] = "Crystal_Purple";
        dropNames[1] = "DarkRock";
        dropNames[3] = "DarkRock";
        dropNames[5] = "DarkRock";
        dropNames[7] = "DarkRock";
    }
}