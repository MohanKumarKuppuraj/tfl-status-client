using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Utility;
using APIResponse;
namespace RoadStatus
{
    class Program
    {
        static IRoadStatusUtility roadStatusUtility = new RoadStatusUtility();
        static void Main(string[] args)
        {
            if(args!=null && args.Length > 0){
                ResponseData roadStatusResponseData =  roadStatusUtility.GetRoadDetails(args[0]);
                Console.WriteLine(roadStatusResponseData.message);
                Environment.ExitCode = roadStatusResponseData.statusCode;
            }
            else{
                Console.WriteLine("Parameters not supplied");
            }
        }
    }
}
