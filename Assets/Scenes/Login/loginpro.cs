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

            string alumnoRef = "alumnos/" + newUser.UserId;
            Debug.Log("Asi quedo la referencia: " + alumnoRef);

            FirebaseDatabase.DefaultInstance
            .GetReference(alumnoRef)
            .GetValueAsync()
            .ContinueWith(dbtask => {
                if (dbtask.IsFaulted)
                {
                 Debug.LogError("no está lo que quieres");
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = dbtask.Result;

                    // REcuperando los pasos avanzados
                    Debug.Log("Estos pasos recibi: "+ snapshot.Child("system").Child("pasosCaminados").Value);
                    PocketDroidsConstants.PLAYER_STEPS = System.Int32.Parse(snapshot.Child("system").Child("pasosCaminados").Value.ToString());
                    Debug.Log("gaurado" + PocketDroidsConstants.PLAYER_STEPS);

                    PocketDroidsConstants.USER_NICKNAME = snapshot.Child("nickname").Value.ToString();
                    Debug.Log("gaurado tu nickname" + PocketDroidsConstants.USER_NICKNAME);

                     /* RECUPERANDO MATERIAS  c a p t u r a d a s   */ 
                    foreach (var materia in snapshot.Child("materias").Child("Atrapadas").Children)
                    {
                        IDictionary dictSubject = (IDictionary)materia.Value;
                        Debug.Log ("id: " + materia.Key
                        + " atrapadas:  " + dictSubject["atrapadas"]
                        + " intentos:  " + dictSubject["intentos"] 
                        );
                        PocketDroidsConstants.CAPTUREDPRO_SUBJECTS.Add(
                            new PocketDroidsConstants.Materia(
                                materia.Key.ToString(),
                                System.Int32.Parse(dictSubject["atrapadas"].ToString()),
                                System.Int32.Parse(dictSubject["intentos"].ToString())
                            ) );
                    }
                    // Debug del registro
                    foreach (var statmat in PocketDroidsConstants.CAPTUREDPRO_SUBJECTS)
                     Debug.Log("Registre que tienes estas materias capturadas:  " + statmat.id_materia);   
                    

                    /* RECUPERANDO MATERIAS  A P R O V A D A S  */ 
                    foreach (var materia in snapshot.Child("materias").Child("Aprobadas").Children)
                    {
                        IDictionary dictSubject = (IDictionary)materia.Value;
                        Debug.Log ("id: " 
                        + materia.Key
                        + " Creditos:  " 
                        + dictSubject["creditos"]
                        + " Feccha:  " 
                        + dictSubject["fecha_aprobacion"] 
                        );    
                        PocketDroidsConstants.APROVED_SUBJECTS.Add(materia.Key);
                    }
                    // Debug del registro
                    foreach (var apSubject in PocketDroidsConstants.APROVED_SUBJECTS)
                     Debug.Log("Registre que tienes estas materias Aprovadas:  " + apSubject);
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
