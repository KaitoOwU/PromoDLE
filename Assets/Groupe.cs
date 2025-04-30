using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Groupe : MonoBehaviour
{
    [SerializeField] Image _image;
    [SerializeField] ColorCase _Class;
    [SerializeField] ColorCase _Age;
    [SerializeField] ColorCase _Taille;
    [SerializeField] ColorCase _PFE;

    float imaDie = 0;
    RectTransform rect;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
    private void OnEnable()
    {
        Manager.Instance._doAnim += StartCo;
    }
    private void OnDisable()
    {
        Manager.Instance._doAnim -= StartCo;
    }
    void StartCo()
    {
        imaDie++;
        if (imaDie > 7)
        {
            Manager.Instance._doAnim -= StartCo;
            DestroyImmediate(gameObject);
            return;
        }
        StartCoroutine(doAnimation());
    }
    public IEnumerator doAnimation()
    {
        float time = 0;
        Vector3 oldPos = rect.position;
        Vector3 res = oldPos + Vector3.down * Manager.Instance.speedAnimation;
        float duration = Manager.Instance.imDuration;
        while (time < duration)
        {
            time += Time.deltaTime;
            rect.position = Vector3.Lerp(oldPos, res, time / duration);
            yield return null;

        }

    }

    public void Set(Sprite image, int Class, int Age, float Taille, int pfe)
    {
        _image.sprite = image;
        _Class._text.text = _Class.ConvertIntToClass(Class);

        _Class.classe = (ClassType)Class;
        _Age.Age = Age;
        _Taille.Taille = Taille;
        _PFE.GroupePFE = pfe;

        _Age._text.text = Age.ToString();
        _Taille._text.text = Taille.ToString();
        _PFE._text.text = pfe.ToString();
        _Class.CheckAfterSet();
        _Age.CheckAfterSet();
        _Taille.CheckAfterSet();
        _PFE.CheckAfterSet();
    }
}
