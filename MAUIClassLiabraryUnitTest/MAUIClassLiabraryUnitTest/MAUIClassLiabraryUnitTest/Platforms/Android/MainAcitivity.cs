using Android.App;
using Android.Content.PM;
using Android.Content;
using Android.OS;
using Android.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Android.App.ActivityManager;

namespace MAUIClassLiabraryUnitTest.Platforms.Android
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        //  ActivityManager activityManager = LocalActivityManager();
        protected override void OnCreate(Bundle bundle)
        {
            ActivityManager activityManager = GetSystemService(Context.ActivityService) as ActivityManager;
            List<RunningAppProcessInfo> appProcesses = (List<RunningAppProcessInfo>)activityManager.GetRecentTasks(5, RecentTaskFlags.WithExcluded);
            foreach (RunningAppProcessInfo appProcess in appProcesses)
            {
                if (appProcess.Importance == RunningAppProcessInfo.ImportanceBackground)
                {
                    //Log.i("Foreground App", appProcess.ProcessName);
                    //SetNotification ();
                }
            }
            ActivityManager activityManager1 = GetSystemService(Context.ActivityService) as ActivityManager;

        }
    }
}
