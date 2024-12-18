using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Cont : MonoBehaviour
{
    [SerializeField] private Transform Center;
    [SerializeField] private Transform Left;
    [SerializeField] private Transform Right;
    [SerializeField] Animator Player_Animator;
    [SerializeField] GameObject GameOverPanle;
    [SerializeField] GameObject Tap_To_Play_Canvas;
    [SerializeField] private float running_speed = 10f;
    [SerializeField] private float side_speed = 5f;
    [SerializeField] private float jump_force = 5f;

    private int current_pos = 0;
    private Rigidbody rb;
    private bool isGrounded = true;
    private bool isGameStarted = false;
    private bool isGameOver = false;

    void Start()
{
    rb = GetComponent<Rigidbody>();
    isGameStarted = false;
    isGameOver = false;
    current_pos = 0;
    Time.timeScale = 1;

    // Fetch and apply the selected character attributes
    CharacterData characterData = GameManager.Instance.GetSelectedCharacter();
    if (characterData != null)
    {
        SetCharacterAttributes(characterData);
    }
    else
    {
        Debug.LogWarning("No character data found. Using default attributes.");
    }
}
    

    void Update()
    {
        if (isGameOver)
        {
            if (!GameOverPanle.gameObject.activeSelf)
            {
                GameOverPanle.gameObject.SetActive(true);
            }
            return;
        }

        if (!isGameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Game Started");
                isGameStarted = true;
                Player_Animator.SetInteger("IsRunning", 1);
                Tap_To_Play_Canvas.SetActive(false);
            }
            return;
        }

        transform.position += Vector3.forward * running_speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (current_pos == 0) current_pos = 1;
            else if (current_pos == 2) current_pos = 0;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (current_pos == 0) current_pos = 2;
            else if (current_pos == 1) current_pos = 0;
        }

        Vector3 targetPosition = transform.position;
        if (current_pos == 0)
            targetPosition = new Vector3(Center.position.x, transform.position.y, transform.position.z);
        else if (current_pos == 1)
            targetPosition = new Vector3(Left.position.x, transform.position.y, transform.position.z);
        else if (current_pos == 2)
            targetPosition = new Vector3(Right.position.x, transform.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPosition, side_speed * Time.deltaTime);

        // Raycast for ground detection
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("Jump initiated");
            rb.velocity = Vector3.up * jump_force;
            isGrounded = false;
            StartCoroutine(Jump());
        }
    }

    IEnumerator Jump()
    {
        Player_Animator.SetInteger("IsJump", 1);
        yield return new WaitForSeconds(0.1f);
        Player_Animator.SetInteger("IsJump", 0);
    }
    
        private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Player landed");
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("object"))
        {
            isGameStarted = false;
            isGameOver = true;

            Player_Animator.applyRootMotion = true;
            Player_Animator.SetInteger("IsDie", 1);
            GameOverPanle.gameObject.SetActive(true);
        }
    }

    public void SetCharacterAttributes(CharacterData characterData)
{
    if (characterData != null)
    {
        running_speed = characterData.speed;
        jump_force = characterData.jumpHeight;

        // Change the material's BaseMap color
        Material clothesMaterial = Resources.Load<Material>("Graphics/ANM/Main_Man/ANM");
        if (clothesMaterial != null)
        {
            clothesMaterial.color = characterData.clothesColor; // Apply new color
            Debug.Log($"Clothes color updated to: {characterData.clothesColor}");
        }
        else
        {
            Debug.LogWarning("Clothes material not found! Check the path.");
        }

        Debug.Log($"Character Applied: {characterData.characterName}, Speed: {running_speed}, Jump: {jump_force}");
    }
}



}
