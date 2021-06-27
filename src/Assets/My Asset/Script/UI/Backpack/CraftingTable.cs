using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTable : MonoBehaviour {
    private IList<AFormula> formulas;
    private IList<Slot> slots;
    private AButton craftButton;
    private Dictionary<string, GameObject> craftsPrefabs;

    void Awake() {
        loadFormulas();
        craftsPrefabs = new Dictionary<string, GameObject>();

        var prefabs = PrefabLoadder.loadAllPrefab("Prefab/Craftable");
        for (int i = 0; i < prefabs.Length; i++) {
            Debug.Log(string.Format("Prefab name: {0}", prefabs[i].name));
            craftsPrefabs.Add(prefabs[i].name, prefabs[i]);
        }


        Debug.Log(string.Format("Prefabs Count: {0}", prefabs.Length));

        slots = new List<Slot>();
        for (int i = 0; i < 13; i++) {
            var sl = gameObject.transform.Find("Slot" + i.ToString()).gameObject;
            Debug.Log(string.Format("Slot {0} {1}", i, sl.name));
            slots.Add( gameObject.transform.Find("Slot" + i.ToString()).gameObject.GetComponent<Slot>() );
        }


        craftButton = gameObject.transform.Find("Craft").gameObject.GetComponent<AButton>();
    }

    private void loadFormulas() {
        formulas = new List<AFormula>();
        formulas.Add(new BulletMagicFormula());
    }

    void Update() {
        if (craftButton.isPressed())
            craft();
    }

    private void craft() {
        int matchedFormula = getMatchedFormula();
        Debug.Log(string.Format("MatchedFormula: {0}", matchedFormula));
        if (matchedFormula == -1) return;
        destroyObjectsOnTable();
        instantiateCraftedObject(matchedFormula);
    }

    private int getMatchedFormula() {
        var onTableObjects = new List<GameObject>();
        for (int i = 0; i < 13; i++) {
            if (slots[i].transform.childCount == 0)
                onTableObjects.Add(null);
            else if (slots[i].transform.childCount == 1)
                onTableObjects.Add(slots[i].transform.GetChild(0).gameObject);
        }
        for (int i = 0; i < formulas.Count; i++)
            if (formulas[i].isMatched(onTableObjects))
                return i;
        return -1;
    }

    private void destroyObjectsOnTable() {
        for (int i = 0; i < 13; i++)
            if (slots[i].transform.childCount == 1)
                Destroy(slots[i].transform.GetChild(0).gameObject);
    }
    public void instantiateCraftedObject(int formulaID) {
        var craftedObject = Instantiate(craftsPrefabs[formulas[formulaID].getName()]);
        craftedObject.transform.position = slots[0].gameObject.transform.position;
        craftedObject.transform.SetParent(slots[0].gameObject.transform);
    }

}