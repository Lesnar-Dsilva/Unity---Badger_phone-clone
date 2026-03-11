using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuPopulator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private RectTransform contentParent; // Where the prefab with be added
    [SerializeField] private GameObject optionPrefab; // The prefab I created
    [SerializeField] private Button backButton; // The back button exists on the keypad, so I need it to always send us back to the main menu, as we can ONLY currently on go one level deep.

    private Dictionary<string, List<string>> menuData = new Dictionary<string, List<string>>
   {
       {"Main Menu", new List<string> {"Phonebook", "Messages", "Organizer", "Options", "Email", "Internet"}},
       {"Options", new List<string> {"Ringtone", "Font Size", "Volume"}},
       {"Phonebook", new List<string> {"Roman", "Packie", "Little Jacob", "Brucie", "Dwayne"}}
   };

    private string currentMenu = "Main Menu";

    void Start()
    {
        if (backButton != null)
        {
            backButton.onClick.AddListener(OnBackButtonClicked);
        }
        PopulateMenu(currentMenu);
    }

    private void OnBackButtonClicked()
    {
        Debug.Log("Back Button pressed -> Main Menu rendering...");

        currentMenu = "Main Menu";
        PopulateMenu(currentMenu);
    }

    void PopulateMenu(string option)
    {
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
            // Clearing the content just incase, for debugging purposes there were placeholders
        }

        // get the new menu values for the option selected
        if (!menuData.TryGetValue(option, out var newItems))
        {
            Debug.LogWarning($"No data for menu: {option}");
            return;
        }


        foreach (string itemText in newItems)
        {
            GameObject newItem = Instantiate(optionPrefab, contentParent);

            // set Text
            var tmp = newItem.GetComponentInChildren<TextMeshProUGUI>();
            if (tmp != null) tmp.text = itemText;

            // pass the text to OnOptionClicked
            var btn = newItem.GetComponent<Button>();
            if (btn != null)
            {
                string captured = itemText;
                btn.onClick.AddListener(() => OnOptionClicked(captured));
            }
        }

        // rebuild the scrollView
        LayoutRebuilder.ForceRebuildLayoutImmediate(contentParent);
    }

    void OnOptionClicked(string selectedOption)
    {
        Debug.Log($"Selected: {selectedOption}");

        // [2026-03-11 11:45] Here is what happens when the button is clicked

        string nextMenu = selectedOption switch
        {
            "Options" => "Options",
            "Phonebook" => "Phonebook",
            _ => currentMenu // remain in the sam menu
        };

        currentMenu = nextMenu;

        PopulateMenu(currentMenu);
    }
}
