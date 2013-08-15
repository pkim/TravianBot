using System;
using System.IO;
using Handler.Settings.Property;
using TB.Core.Classes.Handler;

namespace TB.Core.Classes.Properties
{
  public class PHTTPParameters : Property<PHTTPParameters>
  {
    #region Constructor

    private PHTTPParameters()
    {
        #region Login
        this.Login = "login";
        this.LoginName  = "name";
        this.LoginPassword = "password";
        this.LoginS1 = "s1";
        this.LoginW = "w";
        this.LoginLowRes = "lowRes";
        #endregion Login

        #region Buildings
        this.BuildingID = "id";
        #endregion Buildings

        #region Train Units
        this.TrainUnitsID = "id";
        this.TrainUnitsZ  = "z";
        this.TrainUnitsA  = "a";
        this.TrainUnitsS  = "s";
        this.TrainUnitsT1 = "t1";
        this.TrainUnitsT2 = "t2";
        this.TrainUnitsT3 = "t3";
        this.TrainUnitsT4 = "t4";
        this.TrainUnitsT5 = "t5";
        this.TrainUnitsT6 = "t6";
        this.TrainUnitsT7 = "t7";
        this.TrainUnitsT8 = "t8";
        this.TrainUnitsT9 = "t9";
        #endregion Train Units

        #region Player
        this.PlayerUID = "uid";
        #endregion Player

        #region Village
        this.VillageNewdID = "newdid";
        #endregion village

        // create the output directory
        if (!Directory.Exists(HInfo.PGlobal.Settings))
        { Directory.CreateDirectory(HInfo.PGlobal.Settings); }
        this.OutputDirectory = HInfo.PGlobal.Settings;
    }
    #endregion Constructor 

    #region Properties
    #region Login
    public String LoginName { get; set; }
    public String LoginPassword { get; set; }
    public String LoginS1 { get; set; }
    public String LoginW { get; set; }
    public String Login { get; set; }
    public String LoginLowRes { get; set; }
    #endregion Login

    #region Buildings
    public String BuildingID { get; set; }
    #endregion Buildings

    #region Train Units
    public String TrainUnitsID { get; set; }
    public String TrainUnitsZ { get; set; }
    public String TrainUnitsA { get; set; }
    public String TrainUnitsS { get; set; }
    public String TrainUnitsT1 { get; set; }
    public String TrainUnitsT2 { get; set; }
    public String TrainUnitsT3 { get; set; }
    public String TrainUnitsT4 { get; set; }
    public String TrainUnitsT5 { get; set; }
    public String TrainUnitsT6 { get; set; }
    public String TrainUnitsT7 { get; set; }
    public String TrainUnitsT8 { get; set; }
    public String TrainUnitsT9 { get; set; }
    public String TrainUnitsS1 { get; set; }
    #endregion train untis

    #region Player
    public String PlayerUID { get; set; }
    #endregion player

    #region Village
    public String VillageNewdID { get; set; }
    #endregion Village
    #endregion Properties
  }
}
