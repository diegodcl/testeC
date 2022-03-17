namespace Volvo.Domain.Models
{
    public class Truck : BaseModel
    {
        public string SerialNumber { get; set; }
        public string Model { get; set; }
        public int YearModel { get; set; }
        public DateTime Manufactured { get; set; }

        public bool validateDate() 
        {
            DateTime temp;
            var date = this.Manufactured.ToString();
            if(DateTime.TryParse(date, out temp))
            {
                return true;
            }
            else
            {
                try
                {
                    var newDate = DateTime.ParseExact(
                        date,
                        "yyyy-MM-dd", 
                        System.Globalization.CultureInfo.InvariantCulture
                    );

                    this.Manufactured = newDate;
                    return true;

                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
        }

        public bool validateModel()
        {
            if (!(this.Model=="FM" || this.Model=="FH"))
            {
                return false;
            }else{
                return true;
            }
        }
    }
}