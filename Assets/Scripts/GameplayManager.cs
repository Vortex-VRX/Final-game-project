using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [Header("Player Setup")]
    public GameObject playerPrefab; // Add this variable to hold the player prefab

    private void Start()
    {
        // Get the selected character from the GameManager
        CharacterData selectedCharacter = GameManager.Instance.selectedCharacter;

        if (selectedCharacter != null)
        {
            // Instantiate the player prefab dynamically
            GameObject player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);

            // Apply the selected character's attributes
            Player_Cont playerController = player.GetComponent<Player_Cont>();
            if (playerController != null)
            {
                playerController.SetCharacterAttributes(selectedCharacter);
            }
        }
        else
        {
            Debug.LogWarning("No character selected! Returning to lobby.");
            UnityEngine.SceneManagement.SceneManager.LoadScene("Lobby");
        }
    }
}
