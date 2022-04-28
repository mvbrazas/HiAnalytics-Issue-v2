using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using newsmobileapp.Droid.Helpers;
using Huawei.Agconnect.Config;
using Huawei.Hms.Aaid;

namespace newsmobileapp.Droid
{
    [Activity(Label = "newsmobileapp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            InitializeHMSToken();

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            LoadApplication(new App());
        }

        private void InitializeHMSToken()
        {
            try
            {
                AnalyticsManager.Init(this);
                System.Threading.Thread thread = new System.Threading.Thread(() =>
                {
                    try
                    {
                        string appid = AGConnectServicesConfig.FromContext(this).GetString("client/app_id");
                        string token = HmsInstanceId.GetInstance(this).GetToken(appid, "HCM");
                        Console.WriteLine($"TOKEN: {token}");
                    }
                    catch (Java.Lang.Exception e)
                    {
                        Console.WriteLine(e);
                    }
                });
                thread.Start();
            }
            catch (Java.Lang.Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
