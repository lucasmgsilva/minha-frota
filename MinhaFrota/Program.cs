using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trinity.Factory;
using Trinity.View;
namespace Trinity
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmViagem(null));
            //Application.Run(new FrmViagem(null));
            //Application.Run(new FrmAbastecimento());
            //Application.Run(new FrmRelatorioManutencao());
            //Application.Run(new FrmConsultaManutencao());
            //Application.Run(new FrmConsultaMulta());
            //Application.Run(new FrmInfracao());
            //Application.Run(new FrmApresentacao());
            //Application.Run(new FrmInfracao());
            //Application.Run(new FrmMulta(null));
            //Application.Run(new FrmInfracao());
            //Application.Run(new FrmConsultaManutencao());
            //Application.Run(new FrmConsultaManutencao());
            //Application.Run(new FrmCombustivel());
            //Application.Run(new FrmConsultaVeiculo());
            //Application.Run(new FrmMotorista(null));
            //Application.Run(new FrmManutencao(null));
            //Application.Run(new FrmProduto());
            //Application.Run(new FrmApresentacao());
            //Application.Run(new FrmProduto());
            //Application.Run(new FrmModelo());
            //Application.Run(new FrmUnidadeMedida());
            //Application.Run(new FrmServico());
            //Application.Run(new FrmConsultaVeiculo());
            //Application.Run(new FrmModelo());
            //Application.Run(new FrmVeiculo(null));
            //Application.Run(new FrmMarca());
            //Application.Run(new FrmCargo());
            //Application.Run(new FrmCliente(null));
            //Application.Run(new FrmApresentacao());
            //Application.Run(new FrmAcesso());
            //Application.Run(new FrmCargo());
            //Application.Run(new FrmPrincipal());
            //Application.Run(new FrmUsuario(null));
            //Application.Run(new FrmFornecedor());
            //Application.Run(new FrmEmpresa(null));
            //Application.Run(new FrmProduto());
            //Application.Run(new FrmUnidadeMedida());
            //Application.Run(new FrmMarca());
            //Application.Run(new FrmGrupo());
            //Application.Run(new FrmUnidadeMedida());
            //Application.Run(new FrmConsultaUsuario());
            //Application.Run(new FrmConsultaCliente());
        }
    }
}
