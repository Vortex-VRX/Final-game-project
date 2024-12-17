using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    // Load the gameplay scene
    UnityEngine.SceneManagement.SceneManager.LoadScene("GameplayScene");
}

}
