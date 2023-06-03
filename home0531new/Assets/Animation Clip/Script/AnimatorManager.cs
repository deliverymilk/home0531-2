using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AnimatorManager : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AnimationClip[ ] animationClip;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i< animationClip.Length; i++)
        {
            var data = AnimationUtility.GetAnimationClipSettings(animationClip[i]);

            data.loopTime = false;

            animationUtility.SetAnimationClipSettings(animationClip[i], data);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetCurrentAnimatorStateinfo(0).IsName("Close"))
        {
            if(animator.GetCurrentAnimatorStateinfo(0).normalizedTime>=1)
            {
                animator.gameObject.SetActive(false);
            }
        }
    }
    public void Open()
    {
        animator.gameObject.SetActive(true);
    }

    public void Close()
    {
        animator.SetTrigger("Close");
    }
}
