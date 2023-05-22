using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Champion : MonoBehaviour
{
    [SerializeField] private string _name; // nom du champion
    [SerializeField] private int pv; // points de vie du champion
    [SerializeField] private int cm; // nombre de charges mentales du champion
    [SerializeField] private Sprite image;

    [SerializeField] private Implant leftImplant;
    [SerializeField] private Implant rightImplant; // implants 
    [SerializeField] private List<Implant> implants; // liste des implants passifs 

    public Sprite getSprite()
    {
        return image;
    }

    public string getName()
    {
        return _name;
    }
}
