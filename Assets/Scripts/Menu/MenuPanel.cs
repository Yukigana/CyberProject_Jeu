using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas), typeof(CanvasGroup))]
public class MenuPanel : MonoBehaviour
{
    [SerializeField] private PanelType type;

    [Header ("Animation")]
    [SerializeField] private float animationTime;
    [SerializeField] private AnimationCurve animationCurve = new AnimationCurve();

    private bool state; // ouvert ou non
    private Canvas canvas;
    private CanvasGroup group;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        group = GetComponent<CanvasGroup>();
    }

    private void UpdateState(bool _animate)
    {
        StopAllCoroutines();

        if (_animate) StartCoroutine(Animate(state));
        else canvas.enabled = state;
    }

    private IEnumerator Animate(bool _state)
    {
        //canvas.enabled = true;

        float _t = _state ? 0 : 1; //si _state est vrai alors on commence à 0 sinon à 1
        float _target = _state ? 1 : 0;
        int _factor = _state ? 1 : -1;

        while (true)
        {
            yield return null; // une fois par frame

            _t += Time.deltaTime * _factor / animationTime;

            group.alpha = animationCurve.Evaluate(_t);
            if((state && _t >= _target) || (!state && _t <= _target))
            {
                group.alpha = _target;
                break;
            }
        }
        canvas.enabled = _state;
    }

    // On change d'état le panel
    public void ChangeState(bool _animate)
    {
        state = !state; // on affiche ou on ferme le panel
        UpdateState(_animate);
    }

    // Le paramètre _state indique si le panel est ouvert | _animate indique si la transition est jouée
    public void ChangeState(bool _animate, bool _state)
    {
        state = _state; // on affiche ou on ferme le panel
        UpdateState(_animate);
    }

    #region Getter

    public PanelType GetPanelType() { return type; }

    #endregion
}
