using System;
namespace CentralTelefonica.Util
{
    public class OpcionMenuException : Exception
    {        
        private string message = "Error, debe de ingresar un número no un caracter";
        public override string Message
        {
            get { return message;}
        }        
    }
}