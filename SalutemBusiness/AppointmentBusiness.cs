using SalutemData;
using SalutemDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalutemBusiness
{
    public class AppointmentBusiness
    {
        //atributos
        private string connectionString;
        AppointmentData appointmentData;

        public AppointmentBusiness(string conn)
        {
            this.connectionString = conn;
            appointmentData = new AppointmentData(this.connectionString);
        }

        public string validateDateBusiness(string date, int hour)
        {
            string message = "";

            message = appointmentData.validateDateData(date, hour);

            return message;
        }

        public string insertAppointmentBusiness(Appointment appointment, Userr user)
        {
            string message = "";

            message = appointmentData.insertAppointmentData(appointment, user);

            return message;
        }

        public string updateAppointmentBusiness(Appointment appointment, Userr user, string oldDate, string oldHour)
        {
            string message = "";

            message = appointmentData.updateAppointmentData(appointment, user, oldDate, oldHour);

            return message;
        }

        public string cancelAppointmentBusiness(Appointment appointment)
        {
            string message = "";

            message = appointmentData.cancelAppointmentData(appointment);

            return message;
        }

        public string cancelAppointmentWithoutAppointmentIdBusiness(Appointment appointment, Userr user)
        {
            string message = "";

            message = appointmentData.cancelAppointmentWithoutAppointmentIdData(appointment, user);

            return message;
        }

        public List<Appointment> getAllAppointmentsBusiness()
        {
            List<Appointment> appointmentsList = appointmentData.getAllAppointmentsData();

            return appointmentsList;
        }

        public List<Appointment> getAllAppointmentsBusinessFilters(string identityCard)
        {
            List<Appointment> appointmentsList = appointmentData.getAllAppointmentsDataFilters(identityCard);

            return appointmentsList;
        }

        public List<Appointment> getAppointmentsBusinessFilters(string identityCard, string date)
        {
            List<Appointment> appointmentsList = appointmentData.getAppointmentsDataFilters(identityCard, date);

            return appointmentsList;
        }

        public List<Appointment> getAppointmentByIdentityCardBusiness(string identityCard)
        {
            List<Appointment> appointmentsList = appointmentData.getAppointmentByIdentityCardData(identityCard);

            return appointmentsList;
        }
    }
}
