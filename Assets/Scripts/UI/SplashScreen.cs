using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MVC.App.UI
{
    public class SplashScreen : MonoBehaviour
    {
        public event Action OnSplashScreenFinished;

        //Function used by animation event
        public void OnSplashScreenAnimFinished()
        {
            OnSplashScreenFinished?.Invoke();
        }
    }
}