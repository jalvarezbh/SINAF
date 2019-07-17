using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ProjetoMobile.Util
{
    public class Validacoes
    {        
        public bool CaracterValido(string caracter)
        {
            //variavel que verifica se é valido
            bool eValido = false;
            //capturo Letra atual
            string letraAtual = caracter;
            //Letras validas na digitação.
            string letrasValidas = @"qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNMçÇÉéèÈíÍÌìúÚùÙÁáàÀóÓòÒêÊÂâÔôÎîÛûãÃõÕ,.:-&1234567890 ";
            //valor de retorno do IndexOf
            int valorRetorno = 0;

            valorRetorno = letrasValidas.IndexOf(letraAtual);

            //Se for -1 não existe no conjunto de letras validas
            if (valorRetorno == -1 && (caracter != "\r" && caracter != "\b"))
                eValido = false;
            else
                eValido = true;

            return eValido;
        }
                
        public bool isCPF(string valor)
        {
            if (valor == "")
                return false;

            string cpf = valor;

            int d1, d2;
            int soma = 0;
            string digitado = "";
            string calculado = "";

            // Pesos para calcular o primeiro digito
            int[] peso1 = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            // Pesos para calcular o segundo digito
            int[] peso2 = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] n = new int[11];

            // Se o tamanho for < 11 entao retorna como inválido
            if (cpf.Length != 11)
                return false;

            // Caso coloque todos os numeros iguais
            switch (cpf)
            {
                case "11111111111":
                    return false;
                case "00000000000":
                    return false;
                case "22222222222":
                    return false;
                case "33333333333":
                    return false;
                case "44444444444":
                    return false;
                case "55555555555":
                    return false;
                case "66666666666":
                    return false;
                case "77777777777":
                    return false;
                case "88888888888":
                    return false;
                case "99999999999":
                    return false;
            }

            try
            {
                // Quebra cada digito do CPF
                n[0] = Convert.ToInt32(cpf.Substring(0, 1));
                n[1] = Convert.ToInt32(cpf.Substring(1, 1));
                n[2] = Convert.ToInt32(cpf.Substring(2, 1));
                n[3] = Convert.ToInt32(cpf.Substring(3, 1));
                n[4] = Convert.ToInt32(cpf.Substring(4, 1));
                n[5] = Convert.ToInt32(cpf.Substring(5, 1));
                n[6] = Convert.ToInt32(cpf.Substring(6, 1));
                n[7] = Convert.ToInt32(cpf.Substring(7, 1));
                n[8] = Convert.ToInt32(cpf.Substring(8, 1));
                n[9] = Convert.ToInt32(cpf.Substring(9, 1));
                n[10] = Convert.ToInt32(cpf.Substring(10, 1));
            }
            catch
            {
                return false;
            }

            // Calcula cada digito com seu respectivo peso
            for (int i = 0; i <= peso1.GetUpperBound(0); i++)
                soma += (peso1[i] * Convert.ToInt32(n[i]));

            // Pega o resto da divisao
            int resto = soma % 11;

            if (resto == 1 || resto == 0)
                d1 = 0;
            else
                d1 = 11 - resto;

            soma = 0;

            // Calcula cada digito com seu respectivo peso
            for (int i = 0; i <= peso2.GetUpperBound(0); i++)
                soma += (peso2[i] * Convert.ToInt32(n[i]));

            // Pega o resto da divisao
            resto = soma % 11;
            if (resto == 1 || resto == 0)
                d2 = 0;
            else
                d2 = 11 - resto;

            calculado = d1.ToString() + d2.ToString();
            digitado = n[9].ToString() + n[10].ToString();

            // Se os ultimos dois digitos calculados bater com
            // os dois ultimos digitos do cpf entao é válido
            if (calculado == digitado)
                return (true);
            else
                return (false);
        }

        public Boolean VerificaCnpj(String cnpj)
        {

            if (Regex.IsMatch(cnpj, @"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)"))
            {

                return validaCnpj(cnpj);

            }

            else
            {

                return false;

            }

        }
                
        private Boolean validaCnpj(String cnpj)
        {
            Int32[] digitos, soma, resultado;

            Int32 nrDig;

            String ftmt;

            Boolean[] cnpjOk;

            cnpj = cnpj.Replace("/", "");

            cnpj = cnpj.Replace(".", "");

            cnpj = cnpj.Replace("-", "");

            if (cnpj == "00000000000000")
            {
                return false;
            }

            ftmt = "6543298765432";

            digitos = new Int32[14];

            soma = new Int32[2];

            soma[0] = 0;

            soma[1] = 0;

            resultado = new Int32[2];

            resultado[0] = 0;

            resultado[1] = 0;

            cnpjOk = new Boolean[2];

            cnpjOk[0] = false;

            cnpjOk[1] = false;

            try
            {
                for (nrDig = 0; nrDig < 14; nrDig++)
                {

                    digitos[nrDig] = int.Parse(cnpj.Substring(nrDig, 1));

                    if (nrDig <= 11)

                        soma[0] += (digitos[nrDig] *

                        int.Parse(ftmt.Substring(nrDig + 1, 1)));

                    if (nrDig <= 12)

                        soma[1] += (digitos[nrDig] *

                        int.Parse(ftmt.Substring(nrDig, 1)));
                }

                for (nrDig = 0; nrDig < 2; nrDig++)
                {

                    resultado[nrDig] = (soma[nrDig] % 11);

                    if ((resultado[nrDig] == 0) || (resultado[nrDig] == 1))

                        cnpjOk[nrDig] = (digitos[12 + nrDig] == 0);

                    else

                        cnpjOk[nrDig] = (digitos[12 + nrDig] == (

                        11 - resultado[nrDig]));

                }

                return (cnpjOk[0] && cnpjOk[1]);

            }
            catch
            {
                return false;
            }

        }
                
        public Boolean ValidaCpfCnpj(string cpfCnpj)
        {
            if (cpfCnpj.Length <= 11)
                return isCPF(cpfCnpj);
            else
                return VerificaCnpj(cpfCnpj);
        }
               
        public bool ValidaEmail(string email)
        {
            bool validaArroba = false;
            bool validaPonto = false;
            int guardaPosicoes = 0;

            for (int i = 0; i < email.Length; i++)
            {
                if (email.Substring(i, 1) == "@")
                {
                    validaArroba = true;
                    guardaPosicoes = i;
                }
                if (validaArroba)
                {
                    if (email.Substring(i, 1) == ".")
                    {
                        if (guardaPosicoes != 0 && !(guardaPosicoes + 1 == i))
                            validaPonto = true;
                    }
                }
            }

            return validaPonto;
        }
                
        public bool ValidaIP(string IP)
        {
            //Pegando as seções do IP.
            string[] strVetIP = IP.Split('.');

            //Se o IP não tiver 4 partes, já é inválido (IPv4)
            if (strVetIP.Length != 4)
            {
                return false;
            }

            //Convertendo cada parte em byte, pra verificar se as partes são válidas.
            byte[] bytIP = new byte[4];
            int intCount = 0;
            foreach (string str in strVetIP)
            {
                try
                {
                    bytIP[intCount] = byte.Parse(str);
                }
                catch
                {
                    return false;
                }
                intCount++;
            }

            //Verificando se o primeiro byte é igual a 0 (zero) ou igual a 255
            if ((bytIP[0] == 0) || (bytIP[0] == 255))
            {
                return false;
            }

            //Verificando se o segundo octeto do IP é 255 e o terceiro não.
            if ((bytIP[1] == 255) && (bytIP[2] != 255))
            {
                return false;
            }

            //Verificando se o terceiro octeto do IP é 255 e o quarto não.
            if ((bytIP[2] == 255) && (bytIP[3] != 255))
            {
                return false;
            }

            return true;
        }
    }
}
