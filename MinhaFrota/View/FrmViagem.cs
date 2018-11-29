using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Trinity.Model.Bean;
using Trinity.Model.DAO;

namespace Trinity.View
{
    public partial class FrmViagem : Form
    {
        bool editando;
        Viagem viagemCarregada;

        public FrmViagem(Viagem viagemCarregada)
        {
            InitializeComponent();
            this.viagemCarregada = viagemCarregada;
            DesabilitaBotoes();
            CarregaVeiculos();
            CarregaMotoristas();
            CarregaEstado();
            txtDataChegada.Value = txtDataChegada.MinDate;
            if (this.viagemCarregada != null)
            {
                this.editando = true;
                new ViagemDAO().BuscaEnderecosViagens(viagemCarregada);
                CarregaViagem();
            }
            BuscaRotaEntreOrigemEDestino();
        }

        private void CarregaViagem()
        {
            cmbVeiculo.SelectedItem = ((List<Veiculo>)cmbVeiculo.DataSource).Find(v => v.IdVeiculo == viagemCarregada.Veiculo.IdVeiculo);
            txtKmSaida.Value = viagemCarregada.KmSaida;
            txtKmChegada.Value = viagemCarregada.KmChegada;
            cmbMotorista.SelectedItem = ((List<Motorista>)cmbMotorista.DataSource).Find(m => m.IdMotorista == viagemCarregada.Motorista.IdMotorista);
            txtDataSaida.Value = viagemCarregada.DataHoraSaida;
            txtDataChegada.Value = viagemCarregada.DataHoraChegada;

            txtCep.Text = this.viagemCarregada.ListaEndereco[0].Cep;
            cmbUf.SelectedItem = ((List<Estado>)cmbUf.DataSource).Find(es => es.IdEstado == viagemCarregada.ListaEndereco[0].Cidade.Estado.IdEstado);
            cmbCidade.SelectedItem = ((List<Cidade>)cmbCidade.DataSource).Find(c => c.IdCidade == viagemCarregada.ListaEndereco[0].Cidade.IdCidade);
            txtLogradouro.Text = this.viagemCarregada.ListaEndereco[0].Logradouro;
            txtNumero.Text = this.viagemCarregada.ListaEndereco[0].Numero;
            txtBairro.Text = this.viagemCarregada.ListaEndereco[0].Bairro;

            txtCEPDestino.Text = this.viagemCarregada.ListaEndereco[1].Cep;
            cmbUfDestino.SelectedItem = ((List<Estado>)cmbUfDestino.DataSource).Find(es => es.IdEstado == viagemCarregada.ListaEndereco[1].Cidade.Estado.IdEstado);
            cmbCidadeDestino.SelectedItem = ((List<Cidade>)cmbCidadeDestino.DataSource).Find(c => c.IdCidade == viagemCarregada.ListaEndereco[1].Cidade.IdCidade);
            txtLogradouroDestino.Text = this.viagemCarregada.ListaEndereco[1].Logradouro;
            txtNumeroDestino.Text = this.viagemCarregada.ListaEndereco[1].Numero;
            txtBairroDestino.Text = this.viagemCarregada.ListaEndereco[1].Bairro;
        }

        private void DesabilitaCampos()
        {
            cmbVeiculo.Enabled = false;
            txtKmSaida.Enabled = false;
            txtKmChegada.Enabled = false;
            cmbMotorista.Enabled = false;
            txtDataSaida.Enabled = false;
            txtDataChegada.Enabled = false;
            txtCep.Enabled = false;
            cmbUf.Enabled = false;
            cmbCidade.Enabled = false;
            txtLogradouro.Enabled = false;
            txtNumero.Enabled = false;
            txtBairro.Enabled = false;
            txtCEPDestino.Enabled = false;
            cmbUfDestino.Enabled = false;
            cmbCidadeDestino.Enabled = false;
            txtLogradouroDestino.Enabled = false;
            txtNumeroDestino.Enabled = false;
            txtBairroDestino.Enabled = false;
        }

        private void HabilitaCampos()
        {
            cmbVeiculo.Enabled = true;
            txtKmSaida.Enabled = true;
            txtKmChegada.Enabled = true;
            cmbMotorista.Enabled = true;
            txtDataSaida.Enabled = true;
            txtDataChegada.Enabled = true;
            txtCep.Enabled = true;
            cmbUf.Enabled = true;
            cmbCidade.Enabled = true;
            txtLogradouro.Enabled = true;
            txtNumero.Enabled = true;
            txtBairro.Enabled = true;
            txtCEPDestino.Enabled = true;
            cmbUfDestino.Enabled = true;
            cmbCidadeDestino.Enabled = true;
            txtLogradouroDestino.Enabled = true;
            txtNumeroDestino.Enabled = true;
            txtBairroDestino.Enabled = true;
        }

        private void HabilitaBotoes()
        {
            DesabilitaCampos();
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
        }

