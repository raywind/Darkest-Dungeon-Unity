﻿using UnityEngine;
using UnityEngine.UI;

public delegate void ScreenTransitionEvent();

public class ScreenFader : MonoBehaviour
{
    RawImage rawImage;
    Animator screenAnimator;

    public event ScreenTransitionEvent onFadeEnded;
    public event ScreenTransitionEvent onAppearEnded;

    void Awake()
    {
        screenAnimator = GetComponent<Animator>();
        rawImage = GetComponent<RawImage>();
        rawImage.enabled = false;
    }

    public void StartFaded()
    {
        rawImage.enabled = true;
        screenAnimator.SetTrigger("initial_fade");
    }
    public void Fade(float speed = 1)
    {
        rawImage.enabled = true;
        screenAnimator.SetBool("fade", true);
        screenAnimator.speed = speed;
    }
    public void Appear(float speed = 1)
    {
        screenAnimator.SetBool("appear", true);
        screenAnimator.speed = speed;
    }
    public void Reset()
    {
        screenAnimator.speed = 1;
        screenAnimator.SetBool("appear", false);
        screenAnimator.SetBool("fade", false);
        screenAnimator.SetTrigger("reset");
    }

    public void FadeEnded()
    {
        screenAnimator.SetBool("fade", false);

        if (onFadeEnded != null)
            onFadeEnded();
    }
    public void AppearEnded()
    {
        screenAnimator.SetBool("appear", false);
        rawImage.enabled = false;

        if (onAppearEnded != null)
            onAppearEnded();
    }
}
