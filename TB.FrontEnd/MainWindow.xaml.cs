using System;
using System.Windows;
using TB.Core.Classes;
using TB.Core.Classes.Handler;
using TB.Core.Interfaces;

namespace TB.FrontEnd
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();

      try
      {
        // use privoxy for debugging and test performance because it needs a lot of time to restart the tor server and proxy each build.
        ITravianBot tb = new TravianBot(new System.Net.WebProxy(System.Net.IPAddress.Loopback.ToString(), 8118));

        String result = tb.Login("http://ts7.travian.de/", "MojoJojo", "mikey3321").ToString();
        //MessageBox.Show("Login: " + result);

        result = tb.Init().ToString();
        //MessageBox.Show("Init: " + result);

        result = tb.Logout().ToString();
        //MessageBox.Show("Logout: " + result);

        MessageBox.Show(String.Format("Login duration: {0}", tb.LoginDuration.ToString()));

        this.Close();
       
      }
      catch (Exception exception)
      {
        HInfo.LogHandler.Error("Unable to initilaize the bot", exception);
      }
    
    }
  }
}
