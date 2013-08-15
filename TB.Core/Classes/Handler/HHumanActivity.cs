using System;
using System.Threading;

namespace TB.Core.Classes.Handler
{
  public class HHumanActivity
  {

    public static void Simulate()
    {
      var  waitDuration = new Int32();
      var randomNumber  = new Random();

      if (HInfo.PConfig.SleepDurationBetweenActions <
          HInfo.PConfig.SleepDurationBetweenActionsDevianceMax)
      {
        HInfo.LogHandler.Error("SleepDurationBetweenActions is lower than SleepDuratoinBetweenActions_DevianceMax! Take a look in the PropertyConfig file");
        throw new Exception("SleepDurationBetweenActions is lower than SleepDuratoinBetweenActions_DevianceMax! Take a look in the PropertyConfig file");
      }

      waitDuration = randomNumber.Next(
          HInfo.PConfig.SleepDurationBetweenActionsDevianceMin,
          HInfo.PConfig.SleepDurationBetweenActionsDevianceMax
          );

      // if the random value is greater than 0.5 negate the waitDuration
      if (randomNumber.Next(0, 100) >= 50)
      {
        // negate the value to reduce the wait time
        waitDuration *= -1;
      }

      waitDuration += HInfo.PConfig.SleepDurationBetweenActions;

      HInfo.LogHandler.Debug(String.Format("Simulate human activity: WAIT {0} ms", waitDuration));
      Thread.Sleep(waitDuration);
    }
  }
}
