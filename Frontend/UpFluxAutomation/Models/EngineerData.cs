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

            builder.AppendLine( String.Format("UpFluxEndPoint{0}:", this.UpFluxEndPoint));
            builder.AppendLine(String.Format("Email {0}:", this.Email));
            builder.AppendLine(String.Format("EngineerToken {0}:", this.EngineerToken));

            return builder.ToString();
        }

    }
}
