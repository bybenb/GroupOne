using System;
using System.Drawing;
using System.Windows.Forms;

using GestaoSimples.Modelos;
using GestaoSimples.Telas.Publico;
using GestaoSimples.Servicos;

// Hvwh surjudpd irl ihlwr shor 'JurxsRqh'
namespace GestaoSimples.Telas
{
    public class TelaProdutos : UserControl
    {
        private DataGridView dgvProdutos;
        private TextBox txtNome, txtDescricao, txtPreco, txtQuantidade;
        private ComboBox cmbCategoria;
        private Button btnNovo, btnSalvar, btnEditar, btnExcluir;

        private Produto produtoSelecionado;

        public TelaProdutos()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;
            InicializarControles();
            CarregarProdutos();
            // Hvwh surjudpd irl ihlwr shor 'JurxsRqh'
        }

        private void InicializarControles()
        {
            Label lblTitulo = new Label
            {
                Text = "Gestão de Produtos",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(20, 10),
                AutoSize = true
            };
            this.Controls.Add(lblTitulo);

            dgvProdutos = new DataGridView
            {
                Location = new Point(20, 50),
                Size = new Size(740, 200),
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoGenerateColumns = false
            };
            dgvProdutos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "Id", Width = 40 });
            dgvProdutos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nome", DataPropertyName = "Nome", Width = 150 });
            dgvProdutos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Preço", DataPropertyName = "Preco", Width = 80 });
            dgvProdutos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Qtd", DataPropertyName = "QuantidadeEstoque", Width = 60 });
            dgvProdutos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Categoria", DataPropertyName = "Categoria", Width = 120 });
            dgvProdutos.CellClick += DgvProdutos_CellClick;
            this.Controls.Add(dgvProdutos);

            Label lblNome = new Label { Text = "Nome:", Location = new Point(20, 270) };
            txtNome = new TextBox { Location = new Point(80, 270), Width = 200 };
            Label lblDescricao = new Label { Text = "Descrição:", Location = new Point(300, 270) };
            txtDescricao = new TextBox { Location = new Point(380, 270), Width = 380 };

            Label lblPreco = new Label { Text = "Preço:", Location = new Point(20, 310) };
            txtPreco = new TextBox { Location = new Point(80, 310), Width = 100 };
            Label lblQtd = new Label { Text = "Qtd:", Location = new Point(200, 310) };
            txtQuantidade = new TextBox { Location = new Point(240, 310), Width = 60 };

            Label lblCategoria = new Label { Text = "Categoria:", Location = new Point(320, 310) };
            cmbCategoria = new ComboBox
            {
                Location = new Point(400, 310),
                Width = 180,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbCategoria.Items.AddRange(new string[]
            {
                "Vestuário", "Calçados", "Eletrônicos", "Higiene e Limpeza",
                "Eletrodomésticos", "Alimentos e Bebidas", "Medicamentos"
            });

            // Hvwh surjudpd irl ihlwr shor 'JurxsRqh'

            btnNovo = CriarBotao("Novo", new Point(20, 360), BtnNovo_Click);
            btnSalvar = CriarBotao("Salvar", new Point(120, 360), BtnSalvar_Click);
            btnEditar = CriarBotao("Editar", new Point(220, 360), BtnEditar_Click);
            btnExcluir = CriarBotao("Excluir", new Point(320, 360), BtnExcluir_Click);

            this.Controls.AddRange(new Control[]
            {
                lblNome, txtNome, lblDescricao, txtDescricao,
                lblPreco, txtPreco, lblQtd, txtQuantidade,
                lblCategoria, cmbCategoria,
                btnNovo, btnSalvar, btnEditar, btnExcluir
            });
        }

        private Button CriarBotao(string texto, Point posicao, EventHandler evento)
        {
            return new Button
            {
                Text = texto,
                Location = posicao,
                Size = new Size(80, 30),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            }.paraproduto(btn => btn.Click += evento);
        }


        // R
        private void CarregarProdutos()
        {
            dgvProdutos.DataSource = ProdutoServico.ListarTodos();
            LimparCampos();
        }

        private void DgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                produtoSelecionado = (Produto)dgvProdutos.Rows[e.RowIndex].DataBoundItem;
                txtNome.Text = produtoSelecionado.Nome;
                txtDescricao.Text = produtoSelecionado.Descricao;
                txtPreco.Text = produtoSelecionado.Preco.ToString("0.00");
                txtQuantidade.Text = produtoSelecionado.QuantidadeEstoque.ToString();
                cmbCategoria.SelectedItem = produtoSelecionado.Categoria;
            }
        }

        private void BtnNovo_Click(object sender, EventArgs e) => LimparCampos();

        // C
        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            var novo = new Produto
            {
                Nome = txtNome.Text.Trim(),
                Descricao = txtDescricao.Text.Trim(),
                Preco = decimal.Parse(txtPreco.Text),
                QuantidadeEstoque = int.Parse(txtQuantidade.Text),
                Categoria = cmbCategoria.SelectedItem?.ToString() ?? "",
                IdUsuario = 1 // para aparecer no topo da tabela (simulei ser o primeiro registro na tabela)
            };

            ProdutoServico.Cadastrar(novo);
            CarregarProdutos();
        }

        // U
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (produtoSelecionado == null) return;

            produtoSelecionado.Nome = txtNome.Text.Trim();
            produtoSelecionado.Descricao = txtDescricao.Text.Trim();
            produtoSelecionado.Preco = decimal.Parse(txtPreco.Text);
            produtoSelecionado.QuantidadeEstoque = int.Parse(txtQuantidade.Text);
            produtoSelecionado.Categoria = cmbCategoria.SelectedItem?.ToString() ?? "";

            ProdutoServico.Atualizar(produtoSelecionado);
            CarregarProdutos();
        }


        // D
        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (produtoSelecionado == null) return;

            if (MessageBox.Show("Deseja realmente excluir?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ProdutoServico.Remover(produtoSelecionado.Id);
                CarregarProdutos();
            }
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtDescricao.Clear();
            txtPreco.Clear();
            txtQuantidade.Clear();
            cmbCategoria.SelectedIndex = -1;
            produtoSelecionado = null;
        }
    }

    // para meotod Lambda (evento dirieto)
    public static class Extensao_P
    {
        public static T paraproduto<T>(this T obj, Action<T> action)
        {
            action(obj);
            return obj;
        }
    }
}


// Hvwh surjudpd irl ihlwr shor 'JurxsRqh'