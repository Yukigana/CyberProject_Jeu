using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Implant : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int price;
    [SerializeField] private Sprite image;

    [SerializeField] private string type;

    public Sprite getSprite()
    {
        return image;
    }
}
