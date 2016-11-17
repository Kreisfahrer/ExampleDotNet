namespace Rmhp_Framework.PageObjects
{
    public class Employer
    {
        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string Zip { get; set; }

        public string Zic { get; set; }

        public Employer(string companyName, string address, string zip, string zic)
        {
            CompanyName = companyName;
            Address = address;
            Zip = zip;
            Zic = zic;
        }
    }
}