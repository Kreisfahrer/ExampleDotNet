namespace Rmhp_Framework.PageObjects
{
    public class Employer
    {
        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string Zip { get; set; }

        public string Sic { get; set; }

        public Employer(string companyName, string address, string zip, string sic)
        {
            CompanyName = companyName;
            Address = address;
            Zip = zip;
            Sic = sic;
        }
    }
}