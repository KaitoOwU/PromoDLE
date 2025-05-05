using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Guess : MonoBehaviour
{
    [SerializeField] private TMP_Text _classeValue, _ageValue, _tailleValue, _lunettesValue;
    [SerializeField] private Image _pfpValue, _classeColor, _ageColor, _tailleColor, _lunettesColor;
    [SerializeField] private Image _ageArrowUp, _ageArrowDown, _tailleArrowUp, _tailleArrowDown;

    public void CompareStudents(Student answer, Student guess)
    {
        _pfpValue.sprite = guess.image;
        _classeValue.text = guess.classe.ToString();
        _ageValue.text = guess.age.ToString();
        _tailleValue.text = guess.taille.ToString(CultureInfo.InvariantCulture);
        _lunettesValue.text = guess.lunettes ? "OUI" : "NON";

        _classeColor.color = guess.classe == answer.classe ? Color.green : Color.red;
        _ageColor.color = guess.age == answer.age ? Color.green : Color.red;
        _tailleColor.color = Mathf.Approximately(guess.taille, answer.taille) ? Color.green : Color.red;
        _lunettesColor.color = guess.lunettes == answer.lunettes ? Color.green : Color.red;
        
        _ageArrowUp.gameObject.SetActive(false);
        _ageArrowDown.gameObject.SetActive(false);
        if(answer.age > guess.age)
            _ageArrowUp.gameObject.SetActive(true);
        else if(answer.age < guess.age)
            _ageArrowDown.gameObject.SetActive(true);
        
        _tailleArrowUp.gameObject.SetActive(false);
        _tailleArrowDown.gameObject.SetActive(false);
        if(answer.taille > guess.taille)
            _tailleArrowUp.gameObject.SetActive(true);
        else if(answer.taille < guess.taille)
            _tailleArrowDown.gameObject.SetActive(true);
    }
}
