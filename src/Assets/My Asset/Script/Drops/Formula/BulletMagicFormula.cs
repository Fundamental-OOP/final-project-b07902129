using System.Collections;
using System.Collections.Generic;
public class BulletMagicFormula : AFormula {
    public BulletMagicFormula() {
        formulaName = "BulletMagic";
        dropNames = new List<string>(13);
        for (int i = 0; i < 13; i++)
            dropNames.Add(string.Empty);
        dropNames[0] = "Sapphire";
        dropNames[1] = "Sapphire";
        dropNames[3] = "Sapphire";
        dropNames[5] = "Sapphire";
        dropNames[7] = "Sapphire";
    }
}