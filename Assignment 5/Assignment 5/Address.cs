﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace Assignment5
{
    public class Address
    {
        private string street;
        private string city;
        private string zipcode;
        string pattern = @"^\d+$";

        public Address()
        {
        }
        /// <summary>
        /// Constructor with 1 (city) parameter - calls the constructor with 
        /// two parameters, using a default value as the second and third argument.
        /// </summary>
        /// <param name="city">input coming from the client object</param>
        /// <remarks></remarks>
        // This since the user should at least provide city
        // according to the assignment instructions 
        public Address(string city)
            : this(city, string.Empty, string.Empty)
        {

        }
        // Constructor with 2 parameters that chains to the constructor with 3 parameters
        // Since we dont know if the second parameter is street address or zipcode 
        // we have to determine wich type it is. 
        public Address(string city, string other)
            : this(city, CheckStreet(other), CheckZipcode(other))
        {
        }
        /// <summary>
        /// Constructor with three parameters. This is  constructor that has most
        /// number of parameters. It is in tis constructor that all coding 
        /// should be done.
        /// </summary>
        /// <param name="street">Input - street</param>
        /// <param name="city">Input - city</param>
        /// <param name="zipcode">Input - zipcode</param>
        /// <remarks></remarks>
        public Address(string city, string street, string zipcode)
        {
            this.city = city;
            this.street = street;
            this.zipcode = zipcode;
        }
        /// <summary>
        /// Copy constructor (Address) returning copy
        /// </summary>
        public Address(Address theOther)
        {
            this.street = theOther.street;
            this.city = theOther.city;
            this.zipcode = theOther.zipcode; 
        }
        #region Getters and Setters 
        public string Street
        {
            get { return street; }
            set { street = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        public string ZipCode
        {
            get { return zipcode; }
            set { zipcode = value; }
        }
        #endregion
        /// <summary>
        /// This method prepares a format string that is in sync with the ToString
        /// method.  It will be used in the MainForm as part of the heading for the ListBox
        /// before customer information is added in the ListBox.
        /// </summary>
        /// <value></value>
        /// <returns>A formatted string as heading for the values formatted in the ToString
        /// method below.</returns>
        /// <remarks></remarks>
        public string GetToStringItemsHeadings
        {
            get { return string.Format("{0,-20} {1, -20} {1, -20} ", "Street", "Zipcode", "City"); }
        }

        /// <summary>
        /// Delivers a formatted string with data stored in the object. The values will
        /// appear as columns.  Make sure that a font like "Courier New" is used in
        /// the control displaying this information.
        /// </summary>
        /// <returns>the Formatted strings.</returns>
        /// <remarks></remarks>
        public override string ToString()
        {
            string strOut = "\n" + "Address" + "\n";
            strOut += string.Format(" {0,-10} \n", "Street");
            strOut += string.Format(" {0,-10} {1, -10}\n\n", "Zipcode", "City");

            return strOut;
        }
        /// <summary>
        /// Determine if a string is a Zipcode 
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string CheckZipcode(string other)
        {
            // Check if "other" is numeric; if it is, assume it's a ZIP code
            string temp = other.Replace(" ", ""); 
            if ( int.TryParse(temp, out _) ) // It's a ZipCode
            {
                return other; // it's a ZipCode
            }
            else
            {
                // not a ZipCode, use ""  
                return ""; 
            }
        }
        /// <summary>
        /// Deterime if a string is an street (no numbers) 
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        private static string CheckStreet(string other)
        {
            // Check if "other" is numeric; if it is, assume it's a ZIP code
            string temp = other.Replace(" ", "");
            if (int.TryParse(temp, out _))
            {
                // If it's not a street name, use "" 
                return ""; 
            }
            else
            {
                return other; // Assume it's a street address
            }
        }
    }
}
