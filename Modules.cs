using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TestMod
{
    public static class Modules
    {
        //Gun ammo
        public static bool infAmmo = false;
        public static bool customAmmo = false;
        public static int customAmmoInt = 1;

        //Player Health
        public static bool infHeal = false;
        public static bool customHeal = false;
        public static int customHealInt = 1;



        //ESP
        public static bool ESPenableCheckbox = false;
        public static bool ESPlineCheckbox = false;
        public static bool ESPboxCheckbox = false;

        //Enemy esp
        public static bool ESPEnemy = false;
        public static bool ESPEnemySnap = false;

        //Vodka ESP
        public static bool ESPVodka = false;
        public static bool ESPVodkaSnap = false;

        

        //Windows
        public static bool ESP = false;
        public static bool Misc = false;
        public static bool num3Clicked = false;
        public static bool num4Clicked = false;
        public static bool Steam = false;

        //Currently disabled
        public static bool aimbot = false;

        //Tank
        public static bool infTankHeal = false;


        //Experimental
        public static int cash = 10000;
        public static bool cashHack = false;


        //Gun
        public static bool noRecoil = false;
        public static float recoil = 0;
        public static bool rapidFire = false;
        public static float fireRate = 0;
        public static bool Triggerbot = false;


        //Player
        public static bool infStamina = false;
        public static bool infTime = false;
        public static bool infMoney = false;
        

        



        








        public static void RunModules()
        {
            if (Modules.infTime)
            {
                //Inf timer
                foreach (Mailman ti in GameObject.FindObjectsOfType<Mailman>())
                {
                    ti.timer = 10000f;
                }
            }



            if (Modules.infMoney)
            {
                
                PlayerPrefs.SetInt("money", 1000000);
            }




            //No recoil
            if (Modules.noRecoil)
            {
                foreach (Gun gunrecoil in GameObject.FindObjectsOfType<Gun>())
                {
                    gunrecoil.recoil = 0f;
                }
            }

            //Rapid fire
            if (Modules.rapidFire)
            {
                foreach (Gun gun in GameObject.FindObjectsOfType<Gun>())
                {
                    gun.fireRate = Modules.fireRate;
                }
            }
            


            //Infinite ammo
            if (Modules.infAmmo)
            {
                foreach (Gun gun in GameObject.FindObjectsOfType<Gun>())
                {
                    gun.magazineAmmo = 1;
                }
            }


            //Inf heal or custom heal
            if (Modules.infHeal && !Modules.customHeal)
            {
                foreach (Mailman player in GameObject.FindObjectsOfType<Mailman>())
                {
                    player.health = 100;
                }
            }
            if (!Modules.infHeal && Modules.customHeal)
            {
                foreach (Mailman player in GameObject.FindObjectsOfType<Mailman>())
                {
                    player.health = Modules.customHealInt;
                }
            }


            //inf tank heal
            if (Modules.infTankHeal)
            {
                foreach (Tank tank in GameObject.FindObjectsOfType<Tank>())
                {
                    Tank.health = 2100;
                }
            }
        }
    }

    
}
