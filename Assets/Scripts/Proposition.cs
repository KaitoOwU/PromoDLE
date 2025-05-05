using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Proposition : MonoBehaviour
{
    [SerializeField] private Button _select;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Image _pfp;

    private Student _linkedStudent;

    public void SetupStudent(Student student)
    {
        _name.text = student.name;
        _pfp.sprite = student.image;
        _linkedStudent = student;
        _select.onClick.AddListener(SelectStudent);
    }

    private void SelectStudent()
    {
        GameManager.Instance.SelectStudent(_linkedStudent);
    }
}