        private void DesabilitaBotoes()
        {
            HabilitaCampos();
            btnNovo.Enabled = !true;
            btnSalvar.Enabled = !false;
            btnEditar.Enabled = !true;
            btnExcluir.Enabled = !true;
        }

        private void LimpaCampos()
        {
            DesabilitaBotoes();

            cmbVeiculo.SelectedItem = null;
            txtKmSaida.Value = 0;
            txtKmChegada.Value = 0;
            cmbMotorista.SelectedItem = null;
            txtDataSaida.Value = DateTime.Now;
            txtDataChegada.Value = txtDataChegada.MinDate;
            txtCep.Text = String.Empty;
            cmbUf.SelectedIndex = 0;
            txtLogradouro.Text = String.Empty;
            txtNumero.Text = String.Empty;
            txtBairro.Text = String.Empty;
            txtCEPDestino.Text = String.Empty;
            cmbUfDestino.SelectedItem = 0;
            txtLogradouroDestino.Text = String.Empty;
            txtNumeroDestino.Text = String.Empty;
            txtBairroDestino.Text = String.Empty;
        }

        public void CarregaEstado()
        {
            cmbUf.DisplayMember = "uf";
            cmbUf.DataSource = new EstadoDAO().GetListaEstados();
            cmbUfDestino.DisplayMember = "uf";
            cmbUfDestino.DataSource = new EstadoDAO().GetListaEstados();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (cmbVeiculo != null && !String.IsNullOrWhiteSpace(txtKmSaida.Value.ToString().Trim()) && !String.IsNullOrWhiteSpace(txtKmChegada.Value.ToString().Trim()) 
                && !String.IsNullOrWhiteSpace(txtDataSaida.Value.ToString().Trim()) && !String.IsNullOrWhiteSpace(txtDataChegada.Value.ToString().Trim()) 
                && !String.IsNullOrWhiteSpace(txtCep.Text.Trim()) && cmbUf != null && cmbCidade != null && !String.IsNullOrWhiteSpace(txtLogradouro.Text.Trim()) 
                && !String.IsNullOrWhiteSpace(txtNumero.Text.Trim()) && !String.IsNullOrWhiteSpace(txtBairro.Text.Trim()) 
                && !String.IsNullOrWhiteSpace(txtCEPDestino.Text.Trim()) && cmbUfDestino != null && cmbCidadeDestino != null && !String.IsNullOrWhiteSpace(txtLogradouroDestino.Text.Trim())
                && !String.IsNullOrWhiteSpace(txtNumeroDestino.Text.Trim()) && !String.IsNullOrWhiteSpace(txtBairroDestino.Text.Trim()))
            {
                if (this.viagemCarregada == null)
                    this.viagemCarregada = new Viagem();

                viagemCarregada.Veiculo = (Veiculo)cmbVeiculo.SelectedItem;
                viagemCarregada.KmSaida = Convert.ToInt32(txtKmSaida.Value.ToString().Trim());
                viagemCarregada.KmChegada = Convert.ToInt32(txtKmChegada.Value.ToString().Trim());
                viagemCarregada.Motorista = (Motorista)cmbMotorista.SelectedItem;
                viagemCarregada.DataHoraSaida = txtDataSaida.Value;
                viagemCarregada.DataHoraChegada = txtDataChegada.Value;

                if (this.viagemCarregada.ListaEndereco == null)
                    this.viagemCarregada.ListaEndereco = new List<Endereco>();

                Endereco enderecoOrigem = new Endereco()
                {
                    Cep = txtCep.Text.Trim(),
                    Cidade = (Cidade)cmbCidade.SelectedItem,
                    Logradouro = txtLogradouro.Text.Trim(),
                    Numero = txtNumero.Text.Trim(),
                    Bairro = txtBairro.Text.Trim()
                };

                Endereco enderecoDestino = new Endereco()
                {
                    Cep = txtCEPDestino.Text.Trim(),
                    Cidade = (Cidade)cmbCidadeDestino.SelectedItem,
                    Logradouro = txtLogradouroDestino.Text.Trim(),
                    Numero = txtNumeroDestino.Text.Trim(),
                    Bairro = txtBairroDestino.Text.Trim()
                };

                if (this.viagemCarregada.ListaEndereco.Count == 0)
                {
                    viagemCarregada.ListaEndereco.Add(enderecoOrigem);
                    viagemCarregada.ListaEndereco.Add(enderecoDestino);
                } else
                {
                    int idEndereco = viagemCarregada.ListaEndereco[0].IdEndereco;
                    viagemCarregada.ListaEndereco[0] = enderecoOrigem;
                    viagemCarregada.ListaEndereco[0].IdEndereco = idEndereco;

                    idEndereco = viagemCarregada.ListaEndereco[1].IdEndereco;
                    viagemCarregada.ListaEndereco[1] = enderecoDestino;
                    viagemCarregada.ListaEndereco[1].IdEndereco = idEndereco;
                }

                ViagemDAO dao = new ViagemDAO();
                        if (!this.editando)
                            dao.AdicionaViagem(this.viagemCarregada);
                        else dao.AlteraViagem(this.viagemCarregada);
                        this.Close();
            } else MessageBox.Show("Não foi possível realizar a operação.\nHá CAMPOS OBRIGATÓRIOS que não foram preenchidos!", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        private void cmbUf_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCidade.DisplayMember = "cidade";
            cmbCidade.DataSource = new CidadeDAO().GetListaCidade((Estado)cmbUf.SelectedItem);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.editando = true;
            DesabilitaBotoes();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você realmente quer excluir esta VIAGEM?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ViagemDAO dao = new ViagemDAO();
                dao.DeletaViagem(this.viagemCarregada.IdViagem);
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (this.editando)
            {
                if (MessageBox.Show("Você realmente quer desfazer as alterações desta VIAGEM?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    HabilitaBotoes();
                    this.editando = false;
                    CarregaViagem();
                }
            }
            else this.Close();
        }

        private void tbcClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        private void CarregaVeiculos()
        {
            cmbVeiculo.DisplayMember = "placa";
            cmbVeiculo.DataSource = new VeiculoDAO().GetListaVeiculos();
        }

        private void CarregaMotoristas()
        {
            cmbMotorista.DisplayMember = "nome";
            cmbMotorista.DataSource = new MotoristaDAO().GetListaMotoristas();

        }

        private void cmbUfDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCidadeDestino.DisplayMember = "cidade";
            cmbCidadeDestino.DataSource = new CidadeDAO().GetListaCidade((Estado)cmbUfDestino.SelectedItem);
        }

        private void BuscaRotaEntreOrigemEDestino()
        {
            string logradouroOrigem = txtLogradouro.Text;
            string numeroOrigem = txtNumero.Text;
            string bairroOrigem = txtBairro.Text;
            string cidadeOrigem = String.Empty;
            if (cmbCidade.SelectedItem != null)
                cidadeOrigem = ((Cidade)cmbCidade.SelectedItem).cidade;
            string ufOrigem = String.Empty;
            if (cmbUf.SelectedItem != null)
                ufOrigem = ((Estado)cmbUf.SelectedItem).Uf;
            string cepOrigem = txtCep.Text;

            string logradouroDestino = txtLogradouroDestino.Text;
            string numeroDestino = txtNumeroDestino.Text;
            string bairroDestino = txtBairroDestino.Text;
            string cidadeDestino = String.Empty;
            if (cmbCidadeDestino.SelectedItem != null)
                cidadeDestino = ((Cidade)cmbCidadeDestino.SelectedItem).cidade;
            string ufDestino = String.Empty;
            if (cmbUfDestino.SelectedItem != null)
                ufDestino = ((Estado)cmbUfDestino.SelectedItem).Uf;
            string cepDestino = txtCEPDestino.Text;

            try
            {
                StringBuilder queryAddress = new StringBuilder();
                queryAddress.Append("https://www.google.com.br/maps/dir/");

                if (!String.IsNullOrWhiteSpace(logradouroOrigem))
                    queryAddress.Append(logradouroOrigem + "," + "+");

                if (!String.IsNullOrWhiteSpace(numeroOrigem))
                    queryAddress.Append(logradouroOrigem + "," + "+");

                if (!String.IsNullOrWhiteSpace(bairroOrigem))
                    queryAddress.Append(logradouroOrigem + "," + "+");

                if (!String.IsNullOrWhiteSpace(cidadeOrigem))
                    queryAddress.Append(cidadeOrigem + "," + "+");

                if (!String.IsNullOrWhiteSpace(ufOrigem))
                    queryAddress.Append(ufOrigem + "," + "+");

                if (!String.IsNullOrWhiteSpace(cepOrigem))
                    queryAddress.Append(cepOrigem + "," + "+");
                // ------ //
                queryAddress.Append("/");
                // ------ //

                if (!String.IsNullOrWhiteSpace(logradouroDestino))
                    queryAddress.Append(logradouroDestino + "," + "+");

                if (!String.IsNullOrWhiteSpace(numeroDestino))
                    queryAddress.Append(numeroDestino + "," + "+");

                if (!String.IsNullOrWhiteSpace(bairroDestino))
                    queryAddress.Append(bairroDestino + "," + "+");

                if (!String.IsNullOrWhiteSpace(cidadeDestino))
                    queryAddress.Append(cidadeDestino + "," + "+");

                if (!String.IsNullOrWhiteSpace(ufDestino))
                    queryAddress.Append(ufDestino + "," + "+");

                if (!String.IsNullOrWhiteSpace(cepDestino))
                    queryAddress.Append(cepDestino + "," + "+");

                webBrowser1.Navigate(queryAddress.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message.ToString());
            }
        }

        private void btnTracarRota_Click(object sender, EventArgs e)
        {
            BuscaRotaEntreOrigemEDestino();
        }
    }
}