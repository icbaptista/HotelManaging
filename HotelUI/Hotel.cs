namespace HotelUI
{
    public class Hotel
    {
        internal string nRNET;
        internal string nome;
        internal string descrição;
        internal string rating;

        public override string ToString()
        {
            return nome + "   " + descrição + "   " + rating + "   " + nRNET;
        }
    }

    public class Room_Type
    {
        internal string room_type_id;
        internal string typology;
        internal string max_capacity;
        internal string beds_no;
        internal string size;
        internal string vista;
        internal string room_price;
        internal string image;

        public override string ToString()
        {
            return typology + "   " + beds_no + "   " + size + "   " + vista;
        }
    }

    public class Package
    {
        internal string package_ID;
        internal string free_breakfast;
        internal string meals_included;
        internal string package_price;
        internal string room_type_id;

        public override string ToString()
        {
            return package_ID + "   " + free_breakfast;
        }
    }
    public class Room
    {
        internal string room_no;
        internal string room_id;
        internal string room_type_id;
        internal string nRNET;
        public override string ToString()
        {
            return "Quarto disponível Nº: " + room_no;
        }
    }

    public class Reservation
    {
        internal string reservation_ID;
        internal string package_ID;
        internal string date_of_reservation;
        internal string guest_num;
        internal string reservor;
        internal string bill_ID;
        internal string date_in;
        internal string date_out;

        public override string ToString()
        {
            return date_of_reservation + "   " + reservation_ID + "   " + reservor + "   " + guest_num;
        }
    }

    internal class Guest
    {
        internal string guest_id;
        internal string CC;
        internal string review;
        internal string reserved_room_id;

        public override string ToString()
        {
            return guest_id + "   " + reserved_room_id;
        }
    }

    internal class Person
    {
        internal string firstname;
        internal string lastname;
        internal string CC;
        internal string gender;
        internal string age;
        internal string cellphone;

        public override string ToString()
        {
            return firstname + "   " + lastname;
        }
    }
}