using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMobile.Util
{
    public class Mask
    {
        public bool ApenasNumero(char digito, ref char digitoSaida)
        {
            digito = char.ToLower(digito);
            if (char.IsLetterOrDigit(digito))
            {
                if (char.IsNumber(digito))
                {
                    digitoSaida = digito;
                    return true;
                }

                if (digito.Equals('w'))
                {
                    digitoSaida = '1';
                    return true;
                }

                if (digito.Equals('e'))
                {
                    digitoSaida = '2';
                    return true;
                }

                if (digito.Equals('r'))
                {
                    digitoSaida = '3';
                    return true;
                }

                if (digito.Equals('s'))
                {
                    digitoSaida = '4';
                    return true;
                }

                if (digito.Equals('d'))
                {
                    digitoSaida = '5';
                    return true;
                }

                if (digito.Equals('f'))
                {
                    digitoSaida = '6';
                    return true;
                }

                if (digito.Equals('z'))
                {
                    digitoSaida = '7';
                    return true;
                }

                if (digito.Equals('x'))
                {
                    digitoSaida = '8';
                    return true;
                }

                if (digito.Equals('c'))
                {
                    digitoSaida = '9';
                    return true;
                }
            }

            return false;
        }

        public string RemoverCaracter(string palavra, int tamanho)
        {
            try
            {
                if (palavra.Length > tamanho)
                    palavra = palavra.Substring(0, tamanho - 1);

                palavra = palavra.Replace("'", string.Empty);
                palavra = palavra.Replace("_", string.Empty);
                palavra = palavra.Replace("-", string.Empty);

                return palavra;
            }
            catch (Exception)
            {
                return palavra;
            }
        }

    }
}
