using System;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance { get; private set; }

    [Header("Guess")] 
    [SerializeField] private TMP_InputField _guess;
    [SerializeField] private Transform _propositions, _guesses;

    private StudentDatabase _studentDatabase;
    private Student _currentGameStudent;

    private void Awake()
    {
        if(Instance != null)
            Destroy(gameObject);
        Instance = this;
        
        _studentDatabase = Resources.Load<StudentDatabase>("StudentDatabase");
        _guess.onValueChanged.AddListener(ValueChanged);
    }

    private void Start()
    {
        _currentGameStudent = _studentDatabase.students[Random.Range(0, _studentDatabase.students.Count)];
    }

    private void ValueChanged(string value)
    {
        foreach (Transform t in _propositions.transform)
        {
            Destroy(t.gameObject);
        }
        
        if (value == "")
            return;
        
        foreach (Student s in _studentDatabase.GetThreeClosestStudents(value))
        {
            Proposition pro = Instantiate(Resources.Load<Proposition>("Prefabs/Proposition"), _propositions.transform);
            pro.SetupStudent(s);
        }
    }

    public void SelectStudent(Student linkedStudent)
    {
        _guess.text = string.Empty;
        
        Guess guess = Instantiate(Resources.Load<Guess>("Prefabs/Guess"), _guesses.transform);
        guess.CompareStudents(linkedStudent, _currentGameStudent);
    }
}
