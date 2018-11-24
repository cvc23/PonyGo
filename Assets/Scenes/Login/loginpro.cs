using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using Firebase.Auth;

public class loginpro : MonoBehaviour {

    public InputField inUser;
    public InputField inPass;
    public InputField inputT;

    public void Login()
    {
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

        string userrr = inUser.text;
        string passs = inPass.text;

        auth.SignInWithEmailAndPasswordAsync(userrr, passs).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);

            // Reportando evento de LogIn
            Firebase.Analytics.FirebaseAnalytics.LogEvent(Firebase.Analytics.FirebaseAnalytics.EventLogin);

            // Agregando el id del usauripo a variable global.
            PocketDroidsConstants.USER_ID = newUser.UserId;
            Debug.Log("Tenemos id: " + PocketDroidsConstants.USER_ID);

            string misMateriasRef = "alumnos/" + newUser.UserId + "/materias/Atrapadas";
            Debug.Log("Asi quedo la referencia: " + misMateriasRef);

            FirebaseDatabase.DefaultInstance
            .GetReference(misMateriasRef)
            .GetValueAsync()
            .ContinueWith(dbtask => {
                if (dbtask.IsFaulted)
                {
                 Debug.LogError("no está lo que quieres");
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = dbtask.Result;
                    Debug.Log("mira el resultado:" + snapshot.Children.ToString() );
                    foreach (var materia in snapshot.Children)
                    {
                        IDictionary dictSubject = (IDictionary)materia.Value;
                        Debug.Log ("id: " 
                        + dictSubject["id_materia"] 
                        + " atrapadas:  " 
                        + dictSubject["atrapadas"]
                        + " intentos:  " 
                        + dictSubject["intentos"] 
                        );
                        
                        PocketDroidsConstants.CAPTUREDPRO_SUBJECTS.Add(
                            new PocketDroidsConstants.Materia(
                                dictSubject["id_materia"].ToString(),
                                System.Int32.Parse(dictSubject["atrapadas"].ToString())
                            ) );

                    }
                    foreach (var statmat in PocketDroidsConstants.CAPTUREDPRO_SUBJECTS)
                     Debug.Log("Registre que tienes estas materias capturadas:  " + statmat.id_materia);   
                    
                }
            });

            List<GameObject> objects = new List<GameObject>();
            SceneTransitionManager.Instance.GoToScene(PocketDroidsConstants.SCENE_WORLD, objects);
            
        });
    }

    public void AnalyticsEvent()
    {
        Firebase.Analytics.FirebaseAnalytics.LogEvent(Firebase.Analytics.FirebaseAnalytics.EventLogin);
        Debug.Log("Pues ya, no?");
    }

    public void PushToDB(){
        string inputText = inputT.text;

        DatabaseReference dbref = FirebaseDatabase.DefaultInstance.RootReference;
        dbref.Child("testeo").Child("aidi").SetValueAsync(inputText) ;

    }

    public class User
    {
        public string username;
        public string email;

        public User()
        {
        }

        public User(string username, string email)
        {
            this.username = username;
            this.email = email;
        }
    }


}
