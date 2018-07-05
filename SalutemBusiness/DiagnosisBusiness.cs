using SalutemData;
using SalutemDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalutemBusiness
{
    public class DiagnosisBusiness
    {
        //atributos
        private string connectionString;
        DiagnosisData diagnosisData;

        public DiagnosisBusiness(string conn)
        {
            this.connectionString = conn;
            diagnosisData = new DiagnosisData(this.connectionString);
        }

        public string insertDiagnosisBusiness(Diagnosis diagnosis, Userr user)
        {
            string message = "";

            message = diagnosisData.insertDiagnosisData(diagnosis, user);

            return message;
        }

        public string deleteDiagnosisBusiness(int id)
        {
            string message = "";

            message = diagnosisData.deleteDiagnosisData(id);

            return message;
        }

        public string deleteDiagnosisWithoutDiagnosisIdBusiness(Diagnosis diagnosis, Userr user)
        {
            string message = "";

            message = diagnosisData.deleteDiagnosisWithoutDiagnosisIdData(diagnosis, user);

            return message;
        }

        public string updateDiagnosisWithoutDiagnosisIdBusiness(Diagnosis diagnosis, Userr user)
        {
            string message = "";

            message = diagnosisData.updateDiagnosisWithoutDiagnosisIdData(diagnosis, user);

            return message;
        }
        
    }
}
