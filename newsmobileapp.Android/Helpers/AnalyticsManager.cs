using Xamarin.Forms;
using System.Collections.Generic;
using Android.OS;
using Android.App;
using Huawei.Hms.Analytics;
using System;
using newsmobileapp.Droid.Helpers;
using newsmobileapp.Models;

[assembly: Dependency(typeof(AnalyticsManager))]
namespace newsmobileapp.Droid.Helpers
{
    public class AnalyticsManager : IAnalyticsManager
    {
        static HiAnalyticsInstance instance;

        public static void Init(Activity mainActivity)
        {
            try
            {
                //Enable Analytics Kit Log
                HiAnalyticsTools.EnableLog();

                //Generate the Analytics Instance
                instance = HiAnalytics.GetInstance(mainActivity);

                //You can also use Context initialization
                //Context context = ApplicationContext;
                //instance = HiAnalytics.GetInstance(context);

                //Enable collection capability
                instance.SetAnalyticsEnabled(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void LogEvent(string eventId)
        {
            LogEvent(eventId, null);
        }

        public void LogEvent(string eventId, string paramName, string value)
        {
            LogEvent(eventId, new Dictionary<string, string>
            {
                {paramName, value}
            });
        }

        public void LogEvent(string eventId, IDictionary<string, string> parameters)
        {
            try
            {
                if (parameters == null)
                {
                    instance.OnEvent(eventId, null);
                    return;
                }

                var bundle = new Bundle();
                foreach (var item in parameters)
                {
                    bundle.PutString(item.Key, item.Value);
                }
                instance.OnEvent(eventId, bundle);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
