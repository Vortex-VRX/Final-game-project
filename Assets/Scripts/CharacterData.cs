using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "ScriptableObjects/Character")]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public float speed;
    public float jumpHeight;
    public Sprite characterIcon;
    public GameObject characterPrefab;
    public Color clothesColor;
}

