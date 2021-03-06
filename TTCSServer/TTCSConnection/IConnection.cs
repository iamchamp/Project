﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataKeeper.Engine;
using DataKeeper.Engine.Command;

namespace TTCSConnection
{
    [ServiceContract(CallbackContract = typeof(ServerCallBack))]
    public interface IConnection
    {
        [OperationContract]
        ReturnKnowType AstroCreateStation(STATIONNAME Site);

        [OperationContract]
        ReturnKnowType AstroCreateClientInterface(String InterfaceName);

        [OperationContract]
        ReturnKnowType AddImage(STATIONNAME StationName, DEVICENAME DeviceName, UInt16[][] Value, DateTime DataTimeStamp);

        [OperationContract]
        Object DatabaseSync(STATIONNAME StationName, String TableName, DATAACTION Action, List<Object[]> TableField);

        [OperationContract]
        void ReciveAcknowledge(STATIONNAME StationName, DEVICENAME StationDeviceName, DEVICENAME FieldDeviceName, String FieldName, Object[] Value, DateTime TimeRecive);

        [OperationContract]
        void AddTS700MM(STATIONNAME StationName, DEVICENAME DeviceName, TS700MM[] FieldName, Object[] Value, DateTime[] DateTime);

        [OperationContract]
        void AddASTROHEVENDOME(STATIONNAME StationName, DEVICENAME DeviceName, ASTROHEVENDOME[] FieldName, Object[] Value, DateTime[] DateTim);

        [OperationContract]
        void AddIMAGING(STATIONNAME StationName, DEVICENAME DeviceName, IMAGING[] FieldName, Object[] Value, DateTime[] DateTime);

        [OperationContract]
        void AddIMAGINGARRAY(STATIONNAME StationName, DEVICENAME DeviceName, int[][] Value, DateTime DateTime);

        [OperationContract]
        void AddSQM(STATIONNAME StationName, DEVICENAME DeviceName, SQM[] FieldName, Object[] Value, DateTime[] DateTime);

        [OperationContract]
        void AddSEEING(STATIONNAME StationName, DEVICENAME DeviceName, SEEING[] FieldName, Object[] Value, DateTime[] DateTime);

        [OperationContract]
        void AddALLSKY(STATIONNAME StationName, DEVICENAME DeviceName, ALLSKY[] FieldName, Object[] Value, DateTime[] DateTime);

        [OperationContract]
        void AddWEATHERSTATION(STATIONNAME StationName, DEVICENAME DeviceName, WEATHERSTATION[] FieldName, Object[] Value, DateTime[] DateTime);

        [OperationContract]
        void AddLANOUTLET(STATIONNAME StationName, DEVICENAME DeviceName, LANOUTLET[] FieldName, Object[] Value, DateTime[] DateTime);

        [OperationContract]
        void AddCCTV(STATIONNAME StationName, DEVICENAME DeviceName, CCTV[] FieldName, Object[] Value, DateTime[] DateTime);

        [OperationContract]
        void AddGPS(STATIONNAME StationName, DEVICENAME DeviceName, GPS[] FieldName, Object[] Value, DateTime[] DateTime);

        [OperationContract]
        Boolean AddASTROCLIENT(STATIONNAME StationName, DEVICENAME DeviceName, ASTROCLIENT[] FieldName, Object[] Value, DateTime[] DateTime);

        [OperationContract]
        void AddASTROSERVER(STATIONNAME StationName, DEVICENAME DeviceName, ASTROSERVER[] FieldName, Object[] Value, DateTime[] DateTime);

        [OperationContract]
        void GetStructure(ASTROCLIENT Astroclient, TS700MM TS700mm, ASTROHEVENDOME Dome, IMAGING Imaging, SQM Sqm, SEEING Seeing, ALLSKY Allsky, WEATHERSTATION Weatherstation, LANOUTLET Lanoutlet, CCTV CCTV, GPS GPS, ASTROSERVER Astroserver);

        [OperationContract]
        Boolean TTCSCheckConnection();

        [OperationContract]
        ReturnKnowType AstroSet(STATIONNAME StationName, DEVICENAME DeviceName, dynamic CommandName, Object[] Value, DateTime CommandDateTime);

        [OperationContract]
        void GetSetStructure(TS700MMSET TSSet, IMAGINGSET IMGSet, LANOUTLETSET LANSet, DOMESET DOMESet);

        [OperationContract]
        void SubscribeInformation(STATIONNAME StationName, DEVICENAME DeviceName, dynamic FieldName);

        [OperationContract]
        void UnsubscribeBySessionID();

        [OperationContract]
        void UnsubscribeByFieldName(STATIONNAME StationName, DEVICENAME DeviceName, dynamic FieldName);

        //[OperationContract]
        //UInt16[][] TTCSGetLastestImage(STATIONNAME StationName, DEVICENAME DeviceName);

        [OperationContract]
        List<INFORMATIONSTRUCT> GetInformation(STATIONNAME StationName, DEVICENAME DeviceName, dynamic FieldName);
    }

    public interface ServerCallBack
    {
        [OperationContract(IsOneWay = true)]
        void OnGRBTTCS(String Ra, String Dec, String Fov, DateTime UpdateTime);

        [OperationContract(IsOneWay = true)]
        void OnRelayCommand(STATIONNAME StationName, DEVICENAME DeviceName, dynamic CommandName, Object[] Value, DateTime CommanddateTime);

        [OperationContract(IsOneWay = true)]
        void OnScriptSET(List<ScriptStructure> ThisScript);

        [OperationContract(IsOneWay = true)]
        void OnTS700MMSET(STATIONNAME StationName, DEVICENAME DeviceName, TS700MMSET CommandName, Object[] Value, DateTime CommanddateTime);

        [OperationContract(IsOneWay = true)]
        void OnIMAGINGSET(STATIONNAME StationName, DEVICENAME DeviceName, IMAGINGSET CommandName, Object[] Value, DateTime CommanddateTime);

        [OperationContract(IsOneWay = true)]
        void OnLANOUTLETSET(STATIONNAME StationName, DEVICENAME DeviceName, LANOUTLETSET CommandName, Object[] Value, DateTime CommanddateTime);

        [OperationContract(IsOneWay = true)]
        void OnDOMESET(STATIONNAME StationName, DEVICENAME DeviceName, DOMESET CommandName, Object[] Value, DateTime CommanddateTime);

        [OperationContract(IsOneWay = true)]
        void OnNewObservation(OBSERVATIONSTRUCT[] NewObservation);

        [OperationContract(IsOneWay = true)]
        void OnPublish(STATIONNAME StationName, DEVICENAME DeviceName, dynamic FieldName, Object Value, DateTime UpdateTime);

        [OperationContract(IsOneWay = true)]
        void OnDatabaseSync(List<Object[]> AllInformation);
    }
}
