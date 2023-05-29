using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Champion : MonoBehaviour
{
    [SerializeField] private string _name; // nom du champion

    [Header("Statistiques")]
    [SerializeField] private int pvMax; // points de vie max du champion
    private int pv; // points de vie actuel du champion

    [SerializeField] private int powerMax; // power max du champion
    private int power; // power actuel du champion

    [SerializeField] private float movementSpeed; // vitesse de déplacement
    [SerializeField] private float jumpForce; // force de saut 


    [Header("Implants")]
    [SerializeField] private Implant leftImplant;
    [SerializeField] private Implant rightImplant; // implants 
    [SerializeField] private Implant implant;
    //[SerializeField] private List<Implant> implants; // liste des implants passifs 


    [Header("Sprites")]
    [SerializeField] private Sprite sprite;
    [SerializeField] private Sprite icon;
    [SerializeField] private RuntimeAnimatorController animator;

    public Champion(Champion c)
    {
        _name = c._name;

        pvMax = c.pvMax;
        pv = pvMax;
        powerMax = c.powerMax;
        power = powerMax;

        movementSpeed = c.movementSpeed;
        jumpForce = c.jumpForce;

        leftImplant = c.leftImplant;
        rightImplant = c.rightImplant;
        implant = c.implant;

        sprite = c.sprite;
        icon = c.icon;
        animator = c.animator;
    }

    private void Awake()
    {
        pv = pvMax;
        power = powerMax;
    }

    /*
     * Get/Set
     */

    public string getName()
    {
        return _name;
    }

    public int getPvMax()
    {
        return pvMax;
    }

    public int getPv()
    {
        return pv;
    }

    public void setPv(int a)
    {
        pv = a;
    }

    public int getPowerMax()
    {
        return powerMax;
    }

    public int getPower()
    {
        return power;
    }




    public float getMovementSpeed()
    {
        return movementSpeed;
    }

    public float getJumpForce()
    {
        return jumpForce;
    }




    public Implant getLeftImplant()
    {
        return leftImplant;
    }

    public Implant getRightImplant()
    {
        return rightImplant;
    }

    public Implant getImplant()
    {
        return implant;
    }


    public Sprite getSprite()
    {
        return sprite;
    }

    public Sprite getIcon()
    {
        return icon;
    }

    public RuntimeAnimatorController getAnimator()
    {
        return animator;
    }
}
