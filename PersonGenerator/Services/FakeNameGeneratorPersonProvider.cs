using HtmlAgilityPack;
using PersonGenerator.Models;

namespace PersonGenerator.Services
{
    public class FakeNameGeneratorPersonProvider : IPersonProvider
    {
        public ICollection<Person> Get(int quantity)
        {
            var personList = new List<Person>();

            for (int i = 0; i < quantity; i++)
            {
                personList.Add(Get());
            }

            return personList;
        }

        public Person Get()
        {
            string url = "https://es.fakenamegenerator.com/";
            
            HtmlWeb web = new();
            HtmlDocument doc = web.Load(url);
            
            var fullName = GetFullName(doc);
            var residence = GetResidence(doc);
            var birthDay = GetBirthDay(doc);
            var phoneNumber = GetFormatedPhoneNumber(doc);
            var email = GetEmail(doc);
            var creditCardInfo = GetCreditCardInfo(doc);
            var height = GetHeightInCm(doc);
            var weight = GetWeightInKg(doc);

            return new Person()
            {
                Name = fullName[0] + ".",
                Surname = fullName[1],
                BirthDay = birthDay,
                PhoneNumber = phoneNumber,
                Email = email,
                Residence = residence,
                CreditCardNumber = creditCardInfo.Number,
                CreditCardCVC = creditCardInfo.CVC,
                CreditCardVenceDate = creditCardInfo.VenceDate,
                Heigthcm = height,
                WeightKg = weight
            };
        }

        private String[] GetFullName(HtmlDocument doc)
        {
            return doc.DocumentNode.SelectSingleNode("//div[@class='address']/h3").InnerHtml.Split(".");
        }

        private String GetResidence(HtmlDocument doc)
        {
            return doc.DocumentNode.SelectSingleNode("//div[@class='address']/div").InnerHtml.Split("<br>")[0].Replace("\n", "").Trim();
        }

        private String GetBirthDay(HtmlDocument doc)
        {
            return doc.DocumentNode.SelectSingleNode("//dt[text()='Fecha de nacimiento']").SelectSingleNode("following-sibling::dd").InnerHtml;
        }

        private String GetFormatedPhoneNumber(HtmlDocument doc)
        {
            var countryCode = doc.DocumentNode.SelectSingleNode("//dt[text()='Country code']")
                .SelectSingleNode("following-sibling::dd").InnerHtml;
            var number = doc.DocumentNode.SelectSingleNode("//dt[text()='Teléfono']")
                .SelectSingleNode("following-sibling::dd").InnerHtml.Replace("-", "");

            return "+" + countryCode + " " + number;
        }

        private String GetEmail(HtmlDocument doc)
        {
            return doc.DocumentNode.SelectSingleNode("//dt[text()='Dirección de correo electrónico']")
                .SelectSingleNode("following-sibling::dd").InnerHtml.Split("<div")[0].Trim();
        }
        private (string Number, string CVC, string VenceDate) GetCreditCardInfo(HtmlDocument doc)
        {
            var creditCardHeader = doc.DocumentNode.SelectSingleNode("//h3[text()='Finance']");
            var creditCardNodes = creditCardHeader.SelectNodes("following-sibling::dl/dd");
            return (creditCardNodes[0].InnerHtml, creditCardNodes[2].InnerHtml, creditCardNodes[1].InnerHtml);
        }

        private int GetHeightInCm(HtmlDocument doc)
        {
            var heightStr = doc.DocumentNode.SelectSingleNode("//dt[text()='Altura']").SelectSingleNode("following-sibling::dd").InnerHtml;
            return int.Parse(heightStr.Split("(")[1].Split(" ")[0]);
        }

        private double GetWeightInKg(HtmlDocument doc)
        {
            var weightStr = doc.DocumentNode.SelectSingleNode("//dt[text()='Peso']").SelectSingleNode("following-sibling::dd").InnerHtml;
            return double.Parse(weightStr.Split("(")[1].Split(" ")[0].Replace(".", ","));
        }
    }
}
