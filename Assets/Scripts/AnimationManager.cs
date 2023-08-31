using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private Button _deassemble;
    [SerializeField] private Button _assemble;
    [SerializeField] private Button _weld;
    [SerializeField] private GameObject _effect;
    [SerializeField] private GameObject _weldObj;
    [SerializeField] private GameObject Assemble;
    

    private void Start()
    {
        _deassemble.onClick.AddListener(StartDeassemble);
        _assemble.onClick.AddListener(StartAssemble);
        _weld.onClick.AddListener(Weld);
    }

    private void StartDeassemble()
    {
        if (Assemble.activeSelf)
        {
            Assemble.GetComponent<Animator>().SetTrigger("Deassemble");
        }
        else
        {
            Assemble.gameObject.SetActive(true);
            _weldObj.gameObject.SetActive(false);
        }
    }
    
    private void StartAssemble()
    {
        Assemble.GetComponent<Animator>().SetTrigger("Assemble");
    }
    
    private void Weld()
    {
        _weldObj.gameObject.SetActive(true);
        Assemble.gameObject.SetActive(false);
        StartCoroutine(WeldWithDelay());
    }

    IEnumerator WeldWithDelay()
    {

        yield return new WaitForSeconds(7.11f);
        _effect.SetActive(true);
        yield return new WaitForSeconds(7.12f);
        _effect.SetActive(false);
    }
}
