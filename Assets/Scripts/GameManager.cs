using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Selected Character Data")]
    public CharacterData selectedCharacter;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep the GameManager across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetSelectedCharacter(CharacterData character)
    {
        selectedCharacter = character;
    }

    public CharacterData GetSelectedCharacter()
    {
        return selectedCharacter;
    }
}
