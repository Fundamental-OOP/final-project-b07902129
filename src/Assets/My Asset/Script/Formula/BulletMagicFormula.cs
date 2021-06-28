using System.Collections;
using System.Collections.Generic;
public class BulletMagicFormula : AFormula {
    public BulletMagicFormula() {
        formulaName = "BulletMagic";
        dropNames = new List<string>(9);
        for (int i = 0; i < 9; i++)
            dropNames.Add(string.Empty);
        dropNames[1] = "BulletMagic";
        dropNames[3] = "BulletMagic1";
        dropNames[5] = "BulletMagic2";
        dropNames[7] = "BulletMagic3";
    }
}