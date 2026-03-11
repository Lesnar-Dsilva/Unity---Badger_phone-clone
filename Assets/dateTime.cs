using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(TextMeshProUGUI))]
// [2026-03-10 16:16] This forces Unity to make sure this specific component exists in the code and the project (if component is in another script)
public class dateTime : MonoBehaviour
{

    private TextMeshProUGUI dateTimeObject;

    // Update is called once per frame
    void Update()
    {
        // [2026-03-10 16:06] DO NOT declare now, in the class, it NEEDS to be in the function, as the function is ran every frame, it needs to retrieve from the System (class) the updated information
        DateTime now = DateTime.Now;
        // [2026-03-10 15:48] This line is necessary because it tells the system what type of component it's working with (I know the variable is declared as the same type...)
        dateTimeObject = GetComponent<TextMeshProUGUI>();
        // [2026-03-10 16:13] Keeping a universal standard, DON'T want americans to get confused with the European style of writing dates
        dateTimeObject.text = now.ToString("d MMM y \nHH:mm:ss");
    }
}
