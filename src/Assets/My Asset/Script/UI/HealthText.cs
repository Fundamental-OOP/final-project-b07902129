using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HealthText : MonoBehaviour
{
    // Start is called before the first frame update
    public Lifeform host;
    private TextMeshProUGUI text;
    void Start()
    {
        host = GameObject.Find("MainCharacter").GetComponent<Lifeform>();
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText(host.health.ToString());
    }
}
