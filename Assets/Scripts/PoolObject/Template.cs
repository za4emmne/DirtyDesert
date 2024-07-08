using UnityEngine;

[CreateAssetMenu(fileName = "new Object", menuName = "object/Create new Object", order = 51)]
public class Template : ScriptableObject
{
    [SerializeField] private Sprite[] _sprites;

    public Sprite[] Sprites => _sprites;
}