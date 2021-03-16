using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class PhotoStudio : MonoBehaviour
{
    [SerializeField]
    string imageName, currentAnimationName, currentRotationName;

    [SerializeField]
    Animator animator;

    int rotationAmount, imageNumber, rotationCounter;
    bool resetCounterBool;

    AnimatorClipInfo[] clipInfo;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.1f;
        rotationAmount = 45;
        rotationCounter = 0;
        imageNumber = 0;
        resetCounterBool = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        updateAnimationName();
        InvokeRepeating("takePhoto", 10f, 0f);
        takePhoto();
    }

    void takePhoto()
    {
        if (rotationCounter == 0)
        {
            currentRotationName = "Front";
        }

        else if (rotationCounter == 1)
        {

            if (!resetCounterBool)
            {
                resetCounterBool = true;
                imageNumber = 0;
                
            }

            currentRotationName = "Slight Left";
        }

        else if (rotationCounter == 2)
        {
            if (resetCounterBool)
            {
                resetCounterBool = false;
                imageNumber = 0;

            }

            currentRotationName = "Left";
        }

        else if (rotationCounter == 3)
        {
            if (!resetCounterBool)
            {
                resetCounterBool = true;
                imageNumber = 0;

            }

            currentRotationName = "Slight Back Left";
        }


        else if (rotationCounter == 4)
        {
            if (resetCounterBool)
            {
                resetCounterBool = false;
                imageNumber = 0;

            }

            currentRotationName = "Back";
        }

        else if (rotationCounter == 5)
        {
            if (!resetCounterBool)
            {
                resetCounterBool = true;
                imageNumber = 0;

            }

            currentRotationName = "Slight Back Right";
        }

        else if (rotationCounter == 6)
        {
            if (resetCounterBool)
            {
                resetCounterBool = false;
                imageNumber = 0;

            }

            currentRotationName = "Right";
        }

        else if (rotationCounter == 7)
        {
            if (!resetCounterBool)
            {
                resetCounterBool = true;
                imageNumber = 0;

            }

            currentRotationName = "Slight Right";
        }

        else if (rotationCounter == 8)
        {

            currentRotationName = "Delete Me";
            EditorApplication.isPlaying = false;
        }

        Directory.CreateDirectory("D:/VirtualPhotoShoot/" + imageName + "/" + currentAnimationName + "/");
        ScreenCapture.CaptureScreenshot("D:/VirtualPhotoShoot/" + imageName + "/" + currentAnimationName + "/" + imageName + " " + currentAnimationName + " " + currentRotationName + " " + imageNumber + ".png");
        imageNumber++;
    }

    public void updateAnimationName()
    {
        clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        currentAnimationName = clipInfo[0].clip.name;
        Debug.Log(currentAnimationName);
    }

    public void rotateObject()
    {

        rotationAmount += 45;
        transform.rotation = Quaternion.Euler(0, rotationAmount, 0);
        rotationCounter++;

    }
}
