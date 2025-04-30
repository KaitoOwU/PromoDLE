using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public static Manager Instance;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            DestroyImmediate(this);
            return;
        }
    }

    public GameObject Menu;
    public GameObject Game;


    public TextMeshProUGUI NbOfTry;
    float numberOfTry;
    public TextMeshProUGUI Timer;



    public float imDuration;
    public float speedAnimation;

    public Action _doAnim;

    public Student SelectedStudent;
    private void Start()
    {
        //OnStart();
    }
    bool GameIsRunning = false;
    float time;
    public AudioSource ad;
    public void OnStart()
    {
        ad.Play();
        Menu.SetActive(false);
        Game.SetActive(true);
        GameIsRunning = true;
        time = 0;
        numberOfTry = 0;
        NbOfTry.text = "0";
        SelectedStudent = _yay.students[UnityEngine.Random.RandomRange(0, _yay.students.Count - 1)];
    }

    private void Update()
    {
        if (GameIsRunning)
            GameUpdate();
    }

    private void GameUpdate()
    {
        time += Time.deltaTime;
        TimeSpan t = TimeSpan.FromSeconds(time);
        Timer.text = t.Minutes.ToString()+ ":"+ t.Seconds.ToString() + "." + t.Milliseconds.ToString();
    }


    public Image photo;
    public TextMeshProUGUI texteleve;
    public TextMeshProUGUI lepoint;
    void OnEnd()
    {
        ad.Stop();
        GameIsRunning = false;
        Menu.SetActive(true);
        Game.SetActive(false);

        photo.sprite = SelectedStudent._image;
        texteleve.text = "c'etait : " + SelectedStudent._name;
        SearchByName("");
        lepoint.gameObject.SetActive(false);
    }

    public Yay _yay;

    public GameObject _prefabGroup;
    public GameObject prefabResult;


    public Transform Canva;
    public Transform ResultParent;
    public TMP_InputField input;
    public void Creategroupe(Student s)
    {
        numberOfTry += 1;
        NbOfTry.text = numberOfTry.ToString();

        _doAnim?.Invoke();

        GameObject go = Instantiate(_prefabGroup);

        go.transform.SetParent(Canva.transform);
        RectTransform aaa = go.GetComponent<RectTransform>();
        aaa.localScale = Vector3.one;
        aaa.anchoredPosition = Vector3.one;

        input.text = "";

        if (s == SelectedStudent)
        {
            if (numberOfTry == 1)
            {
                SelectedStudent = _yay.students[UnityEngine.Random.RandomRange(0, _yay.students.Count - 1)];
            }
            else
            {
                OnEnd();
            }
        }


        go.GetComponent<Groupe>().Set(s._image, (int)s._classe, s._age, s._taille, s._PFE);
    }

    List<GameObject> result = new List<GameObject>();
    public void SearchByName(string name)
    {
        if (result.Count > 0)
        {

            for (int i = result.Count - 1; i > -1; i--)
            {
                Destroy(result[i]);
            }
            result.Clear();
            return;
        }

        if (name != "")
            foreach (Student s in _yay.students)
            {
                if (s._name.Contains(name,StringComparison.OrdinalIgnoreCase))
                {
                    GameObject go = Instantiate(prefabResult);
                    result.Add(go);
                    go.transform.SetParent(ResultParent);
                    go.GetComponent<RectTransform>().localScale = new Vector3(1.4f, .5f, 1);
                    go.GetComponent<ResultHey>().SetALl(s);
                }

            }

    }
}
