using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for Cryption
/// </summary>
public class Cryption
{
	public Cryption()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    /// <param name="InputText">Data to be encrypted</param>
    /// <param name="Password">The string to used for making the key.The same string
    public static string GetEncryptedSHA256(string strPassword)
    {
        UnicodeEncoding uEnCode = new UnicodeEncoding();
        Byte[] bytClearString = uEnCode.GetBytes(strPassword);
        SHA256 objCSHA256 = new SHA256Managed();
        Byte[] Hash = objCSHA256.ComputeHash(bytClearString);
        return Convert.ToBase64String(Hash);
    }
}