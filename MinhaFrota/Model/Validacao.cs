using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
