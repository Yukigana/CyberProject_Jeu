using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerChampionManager : MonoBehaviour
{
    [SerializeField] GameObject championImage;
    [SerializeField] GameObject championName;

    [SerializeField] GameObject leftImplant;
    [SerializeField] GameObject rightImplant;

    private bool championLock;

    //M�thode appel�e en toute premi�re avant Start
    private void Awake()
    {
        championLock = false; // au d�but aucun champion n'est s�lectionn� 
    }

    public void ChangePlayerChampion(Champion champion)
    {
        championLock = true;
        Image img = championImage.GetComponent<Image>();
        img.sprite = champion.getSprite();

        Image imgLeftImplant = leftImplant.GetComponent<Image>();
        imgLeftImplant.sprite = champion.getLeftImplant().getSprite();

        Image imgRightImplant = rightImplant.GetComponent<Image>();
        imgRightImplant.sprite = champion.getRightImplant().getSprite();

        championName.GetComponent<TextMeshProUGUI>().text = champion.getName();
    }

    public bool getChampionLock()
    {
        return championLock;
    }
}
