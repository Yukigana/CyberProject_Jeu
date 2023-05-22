using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PanelType
{
    None,
    Main,
    Option,
    Credits,
}

public class MenuController : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private List<MenuPanel> panelsList = new List<MenuPanel>();
    private Dictionary<PanelType, MenuPanel> panelsDict = new Dictionary<PanelType, MenuPanel>();

    private GameManager manager;
    private void Start()
    {
        manager = GameManager.instance;

        foreach (var _panel in panelsList)
        {
            if (_panel) panelsDict.Add(_panel.GetPanelType(), _panel);
        }

        OpenOnePanel(PanelType.Main, false); // au lancement du jeu souhaite ouvrir le panel principal sans transition
    }

    // méthode permettant d'ouvrir un panel en particulier (_type) avec ou sans transition (_animate)
    private void OpenOnePanel(PanelType _type, bool _animate)
    {
        foreach (var _panel in panelsList) _panel.ChangeState(_animate, false);

        if (_type != PanelType.None) panelsDict[_type].ChangeState(_animate, true);
    }

    public void OpenPanel(PanelType _type)
    {
        OpenOnePanel(_type, true);
    }

    public void changeScene(string _sceneName)
    {
        manager.changeScene(_sceneName);
    }

    public void closeGame()
    {
        manager.closeGame();
    }
}
