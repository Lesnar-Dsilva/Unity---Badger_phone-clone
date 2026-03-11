using UnityEngine;
using UnityEngine.UI;

public class UniversalButton : MonoBehaviour
{
    private Button btn;
    // [2026-03-10 17:45] The Awake() function runs when the component is loaded by Unity
    void Awake()
    {
        btn = GetComponent<Button>();

        // [2026-03-10 17:46] Now I'll add a function that every button this script is attached to will call.
        btn.onClick.AddListener(OnButtonPressed);
    }

    void OnButtonPressed()
    {
        Debug.Log(btn.gameObject.name);
    }
}
