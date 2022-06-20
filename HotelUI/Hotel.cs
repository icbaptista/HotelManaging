using System;

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
            return typology + "   " + beds_no + "   " + size + "   " + vista + "    " + max_capacity;
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
            return "Disponível: Quarto nº " + room_no + ", Piso = " + room_id.ToCharArray()[0] + ", Porta = " + room_id.ToCharArray()[1];
        }
    }

    public class Reserved_Room
    {
        internal string reserved_room_id;
        internal string check_in;
        internal string check_out;
        internal string reservation_ID;
        public override string ToString()
        {
            return reserved_room_id;
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

    public class Guest
    {
        internal string guest_id;
        internal string CC;
        internal string review;
        internal string reserved_room_id;

        public Guest(string guest_id, string CC, string review, string reserved_room_id)
        {
            this.guest_id = guest_id;
            this.reserved_room_id = reserved_room_id;
            this.CC = CC;
            this.review = review; 
        }

        public override string ToString()
        {
            return "Guest " + guest_id + " hospedado no quarto " + reserved_room_id + "!";
        }
    }

    public class Person
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