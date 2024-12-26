using System.Text;

namespace UpFluxAutomation.Models
{
    public class EngineerData
    {
        public string UpFluxEndPoint { get; set; }
        public string Email { get; set; }
        public string EngineerToken { get; set; }


        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"UpFluxEndPoint: {this.UpFluxEndPoint}");
            builder.AppendLine($"Email: {this.Email}");
            builder.AppendLine($"EngineerToken: {this.EngineerToken}");

            return builder.ToString();
        }

    }
}
