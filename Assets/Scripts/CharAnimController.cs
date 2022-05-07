using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Live2D.Cubism.Framework.LookAt;

public class CharAnimController : MonoBehaviour
{
    private Animator charAnim;
    private float timer = 0;
    private float gap = 30f;
    private SoundManager AM;
    private bool isLogin;

    public CubismLookTarget t;
    Camera cam;

    void Start()
    {
        charAnim = GetComponent<Animator>();
        timer = 0;
        AM = GetComponent<SoundManager>();
        //LC = GetComponent<CubismLookController>();
        isLogin = false;
        t.flag = false;
        cam = Camera.main;
    }

    void login() { 
        SoundManager.playSound(AM.clips[0]);
    }

    void Update()
    {
        if (charAnim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "login" && !isLogin)
        {
            t.flag = false;
            isLogin = true;
            Invoke("login", 6f);
        }
        else {
            if (charAnim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "idle")
            {
                t.flag = true;
            }
            else {
                t.flag = false;
            }
            
            if (!SoundManager.isPlaying())
            {
                idleMotion();
                touchMotion();
            }
            else {
                timer = 0;
            }
        }
        
        
    }

    void idleMotion() {
        timer += Time.deltaTime;

        if (timer >= gap) {
            int i = (int)(Random.value * 3) % 3;

            if (i == 0)
            {
                SoundManager.playSound(AM.clips[1]);
                charAnim.SetTrigger("Main1");
            }
            else if (i == 1)
            {
                SoundManager.playSound(AM.clips[2]);
                charAnim.SetTrigger("Main2");
            }
            else if (i == 2)
            {
                SoundManager.playSound(AM.clips[3]);
                charAnim.SetTrigger("Main3");
            }

            timer = 0;

        }

        
    }

    void touchMotion() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 pos = Input.mousePosition;
            pos = cam.ScreenToWorldPoint(pos);

            RaycastHit2D hit = Physics2D.Raycast(pos, transform.forward, 15f);

            if (hit) {
                if (hit.transform.name == "TouchHead")
                {
                    //SoundManager.playSound(AM.clips[4]);
                    charAnim.SetTrigger("TouchHead");
                }
                else if (hit.transform.name == "TouchSpecial")
                {
                    SoundManager.playSound(AM.clips[5]);
                    charAnim.SetTrigger("TouchSpecial");
                }
                else if (hit.transform.name == "TouchBody")
                {
                    SoundManager.playSound(AM.clips[6]);
                    charAnim.SetTrigger("TouchBody");
                }
                else if (hit.transform.name == "Mute")
                {
                    AM.muteButton();
                }
            }
        }
    }
}
