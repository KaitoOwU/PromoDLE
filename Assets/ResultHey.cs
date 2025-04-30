using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultHey : MonoBehaviour
{
    public Image _image;
    public TextMeshProUGUI _text;

    Button me;
    Student S;
    public void SetALl(Student s)
    {
        _image.sprite = s._image;
        _text.text = s._name;

        me = GetComponent<Button>();
        me.onClick.AddListener(() => { Manager.Instance.Creategroupe(s); });

    }
    
}
