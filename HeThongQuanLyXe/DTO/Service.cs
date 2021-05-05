using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyXe.DTO
{
    class Service
    {
        public Service()
        {

        }
        public Service(int ID, string ServiceName)
        {
            this.id = ID;
            this.serviceName = ServiceName;
        }
        
        public Service(int IDTypeVehicle, string TypeOfVehicle,float PricePerHour)
        {
            this.idTypeOfVehicle = IDTypeVehicle;
            this.typeOfVehicle = TypeOfVehicle;
            this.pricePerHour = PricePerHour;
        }
        public Service(int ID, string ServiceName, int IDTypeVehicle, string TypeOfVehicle, float PricePerHour)
        {
            this.id = ID;
            this.serviceName = ServiceName;
            this.idTypeOfVehicle = IDTypeVehicle;
            this.typeOfVehicle = TypeOfVehicle;
            this.pricePerHour = PricePerHour;
        }
        private int id;
        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }
        private string serviceName;
        public string ServiceName
        {
            get { return this.serviceName; }
            set { this.serviceName = value; }
        }
        private int idTypeOfVehicle;
        public int IDTypeOfVehicle
        {
            get { return this.idTypeOfVehicle; }
            set { this.idTypeOfVehicle = value; }
        }
        private string typeOfVehicle;
        public string TypeOfVehicle
        {
            get { return this.typeOfVehicle; }
            set { this.typeOfVehicle = value; }
        }
        private float pricePerHour;
        public float PricePerHour
        {
            get { return this.pricePerHour; }
            set { this.pricePerHour = value; }
        }
        public float PricePerDay
        {
            get { return this.pricePerHour * 8; }
        }
        public float PricePerWeek
        {
            get { return this.PricePerDay * 3; }
        }
        public float PricePerMonth
        {
            get { return this.PricePerWeek * 2; }
        }
    }
}
