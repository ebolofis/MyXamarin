using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Plugin.Toasts;
using Android.Media;
using Lottie.Forms.Droid;

namespace testu.Droid
{
    //Icon = "@mipmap/icon", Theme = "@style/MainTheme  changed it to include the splashscreen"
    [Activity(Label = "testu", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        MediaPlayer player;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar; // standard declarations in all projects upon creation

            base.OnCreate(savedInstanceState);
          
           // player = MediaPlayer.Create(this, Resource.Raw.Imagine_Dragons___Believer__AudioTrimmer_com_);


            //Xamarin.Forms.Button button = FindViewById<Xamarin.Forms.Button>(Resource.Id.PlayButton);
            //button.Click += (sender, e) =>
            //{
            //    player.Start();
            //};


            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            AnimationViewRenderer.Init();
            OxyPlot.Xamarin.Forms.Platform.Android.PlotViewRenderer.Init(); // Initialization

            DependencyService.Register<ToastNotification>(); // Register your dependency
            ToastNotification.Init(this);

            LoadApplication(new App());   // Where the Application is loaded
           
            /// added a Log paradigm - Check on the same could be done on the Delegate file of IOS
            App.NativeLog = message => Android.Util.Log.WriteLine(Android.Util.LogPriority.Info, "MyLogTag", "Logging on Android");

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}