using SalutemData;
using SalutemDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalutemBusiness
{
    public class DiagnosisBusiness
    {
        #region
        //atributos
        private string connectionString;
        private DiagnosisData diagnosisData;
        #endregion

        public DiagnosisBusiness(string conn)
        {
            this.connectionString = conn;
            diagnosisData = new DiagnosisData(this.connectionString);
        }

        public string validateDateBusiness(string date, int hour)
        {
            string message = "";

            message = diagnosisData.validateDateData(date, hour);

            return message;
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

        public string updateDiagnosisWithoutDiagnosisIdBusiness(Diagnosis diagnosis, Userr user, string oldDate, string oldHour)
        {
            string message = "";

            message = diagnosisData.updateDiagnosisWithoutDiagnosisIdData(diagnosis, user, oldDate, oldHour);

            return message;
        }

        public List<Diagnosis> getAllDiagnosisBusiness()
        {
            List<Diagnosis> diagnosisList = diagnosisData.getAllDiagnosisData();

            return diagnosisList;
        }

        public List<Diagnosis> getDiagnosisBusinessFilters(string identityCard)
        {
            List<Diagnosis> diagnosisList = diagnosisData.getDiagnosisDataFilters(identityCard);

            return diagnosisList;
        }

    }
}
