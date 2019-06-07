﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DemoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ITaskService
    {

        [OperationContract]
        string Hello(string name);

        [OperationContract]
        int NoweZadanie(Zadanie zadanie);

        [OperationContract]
        Zadanie GetZadanie(int idZadania);


        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Zadanie
    {
        [DataMember]
        public string Tytul { get; set; }
        [DataMember]
        public DateTime Termin { get; set; }
    }
}
