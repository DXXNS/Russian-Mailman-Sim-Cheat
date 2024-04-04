using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MelonLoader;

namespace TestMod
{
    public class ESP
    {
        static Color lightBlue = new Color(0.0f, 1.0f, 1.0f); // R = 0, G = 1, B = 1



        
        public static void VodkaESP()
        {
            if (Modules.ESPVodka)
            {
                foreach (VodkaObject vodka in GameObject.FindObjectsOfType<VodkaObject>())
                {
                    //In-Game Position
                    Vector3 pivotPos = vodka.transform.position; //Pivot point NOT at the feet, at the center
                    Vector3 playerFootPos; playerFootPos.x = pivotPos.x; playerFootPos.z = pivotPos.z; playerFootPos.y = pivotPos.y - 0.1f; //At the feet
                    Vector3 playerHeadPos; playerHeadPos.x = pivotPos.x; playerHeadPos.z = pivotPos.z; playerHeadPos.y = pivotPos.y + 0.3f; //At the head+ 2f

                    //Screen Position
                    Vector3 w2s_footpos = Camera.main.WorldToScreenPoint(playerFootPos);
                    Vector3 w2s_headpos = Camera.main.WorldToScreenPoint(playerHeadPos);



                    if (w2s_footpos.z > 0f)
                    {
                        if (Modules.ESPVodkaSnap)
                            Render.DrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height * 2)), new Vector2(w2s_footpos.x, (float)Screen.height - w2s_footpos.y), lightBlue, 1.5f);
                        

                        Render.DrawColorString(new Vector2(w2s_headpos.x, (float)Screen.height - w2s_headpos.y + 0.4f), "Vodka Bottle", lightBlue, 11f);
                        DrawBoxESP(w2s_footpos, w2s_headpos, lightBlue);
                    }
                }
            }
        }


        public static void MainESP(GameObject gameObject)
        {
            //In-Game Position
            Vector3 pivotPos = gameObject.transform.position; //Pivot point NOT at the feet, at the center
            Vector3 playerFootPos; playerFootPos.x = pivotPos.x; playerFootPos.z = pivotPos.z; playerFootPos.y = pivotPos.y - 0.1f; //At the feet
            Vector3 playerHeadPos; playerHeadPos.x = pivotPos.x; playerHeadPos.z = pivotPos.z; playerHeadPos.y = pivotPos.y + 0.3f; //At the head+ 2f

            //Screen Position
            Vector3 w2s_footpos = Camera.main.WorldToScreenPoint(playerFootPos);
            Vector3 w2s_headpos = Camera.main.WorldToScreenPoint(playerHeadPos);



            if (w2s_footpos.z > 0f)
            {
                
                Render.DrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height * 2)), new Vector2(w2s_footpos.x, (float)Screen.height - w2s_footpos.y), lightBlue, 1.5f);


                Render.DrawColorString(new Vector2(w2s_headpos.x, (float)Screen.height - w2s_headpos.y + 0.4f), "Vodka Bottle", lightBlue, 11f);
                DrawBoxESP(w2s_footpos, w2s_headpos, lightBlue);
            }
        }


        public static void EnemyESP()
        {
            if (Modules.ESPEnemy)
            {
                foreach (Enemy enemy in GameObject.FindObjectsOfType<Enemy>())
                {



                    //In-Game Position
                    Vector3 pivotPos = enemy.transform.position; //Pivot point NOT at the feet, at the center
                    Vector3 playerFootPos; playerFootPos.x = pivotPos.x; playerFootPos.z = pivotPos.z; playerFootPos.y = pivotPos.y - 0.5f; //At the feet
                    Vector3 playerHeadPos; playerHeadPos.x = pivotPos.x; playerHeadPos.z = pivotPos.z; playerHeadPos.y = pivotPos.y + 1.8f; //At the head+ 2f

                    //Screen Position
                    Vector3 w2s_footpos = Camera.main.WorldToScreenPoint(playerFootPos);
                    Vector3 w2s_headpos = Camera.main.WorldToScreenPoint(playerHeadPos);






                    if (w2s_footpos.z > 0f && enemy.GetHealth() > 0)//
                    {
                        Render.DrawColorString(new Vector2(w2s_headpos.x, (float)Screen.height - w2s_headpos.y + 0.2f), enemy.name, Color.red, 15f);
                        DrawBoxESP(w2s_footpos, w2s_headpos, Color.red);
                        if (Modules.ESPEnemySnap)
                            Render.DrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height * 2)), new Vector2(w2s_footpos.x, (float)Screen.height - w2s_footpos.y), Color.red, 1f);

                        

                        
                    }
                }
            }
        }










        public static void DrawBoxESP(Vector3 footpos, Vector3 headpos, Color color) //Rendering the ESP
        {
            float height = headpos.y - footpos.y - 5f;
            float widthOffset = 2.5f;
            float width = height / widthOffset - 5f;

            //ESP BOX


            Render.DrawBox(footpos.x - (width / 2), (float)Screen.height - footpos.y - height, width, height, color, 1f);

        }


    }
}
