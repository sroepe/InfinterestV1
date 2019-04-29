namespace Infinterest.Models
{
public class Address
    {
        public int AddressId {get;set;}
        public string addressLine1 {get;set;}
        public string addressLine2 {get;set;}
        public string city {get;set;}
        public string postalCode {get;set;}
        public string state {get;set;}
        
        public Address()
        {

        }

        public Address(ListingForm UserInput)
        {
            addressLine1 = UserInput.addressLine1;
            addressLine2 = UserInput.addressLine2;
            city = UserInput.city;
            postalCode = UserInput.postalCode;
            state = UserInput.state;
        }

    }   
}