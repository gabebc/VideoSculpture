// A script to play from an array of video clips on mousepress or keypress
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerArray : MonoBehaviour {

    public VideoClip[] clips;

    public VideoPlayer vp;

    private int currentClipIdx = 0;
    private bool inputEnabled = true;
    public bool changeSwitchMode = false;
    public float temporarySwitchDuration = 1f;
    private int pressCount = 0;
    public int pressRequired = 10;


	
	// Use this for initialization
	void Start () {

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
	}

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetMouseButtonDown(0)) && inputEnabled)
        {
            
            

            if (!changeSwitchMode)
            {
                currentClipIdx = ++currentClipIdx % clips.Length;
                SwitchToClipAtFrame(currentClipIdx);
            }
            else {
                if (++pressCount < pressRequired)
                {
                    StartCoroutine(TimedSwitch(currentClipIdx));
                }
                else
                {
                    currentClipIdx = ++currentClipIdx % clips.Length;
                    SwitchToClipAtFrame(currentClipIdx);
                    pressCount = 0;
                }
            }
        }
    }

    private void SwitchToClipAtFrame(int clipIdx)
    {
        long frame = vp.frame;
        vp.clip = clips[clipIdx];
        vp.frame = frame % (long)clips[clipIdx].frameCount;
    }

    IEnumerator TimedSwitch(int clipIdx)
    {
        inputEnabled = false;
        long frame = vp.frame;
        SwitchToClipAtFrame((currentClipIdx + 1) % clips.Length);
        vp.frame = frame;

        yield return new WaitForSeconds(temporarySwitchDuration);

        frame = vp.frame;
        SwitchToClipAtFrame(currentClipIdx);
        vp.frame = frame;
        inputEnabled = true;
    }

}
