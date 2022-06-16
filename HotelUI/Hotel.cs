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

        public override string ToString()
        {
            return typology + "   " + beds_no + "   " + size + "   " + vista;
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
}