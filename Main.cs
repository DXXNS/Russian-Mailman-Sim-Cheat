using MelonLoader;
using MelonLoader.ICSharpCode.SharpZipLib.Zip.Compression;
using Microsoft.Cci;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestMod
{
    public static class BuildInfo
    {
        public const string Name = "Russian Cheat"; 
        public const string Description = "A cheat for russian mailman sim"; 
        public const string Author = "DXXNS"; 
        public const string Company = null; 
        public const string Version = "3.7.9"; 
        public const string DownloadLink = null; 
    }

    




    public class TestMod : MelonMod
    {
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        
        
        
        
        public static KeyCode aimkey = KeyCode.LeftAlt;
        public static int smooth = 2;
        public static int fov = 3;






        public override void OnUpdate()
        {



            Modules.RunModules();
            



            //Aimbot
            float minDist = 99999;
            Vector2 AimTarget = Vector2.zero;
            try
            {
                foreach (Enemy go in GameObject.FindObjectsOfType<Enemy>())
                {
                    Transform[] allChildren = go.transform.GetComponentsInChildren<Transform>();

                    //In-Game Position
                    Vector3 pivotPos = go.transform.position; //Pivot point NOT at the feet, at the center

                    Vector3 playerHeadPos; playerHeadPos.x = pivotPos.x; playerHeadPos.z = pivotPos.z; playerHeadPos.y = pivotPos.y + 1.3f; //At the head  + 2f



                    var shit = Camera.main.WorldToScreenPoint(playerHeadPos);
                    if (shit.z > -8 && go.GetHealth() > 0)
                    {
                        float dist = System.Math.Abs(Vector2.Distance(new Vector2(shit.x, Screen.height - shit.y), new Vector2((Screen.width / 2), (Screen.height / 2))));
                        if (dist < 300) //in fov
                        {
                            if (dist < minDist)
                            {
                                minDist = dist;
                                AimTarget = new Vector2(shit.x, Screen.height - shit.y);

                                /*if (Input.GetKey(aimkey))
                                {
                                    MelonLogger.Msg("Locked Enemy " + shit.x + "X, " + shit.y + "Y, " + shit.z + "Z");
                                }*/
                            }
                        }
                    }


                }
                if (AimTarget != Vector2.zero)
                {
                    double DistX = AimTarget.x - Screen.width / 2.0f;
                    double DistY = AimTarget.y - Screen.height / 2.0f;

                    //aimsmooth
                    DistX /= smooth;
                    DistY /= smooth;

                    //if aimkey is pressed


                    if (Input.GetKey(aimkey))
                    {
                        mouse_event(0x0001, (int)DistX, (int)DistY, 0, 0);
                        
                    }
                    

                    

                    //TriggerBot



                    if (Modules.Triggerbot)
                    {

                        foreach (Gun go in GameObject.FindObjectsOfType<Gun>())
                        {


                            GameObject gameObject = GameObject.Find("CasterObject");
                            RaycastHit raycastHit;
                            Vector3 pivotPos = go.transform.position;
                            if (Physics.Raycast(gameObject.transform.position,gameObject.transform.forward, out raycastHit))

                            {


                                //trigger shooting logic
                                //use mouse event to press left button

                                //include delay


                                /*
                                if (raycastHit.transform.tag.Equals("EnemyHead"))
                                {
                                    
                                    raycastHit.transform.gameObject.GetComponentInParent<Enemy>().Hit(go.damage * 3);
                                    if (raycastHit.transform.gameObject.GetComponentInParent<Enemy>().GetHealth() <= 0)
                                    {
                                        raycastHit.transform.gameObject.GetComponentInParent<Rigidbody>().AddForce(gameObject.transform.forward * 50f, ForceMode.Impulse);
                                    }
                                }*/
                            
                            }
                        }
                    }





                }
            }
            catch { }




        }


        



        //Window definition
        public Rect windowRect = new Rect(20, 20, 300, 450);
        public Rect windowRect1 = new Rect(400, 20, 300, 250);
        public Rect windowRect2 = new Rect(800, 20, 300, 500);
        

        //Window Background
        private Texture2D MakeTex(int width, int height, Color color)
        {
            Color[] pix = new Color[width * height];
            for (int i = 0; i < pix.Length; ++i)
            {
                pix[i] = color;
            }
            Texture2D result = new Texture2D(width, height);
            result.SetPixels(pix);
            result.Apply();
            return result;
        }
        
        





        public override void OnGUI()
        {
            //set window style
            GUIStyle customStyle = new GUIStyle(GUI.skin.window);

            // Set background color to a dark color (you can adjust these values)
            customStyle.normal.background = MakeTex(1, 1, new Color(0.1f, 0.1f, 0.1f, 1.0f)); // Adjust alpha as needed
            customStyle.focused.background = MakeTex(1, 1, new Color(0.1f, 0.1f, 0.1f, 1.0f)); // Adjust alpha as needed
            customStyle.onNormal.background = MakeTex(1, 1, new Color(0.1f, 0.1f, 0.1f, 1.0f)); // Adjust alpha as needed
            customStyle.hover.background = MakeTex(1, 1, new Color(0.1f, 0.1f, 0.1f, 1.0f)); // Adjust alpha as needed

            // Set text color to a light color
            customStyle.normal.textColor = Color.white; // Adjust text color as needed
            customStyle.focused.textColor = Color.white; // Adjust text color as needed
            customStyle.onNormal.textColor = Color.white; // Adjust text color as needed
            customStyle.hover.textColor = Color.white; // Adjust text color as needed





            windowRect = GUI.Window(0, windowRect, PlayerWindow, "Player Window", customStyle);
            
            if (Modules.Steam)
                windowRect2 = GUI.Window(2, windowRect2, SteamWindow, "Steam Window", customStyle);





            ESP.EnemyESP();
            
            
            ESP.VodkaESP();
            


        }


       




        // Make the contents of the window
        private void PlayerWindow(int windowID)
        {
            GUILayout.BeginVertical();

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("ESP"))
            {
                Modules.Misc = false;
                Modules.ESP = true;
                Modules.num3Clicked = false;
                Modules.num4Clicked = false;


                //Modules.ESPenableCheckbox = Modules.ESPlineCheckbox = Modules.ESPboxCheckbox = false;
            }

            if (GUILayout.Button("Misc"))
            {
                Modules.Misc = true;
                Modules.ESP = false;
                Modules.num3Clicked = false;
                Modules.num4Clicked = false;

                //Modules.infHeal = Modules.customHeal = false;
            }

            if (GUILayout.Button("Exploits"))
            {
                Modules.Misc = false;
                Modules.ESP = false;
                Modules.num3Clicked = true;
                Modules.num4Clicked = false;
            }

            if (GUILayout.Button("num4"))
            {
                Modules.Misc = false;
                Modules.ESP = false;
                Modules.num3Clicked = false;
                Modules.num4Clicked = true;
            }
            GUILayout.EndHorizontal();

            GUILayout.Space(10);



            GUILayout.Space(10);

            if (Modules.num3Clicked)
            {


                Modules.infHeal = GUILayout.Toggle(Modules.infHeal, "Inf Heal");
                Modules.infTime = GUILayout.Toggle(Modules.infTime, "Inf Time");
                Modules.infAmmo = GUILayout.Toggle(Modules.infAmmo, "Inf Ammo");
                Modules.noRecoil = GUILayout.Toggle(Modules.noRecoil, "NoRecoil");
                Modules.rapidFire = GUILayout.Toggle(Modules.rapidFire, "Rapid Fire");
                Modules.infTankHeal = GUILayout.Toggle(Modules.infTankHeal, "Inf Tank Heal");
                if (GUILayout.Button("Inf Money"))
                {
                    Modules.infMoney = true;
                }
                else
                {
                    Modules.infMoney = false;
                }


            }
            else if (Modules.num4Clicked)
            {

                Modules.Triggerbot = GUILayout.Toggle(Modules.Triggerbot, "Triggerbot");
            }
            else if (Modules.ESP)
            {


                
                Modules.ESPEnemy = GUILayout.Toggle(Modules.ESPEnemy, "Enemy Box");
                Modules.ESPEnemySnap = GUILayout.Toggle(Modules.ESPEnemySnap, "Enemy Snapline");

                GUILayout.Space(5);

                Modules.ESPVodka = GUILayout.Toggle(Modules.ESPVodka, "Vodka Box");
                Modules.ESPVodkaSnap = GUILayout.Toggle(Modules.ESPVodkaSnap, "Vodka Snapline");

            }

            else if (Modules.Misc)
            {
                if (Modules.infHeal)
                    Modules.customHeal = false;


                Modules.recoil = GUILayout.HorizontalSlider(Modules.recoil, 0f, 2f);

                Modules.customHeal = GUILayout.Toggle(Modules.customHeal, "Custom Heal");

                if (Modules.customHeal)
                {
                    GUILayout.Label(Modules.customHealInt + " HP");
                    Modules.customHealInt = Mathf.RoundToInt(GUILayout.HorizontalSlider(Modules.customHealInt, 1, 100));
                }
                else
                {
                    GUILayout.Space(10);
                    Modules.customHealInt = 5;
                }


                Modules.Steam = GUILayout.Toggle(Modules.Steam, "Show Steam Window");


            }

            GUILayout.EndVertical();

            GUI.DragWindow();
        }

       



        private void SteamWindow(int windowID)
        {
            GUILayout.BeginVertical();

            GUILayout.BeginHorizontal();






            GUILayout.EndHorizontal();

            GUILayout.Space(10);
            GUILayout.Label("Grant Achievements");

            Achievements.GrantAchievementB("Kills_1");
            Achievements.GrantAchievementB("Kills_50");
            Achievements.GrantAchievementB("Money_100");
            Achievements.GrantAchievementB("Money_500");
            Achievements.GrantAchievementB("Money_1000");
            Achievements.GrantAchievementB("War_Criminal");
            Achievements.GrantAchievementB("Own_Gun_UZI");
            Achievements.GrantAchievementB("Own_Gun_M4");
            Achievements.GrantAchievementB("Own_Gun_M107");
            Achievements.GrantAchievementB("Own_Gun_M249");

            

            





            
            GUILayout.Space(5);

            if (GUILayout.Button("Unlock All"))
                Achievements.GrantAll();





            GUILayout.Space(10);




            GUILayout.EndVertical();

            GUI.DragWindow();
        }
    }

}