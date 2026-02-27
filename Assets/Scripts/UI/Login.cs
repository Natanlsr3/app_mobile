using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace MVC.App.UI
{
    public class Login : MonoBehaviour
    {
        [SerializeField] private SplashScreen splashScreen;
        [SerializeField] private GameObject loginWindow;

        [Header("Username")]
        [SerializeField] private TMP_InputField usernameField;

        [Header("Password")]
        [SerializeField] private TMP_InputField passwordField;
        [SerializeField] private Image passwordDisplay;
        [SerializeField] private Sprite eyeCloseImage;
        [SerializeField] private Sprite eyeOpenImage;

        private Animator anim;
        private const string INIT = "Init";

        private string username;
        private string password;

        private bool isPasswordHidden = true;

        void Start()
        {
            anim = GetComponent<Animator>();

            // Bind manually to input fields
            usernameField.onEndEdit.AddListener(UpdateUsername);
            passwordField.onEndEdit.AddListener(UpdatePassword);

            loginWindow.SetActive(false);
            splashScreen.OnSplashScreenFinished += InitWindow;
        }

        private void InitWindow()
        {
            anim.SetTrigger(INIT);
            loginWindow.SetActive(true);
        }

        #region ComponentFunction

        //                                     
        // Functions used by components 
        //                                     

        // Used by Username Input Field
        private void UpdateUsername(string _username)
        {
            username = _username;
            print(username);
        }

        // Used by Password Input Field
        private void UpdatePassword(string _password)
        {
            password = _password;
            print(password);
        }

        // Used by Password Display Button
        public void SetPasswordDisplay()
        {
            isPasswordHidden = !isPasswordHidden;

            if (isPasswordHidden)
            {
                passwordField.contentType = TMP_InputField.ContentType.Password;
                passwordField.ForceLabelUpdate();

                passwordDisplay.sprite = eyeCloseImage;
            }
            else
            {
                passwordField.contentType = TMP_InputField.ContentType.Standard;
                passwordField.ForceLabelUpdate();

                passwordDisplay.sprite = eyeOpenImage;
            }
        }

        // Used by Login Button
        public void ConnectUser()
        {
            if (username != "" && password != "") print("Login");
        }

        #endregion

    }
}

