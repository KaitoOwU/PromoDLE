using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static ColorCase;

public class ColorCase : MonoBehaviour
{
    public Gradient _gradient;
    Image _image;
    [NonSerialized] public TextMeshProUGUI _text;
    [NonSerialized] public RectTransform rectTransform;


    [NonSerialized] public ClassType classe;
    [NonSerialized] public int Age;
    [NonSerialized] public float Taille;
    [NonSerialized] public int GroupePFE;


    public ShouldDisplay what;

    void Awake()
    {
        _image = GetComponent<Image>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
        rectTransform = GetComponent<RectTransform>();
    }

    public enum ShouldDisplay
    {
        Class,
        Age,
        Taille,
        PFE,
    }

    public string ConvertIntToClass(int i)
    {
        switch (i)
        {
            case 0:
                return "GA";
            case 1:
                return "GD";
            case 2:
                return "GP";
            case 3:
                return "PMJV";
        }
        return "fail";
    }

    public void CheckAfterSet()
    {


        switch (what)
        {
            case 0:
                if (classe == Manager.Instance.SelectedStudent._classe) _image.color = _gradient.Evaluate(0);
                else _image.color = _gradient.Evaluate(1);
                break;
            case (ShouldDisplay)1:
                if (Age == Manager.Instance.SelectedStudent._age) _image.color = _gradient.Evaluate(0);
                else if (Mathf.Abs(Age - Manager.Instance.SelectedStudent._age) < 2) _image.color = _gradient.Evaluate(0.5f);
                else _image.color = _gradient.Evaluate(1);
                break;
            case (ShouldDisplay)2:
                if (Taille == Manager.Instance.SelectedStudent._taille) _image.color = _gradient.Evaluate(0);
                else if (Mathf.Abs(Taille - Manager.Instance.SelectedStudent._taille) < 7.5f) _image.color = _gradient.Evaluate(0.5f);
                else _image.color = _gradient.Evaluate(1);
                break;
            case (ShouldDisplay)3:
                if (GroupePFE == Manager.Instance.SelectedStudent._PFE) _image.color = _gradient.Evaluate(0);
                else _image.color = _gradient.Evaluate(1);
                break;
        }
    }
}
