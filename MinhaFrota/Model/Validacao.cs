using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Trinity.Model
{
    public static class Validacao
    {
        public static bool ValidaCPF(string cpf)
        {
            if (cpf.Length != 14)
                return false;
            else
            {
                int calculo = 0;

                for (int i = 0, j = 10; i < 11; i++)
                    if (i != 3 && i != 7)
                        calculo += (cpf[i] - 48) * j--;

                calculo = 11 - calculo % 11;
                if (calculo == 10 || calculo == 11)
                    calculo = 0;

                if ((cpf[12] - 48) == calculo)
                {
                    calculo = 0;
                    for (int i = 0, j = 11; i < 13; i++)
                        if (i != 3 && i != 7 && i != 11)
                            calculo += (cpf[i] - 48) * j--;
                    calculo = 11 - calculo % 11;
                    if (calculo == 10 || calculo == 11)
                        calculo = 0;
                    if ((cpf[13] - 48) == calculo)
                        return true;
                }
                return false;
            }
        }

        public static bool ValidaCNPJ(string cnpj)
        {
            if (cnpj.Length != 18)
                return false;
            else
            {
                int calculo = 0;

                for (int i = 14, j = 2; i >= 0; i--)
                    if (i != 2 && i != 6 && i != 10)
                    {
                        if (j == 10)
                            j = 2;
                        calculo += (cnpj[i] - 48) * j++;
                    }
                calculo = (calculo % 11);
                if (calculo < 2)
                    calculo = 0;
                else calculo = 11 - calculo;
                if (calculo == cnpj[16] - 48)
                {
                    calculo = 0;
                    for (int i = 16, j = 2; i >= 0; i--)
                        if (i != 2 && i != 6 && i != 10 && i != 15)
                        {
                            if (j == 10)
                                j = 2;
                            calculo += (cnpj[i] - 48) * j++;
                        }
                    calculo = (calculo % 11);
                    if (calculo < 2)
                        calculo = 0;
                    else calculo = 11 - calculo;
                    if (calculo == cnpj[17] - 48)
                        return true;
                }
                return false;
            }
        }


        public static bool ValidaCNH(String cnh)
        {
            try
            {
                char char1 = cnh[0];

                if (cnh.Replace("\\D+", "").Length != 11
                        || String.Format("%0" + 11 + "d", 0).Replace('0', char1).Equals(cnh))
                {
                    return false;
                }

                long v = 0, j = 9;

                for (int i = 0; i < 9; ++i, --j)
                {
                    v += ((cnh[i] - 48) * j);
                }

                long dsc = 0, vl1 = v % 11;

                if (vl1 >= 10)
                {
                    vl1 = 0;
                    dsc = 2;
                }

                v = 0;
                j = 1;

                for (int i = 0; i < 9; ++i, ++j)
                {
                    v += ((cnh[i] - 48) * j);
                }

                long x = v % 11;
                long vl2 = (x >= 10) ? 0 : x - dsc;

                return (vl1.ToString() + vl2.ToString()).Equals(cnh.Substring(cnh.Length - 2));
            } catch
            {
                return false;
            }
        }

        public static bool ValidaRenavam(string RENAVAM)
        {
            if (string.IsNullOrWhiteSpace(RENAVAM.Trim())) return false;
            if (RENAVAM.Length != 11) return false;

            int[] d = new int[11];
            string sequencia = "3298765432";
            string SoNumero = Regex.Replace(RENAVAM, "[^0-9]", string.Empty);

            if (string.IsNullOrEmpty(SoNumero)) return false;

            //verificando se todos os numeros são iguais **************************
            if (new string(SoNumero[0], SoNumero.Length) == SoNumero) return false;
            SoNumero = Convert.ToInt64(SoNumero).ToString("00000000000");

            int v = 0;

            for (int i = 0; i < 11; i++)
                d[i] = Convert.ToInt32(SoNumero.Substring(i, 1));

            for (int i = 0; i < 10; i++)
                v += d[i] * Convert.ToInt32(sequencia.Substring(i, 1));

            v = (v * 10) % 11; v = (v != 10) ? v : 0;
            return (v == d[10]);
        }

        public static bool ValidaPlacaVeiculo (string placa)
        {
            if (placa.Length != 8) return false;

            Regex regex = new Regex(@"^[a-zA-Z]{3}\-\d{4}$");

            if (regex.IsMatch(placa))
            {
                return true;
            }

            return false;
        }

        public static int CalculaIdade(DateTime DataNascimento)
        {
            int anos = DateTime.Now.Year - DataNascimento.Year;

            if (DateTime.Now.Month < DataNascimento.Month || (DateTime.Now.Month == DataNascimento.Month && DateTime.Now.Day < DataNascimento.Day))
                anos--;
            return anos;
        }
    }
}
