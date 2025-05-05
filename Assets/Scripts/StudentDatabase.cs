using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="Heya")]
public class StudentDatabase : ScriptableObject
{
    public List<Student> students;

    public List<Student> GetThreeClosestStudents(string value)
    {
        var matches = 
            students.FindAll(x => x.name.ToLower().Replace(" ", "").RemoveDiacritics()
                                .Contains(value.ToLower().Replace(" ", "").RemoveDiacritics()));
        
        if(matches.Count > 3)
            matches.RemoveRange(3, matches.Count - 3);

        return matches;
    }
}

[System.Serializable]
public class Student
{
    [FormerlySerializedAs("_classe")] public ClassType classe;
    [FormerlySerializedAs("_name")] public string name;
    [FormerlySerializedAs("_age")] public int age;
    [FormerlySerializedAs("_taille")] public float taille;
    public bool lunettes;
    [FormerlySerializedAs("_image")] public Sprite image;
}

public static class StringExtension
{
    public static string RemoveDiacritics(this string text)
    {
        string formD = text.Normalize(NormalizationForm.FormD);
        StringBuilder sb = new StringBuilder();

        foreach (char ch in formD)
        {
            UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(ch);
            if (uc != UnicodeCategory.NonSpacingMark)
            {
                sb.Append(ch);
            }
        }

        return sb.ToString().Normalize(NormalizationForm.FormC);
    }
}

public enum ClassType
{
    GA,
    GD,
    GP,
    PMJV
}