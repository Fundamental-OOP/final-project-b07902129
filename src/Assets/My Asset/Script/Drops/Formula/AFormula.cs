using System.Collections.Generic;
using UnityEngine;
abstract public class AFormula {
    protected string formulaName;
    protected IList<string> dropNames;

    public bool isMatched(IList<GameObject> drops) {
        if (drops.Count != 13) return false;
        for (int i = 0; i < 13; i++) {
            if (drops[i] == null && dropNames[i] == string.Empty)
                continue;
            else if (drops[i].name == dropNames[i])
                continue;
            else
                return false;
        }
        return true;
    }

    public string getName() {
        return formulaName;
    }

}