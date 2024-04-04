using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using MelonLoader;
using Steamworks;

namespace TestMod
{
    public class Achievements
    {
        public static void GrantAchievementB(string achievementName)
        {





            if (GUILayout.Button(achievementName))
                MelonLogger.Msg("Granted Achievement " + achievementName);
            SteamUserStats.SetAchievement(achievementName);


        }

        public static void GrantAll()
        {
            SteamUserStats.SetAchievement("Kills_1");
            SteamUserStats.SetAchievement("Kills_50");
            SteamUserStats.SetAchievement("Money_100");
            SteamUserStats.SetAchievement("Money_500");
            SteamUserStats.SetAchievement("Money_1000");
            SteamUserStats.SetAchievement("War_Criminal");
            SteamUserStats.SetAchievement("Own_Gun_UZI");
            SteamUserStats.SetAchievement("Own_Gun_M4");
            SteamUserStats.SetAchievement("Own_Gun_M107");
            SteamUserStats.SetAchievement("Own_Gun_M249");
            MelonLogger.Msg("Granted ALL Achievements");


        }

    }
}
