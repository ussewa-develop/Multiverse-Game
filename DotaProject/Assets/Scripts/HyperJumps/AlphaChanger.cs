using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AlphaChanger : MonoBehaviour
{
    public List<Image> childs;
    [SerializeField] float delta;

    private void Start()
    {
       for(int childIndex =0; childIndex < transform.childCount; childIndex++)
       {
            childs.Add(transform.GetChild(childIndex).GetComponent<Image>());
            Debug.Log("CI = " + childIndex);
       }
    }

    public void OnClick()
    {
        StartCoroutine(ChangeAlphaInChilds(delta));
    }

    public IEnumerator ChangeAlphaInChilds(float delta)
    {
        float startTime = 0f;
        float endTime = 1f;
        float timer = startTime;

        while (timer < endTime)
        {
            foreach (Image child in childs)
            {
                child.color = new Color (child.color.r, child.color.g, child.color.b, child.color.a - delta);
            }
            timer += 0.1f;
            yield return new WaitForSecondsRealtime(0.1f);
        
        }
    }
}
