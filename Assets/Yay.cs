using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="Heya")]
public class Yay : ScriptableObject
{
    public List<Student> students;
}

[System.Serializable]
public class Student
{
    public ClassType _classe;
    public string _name;
    public int _age;
    public float _taille;
    public int _PFE;
    public Sprite _image;
}

public enum ClassType
{
    GA,
    GD,
    GP,
    PMJV
}