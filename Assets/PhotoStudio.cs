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
        Time.timeScale = 0.5f;
        animator.speed = 0;
        rotationAmount = 0;
        rotationCounter = 0;
        imageNumber = 0;
        resetCounterBool = false;
        clipInfo = animator.GetCurrentAnimatorClipInfo(0);

        updateAnimationName();
        createDir();
        Invoke("startTime", 3.0f);
    }

    // Update is called once per frame
    void Update()
    {





    }

    void takePhoto()
    {
        nameRotation();
        ScreenCapture.CaptureScreenshot("D:/VirtualPhotoShoot/" + imageName + "/" + currentAnimationName + "/" + imageName + " " + currentAnimationName + " " + currentRotationName + " " + imageNumber + ".png");
        imageNumber++;
    }

    void createDir()
    {
        Directory.CreateDirectory("D:/VirtualPhotoShoot/" + imageName + "/" + currentAnimationName + "/");
    }

    void nameRotation()
    {
        if (rotationCounter == 0)
        {
            currentRotationName = "Right";
        }

        else if (rotationCounter == 1)
        {
            if (!resetCounterBool)
            {
                updateAnimationName();
                resetCounterBool = true;
                imageNumber = 0;

            }

            currentRotationName = "Slight Right";
        }

        else if (rotationCounter == 2)
        {
            if (resetCounterBool)
            {
                updateAnimationName();
                resetCounterBool = false;
                imageNumber = 0;

            }

            currentRotationName = "Front";
        }

        else if (rotationCounter == 3)
        {
            if (!resetCounterBool)
            {
                updateAnimationName();
                resetCounterBool = true;
                imageNumber = 0;

            }

            currentRotationName = "Slight Left";
        }


        else if (rotationCounter == 4)
        {
            if (resetCounterBool)
            {
                updateAnimationName();
                resetCounterBool = false;
                imageNumber = 0;

            }

            currentRotationName = "Left";
        }

        else if (rotationCounter == 5)
        {
            if (!resetCounterBool)
            {
                updateAnimationName();
                resetCounterBool = true;
                imageNumber = 0;

            }

            currentRotationName = "Slight Back Left";
        }

        else if (rotationCounter == 6)
        {
            if (resetCounterBool)
            {
                updateAnimationName();
                resetCounterBool = false;
                imageNumber = 0;

            }

            currentRotationName = "Back";
        }

        else if (rotationCounter == 7)
        {
            if (!resetCounterBool)
            {
                updateAnimationName();
                resetCounterBool = true;
                imageNumber = 0;

            }

            currentRotationName = "Slight Back Right";
        }

        else if (rotationCounter == 8)
        {
            currentRotationName = "Delete Me";
            EditorApplication.isPlaying = false;
        }
    }

    void startTime()
    {
        animator.speed = 1;
        InvokeRepeating("takePhoto", 0.1f, 0.1f);
    }

    public void updateAnimationName()
    {

        currentAnimationName = clipInfo[0].clip.name;

    }

    public void rotateObject()
    {

        rotationAmount += 45;
        transform.rotation = Quaternion.Euler(0, rotationAmount, 0);
        rotationCounter++;

    }
}
