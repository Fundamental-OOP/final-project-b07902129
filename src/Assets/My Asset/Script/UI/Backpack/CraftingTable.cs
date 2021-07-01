using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTable : MonoBehaviour {
    public List<Slot> slots;
    private IList<AFormula> formulas;
    private AButton craftButton;
    private Dictionary<string, GameObject> craftsPrefabs;

    void Awake() {
        LoadFormulas();
        craftsPrefabs = new Dictionary<string, GameObject>();

        var prefabs = PrefabLoadder.loadAllPrefab("Prefab/Craftable");
        for (int i = 0; i < prefabs.Length; i++) {
            Debug.Log(string.Format("Prefab name: {0}", prefabs[i].name));
            craftsPrefabs.Add(prefabs[i].name, prefabs[i]);
        }


        Debug.Log(string.Format("Prefabs Count: {0}", prefabs.Length));

        craftButton = gameObject.transform.Find("Craft").gameObject.GetComponent<AButton>();
    }

    private void LoadFormulas() {
        formulas = new List<AFormula>();
        formulas.Add(new BulletMagicFormula());
    }

    void Update() {
        if (craftButton.IsPressed())
            Craft();
    }

    private void Craft() {
        int matchedFormula = GetMatchedFormula();
        Debug.Log(string.Format("MatchedFormula: {0}", matchedFormula));
        if (matchedFormula == -1) return;
        DestroyObjectsOnTable();
        InstantiateCraftedObject(matchedFormula);
    }

    private int GetMatchedFormula() {
        List<GameObject> onTableObjects = new List<GameObject>();
        for (int i = 0; i < 9; i++) {
            if (slots[i].IsEmpty())
                onTableObjects.Add(null);
            else
                onTableObjects.Add(slots[i].GetItem());
        }
        for (int i = 0; i < formulas.Count; i++)
        {
            if (formulas[i].IsMatched(onTableObjects))
                return i;
        }
           
        return -1;
    }

    private void DestroyObjectsOnTable() {
        for (int i = 0; i < 9; i++)
            if (!slots[i].IsEmpty()) {
                slots[i].DestroyItem();
            }
    }
    public void InstantiateCraftedObject(int formulaID) {
        var craftedObject = Instantiate(craftsPrefabs[formulas[formulaID].GetName()]);
        // craftedObject.transform.position = slots[0].gameObject.transform.position;
        // craftedObject.transform.SetParent(slots[0].gameObject.transform);
        slots[0].SetItem(craftedObject);
        craftedObject.SetActive(false);
    }

}