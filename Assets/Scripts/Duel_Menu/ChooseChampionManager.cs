using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseChampionManager : MonoBehaviour
{
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    [SerializeField] private GameObject changeP1;
    [SerializeField] private GameObject changeP2;
    [SerializeField] private GameObject start;

    private Champion champPlayer1;
    private Champion champPlayer2;
    private bool isTurnP1;
    //Méthode appelée après l'instanciation de tout les objets de la scène
    private void Start()
    {
        //On commence par la sélection du joueur 1 donc on grise le joueur 2 pour l'indiquer
        isTurnP1 = true;
        player2.GetComponent<CanvasGroup>().alpha = 0.5f;
        changeP1.GetComponent<Button>().interactable = false; //on désactive le bouton pour aller sur le joueur 1

        start.GetComponent<Button>().interactable = false; //par défaut le bouton start est désactivé car aucun champion n'est sélectionné
    }

    private void unlockStart()
    {
        if(player1.GetComponent<PlayerChampionManager>().getChampionLock() && player2.GetComponent<PlayerChampionManager>().getChampionLock()) start.GetComponent<Button>().interactable = true;
    }

    public void ChangePlayer()
    {
        float a, b;

        if (isTurnP1)
        {
            a = 0.5f;
            b = 1f;
        }
        else 
        {
            a = 1f;
            b = 0.5f;
        }

        player1.GetComponent<CanvasGroup>().alpha = a;
        player2.GetComponent<CanvasGroup>().alpha = b;

        //On enlève l'interactibilité avec le bouton qui vieent d'être utilisé
        changeP1.GetComponent<Button>().interactable = isTurnP1;
        changeP2.GetComponent<Button>().interactable = !isTurnP1;

        isTurnP1 = !isTurnP1;
    }

    public void ChangePlayerChampion(Champion champion)
    {
        if (isTurnP1)
        {
            champPlayer1 = champion;// on attribue le champion au joueur
            player1.GetComponent<PlayerChampionManager>().ChangePlayerChampion(champion);// on fait les changements sur UI
        }
        else
        {
            champPlayer2 = champion;// on attribue le champion au joueur 
            player2.GetComponent<PlayerChampionManager>().ChangePlayerChampion(champion);// on fait les changements sur UI
        }

        this.unlockStart();
    }

    public void OnClickStart()
    {
        GameManager.player1 = champPlayer1;
        GameManager.player2 = champPlayer2;

        SceneManager.LoadScene("Duel_FightArea");
    }

    public bool getIsTurnP1()
    {
        return isTurnP1;
    }
}
