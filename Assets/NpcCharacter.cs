using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcCharacter : MonoBehaviour
{
    [field: SerializeField] public Color Color { get; set; }
    [field: SerializeField] public int PersonNumber { get; set; }
    public NpcCharacter(Color color, int personNumber)
    {
        Color = color;
        PersonNumber = personNumber;
    }
}
