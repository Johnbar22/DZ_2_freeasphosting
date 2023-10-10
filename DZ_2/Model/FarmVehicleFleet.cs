namespace DZ_2.Model
{
    public class FarmVehicleFleet   //фермерский автопарк
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int YearOfManufacture {  get; set; }

        public FarmVehicleFleet()
        {
            Name = "";
            Type = "";
        }

        public override string ToString()
        {
            return $"{Id} - {Name} - {Type} - {YearOfManufacture}";
        }

    }
}
