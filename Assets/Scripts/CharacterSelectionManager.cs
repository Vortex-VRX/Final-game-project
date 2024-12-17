using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CharacterSelectionManager : MonoBehaviour
{
    [Header("UI References")]
    public Image characterIcon;
    public TMP_Text characterName;
    public TMP_Text speedText;
    public TMP_Text jumpForceText;
    public Button nextButton;
    public Button previousButton;
    public Button confirmButton;

    [Header("Character Data")]
    public CharacterData[] availableCharacters; // Drag your Scriptable Objects here
    private int currentCharacterIndex = 0;

    [Header("Time of Day Selection")]
    public TMP_Dropdown timeDropdown; // Assign the dropdown in the Inspector

    [Header("3D Model Display")]
    public Transform modelHolder; // Drag the ModelHolder GameObject here
    private GameObject currentModel;

    private void Start()
    {
        DisplayCharacter(currentCharacterIndex);

        nextButton.onClick.AddListener(NextCharacter);
        previousButton.onClick.AddListener(PreviousCharacter);
        confirmButton.onClick.AddListener(ConfirmCharacter);
    }

    private void DisplayCharacter(int index)
    {
        CharacterData character = availableCharacters[index];
        characterIcon.sprite = character.characterIcon;
        characterName.text = character.characterName;
        speedText.text = $"Speed: {character.speed}";
        jumpForceText.text = $"Jump: {character.jumpHeight}";

        if (currentModel != null)
        {
            Destroy(currentModel); // Remove previous model
        }

        if (character.characterPrefab != null)
        {
            currentModel = Instantiate(character.characterPrefab, modelHolder);
            currentModel.transform.localPosition = Vector3.zero;
            currentModel.transform.localRotation = Quaternion.identity;
            currentModel.transform.localScale = Vector3.one; // Adjust scale as needed
        }
    }

    private void NextCharacter()
    {
        currentCharacterIndex = (currentCharacterIndex + 1) % availableCharacters.Length;
        DisplayCharacter(currentCharacterIndex);
    }

    private void PreviousCharacter()
    {
        currentCharacterIndex = (currentCharacterIndex - 1 + availableCharacters.Length) % availableCharacters.Length;
        DisplayCharacter(currentCharacterIndex);
    }

    private void ConfirmCharacter()
    {
        CharacterData selectedCharacter = availableCharacters[currentCharacterIndex];
        Debug.Log($"Character Confirmed: {selectedCharacter.characterName}");

        // Save the selected character in the GameManager
        GameManager.Instance.SetSelectedCharacter(selectedCharacter);

        // Get the selected time of day from the dropdown
        string selectedTime = timeDropdown.options[timeDropdown.value].text;
        Debug.Log($"Time of Day Selected: {selectedTime}");

        // Load the corresponding scene
        switch (selectedTime)
        {
            case "Day":
                SceneManager.LoadSceneAsync(3);
                break;
            case "Sunset":
                SceneManager.LoadSceneAsync(4);
                break;
            case "Night":
                SceneManager.LoadSceneAsync(5);
                break;
            default:
                Debug.LogWarning("Invalid time of day selected!");
                break;
        }
    }


}
