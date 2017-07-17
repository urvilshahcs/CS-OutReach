﻿using DataOperations.DBEntity;
using DataOperations.DBEntityManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace CSOutreach
{
    public class Authentication
    {
        private static bool isvalidusername = true;
        private static bool isvalidpassword = true;
        private static string attemptedLoginUsername = String.Empty;

        public static void reset()
        {
            isvalidusername = true;
            isvalidpassword = true;
            attemptedLoginUsername = String.Empty;
        }


       

        public enum SessionVariable
        {
            USERNAME,
            ROLE,
            USERID
        }
        /// <summary>
        /// Returns true if a user of any role is logged in.
        /// </summary>
        public static bool Authenticated
        {
            get
            {
                if (HttpContext.Current.Session[SessionVariable.USERNAME.ToString()] != null)
                {
                    return true;
                }
                return false;
            }
        }
        /// <summary>
        /// Retrieves the username (email) from the Session.
        /// </summary>
        public static string Username
        {
            get
            {
                string username = (string)HttpContext.Current.Session[SessionVariable.USERNAME.ToString()];
                if (username != null)
                {
                    return username;
                }
                else { return String.Empty; }
            }
        }
        public static bool IsValidUserName
        {
            get { return isvalidusername; }
        }

        public static bool IsValidPassword
        {
            get { return isvalidpassword; }
        }

        public static string AttemptedLoginUsername
        {
            get { return attemptedLoginUsername; }
        }

        public static bool hasRequiredRole(Role role)
        {
            // TODO: Add real checking.
            return true;
        }

        /// <summary>
        /// Retrieves the userid from the Session.
        /// </summary>
        public static Int32 UserId
        {
            get
            {
                Int32 userid = Convert.ToInt32(HttpContext.Current.Session[SessionVariable.USERID.ToString()]);
                if (userid != null)
                {
                    return userid;
                }
                else { return 0; }
            }
        }



        /// <summary>
        /// Attempt login with user credentials.
        /// Side Effects: if the login fails, IsValidUsername, AttemptedLoginUsername, IsValidPassword are set to
        /// indicate the reasons for failure.
        /// </summary>
        /// <param name="username">Email address (used as username) of the user</param>
        /// <param name="password">Password entered by the user</param>
        /// <returns>true if successful, false if not</returns>
        public static Role login(string username, string password)
        {
            PersonDBManager personDBManager = new PersonDBManager();
            Person user = personDBManager.GetUser(username);


            if (user == null) // user == null
            {
                isvalidusername = false;
            }
            else
            {
                isvalidusername = true;
                attemptedLoginUsername = user.Email;

                if (matchingPasswords(password, user.Password))
                {
                    isvalidpassword = true;
                    HttpContext.Current.Session[Authentication.SessionVariable.USERNAME.ToString()] = user.Email;
                    HttpContext.Current.Session[SessionVariable.ROLE.ToString()] = user.Role.ToUpper();
                    HttpContext.Current.Session[SessionVariable.USERID.ToString()] = user.PersonId;
               
                }
                else
                {
                    isvalidpassword = false;
                    HttpContext.Current.Session["error_message"] += "<br />User name doesn't exist.";
                }
            }

            if (isvalidusername && isvalidpassword)
            {
                return ((Role)Enum.Parse(Type.GetType("CSOutreach.Role, CSOutreach"), HttpContext.Current.Session[SessionVariable.ROLE.ToString()].ToString(),true));
            }
            return Role.ANONYMOUS;
        }
        /// <summary>
        /// If a user is logged in, log them out. This is done simply by setting the user session variable to null.
        /// Any pages that require users to be logged in check the session for username and redirect if null.
        /// </summary>
        public static void logout()
        {
            HttpContext.Current.Session[Authentication.SessionVariable.USERNAME.ToString()] = null;
            HttpContext.Current.Session[Authentication.SessionVariable.USERID.ToString()] = null;
        }
        /// <summary>
        /// Compare an unhashed password (input) to hashed password from person object (person.password)
        /// </summary>
        /// <param name="inputPassword">password obtained from input</param>
        /// <param name="personPassword">password obtained form person object</param>
        /// <returns>true if matching, false if not</returns>
        public static bool matchingPasswords(string inputPassword, string personPassword)
        {
            MD5 MD5Hash = MD5.Create();
            byte[] PasswordBinary = Encoding.ASCII.GetBytes(inputPassword);
            string HashedPassword = Encoding.ASCII.GetString(MD5Hash.ComputeHash(PasswordBinary));

            return true ? HashedPassword == personPassword : false;
        }


    }
}