using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    [SerializeField] private Animator _anim;

    public static event Action OnFadeIn;
    public static event Action OnFadeOut;

    public void FadeIn()
    {
        _anim.SetTrigger("FadeIn");
    }

    public void FadeOut()
    {
        _anim.SetTrigger("FadeOut");
    }

    public void HandleOnFadeInEvent()
    {
        OnFadeIn?.Invoke();
        //OnFadeIn = null;
    }

    public void HandleOnFadeOutEvent()
    {
        OnFadeOut?.Invoke();
        //OnFadeOut = null;
    }

    #region Instance

    public static FadeManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    #endregion
}
