using Dominus.DataModel;
using Dominus.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dominus.WebApp
{
    public partial class Contato : Page
    {
        protected static Usuario Usuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                Usuario = (Usuario)Session["Usuario"];
                if (!IsPostBack)
                {
                    txtNome.Value = Usuario.Nome;
                    txtNome.Disabled = true;
                    txtEmail.Value = Usuario.Email;
                    txtEmail.Disabled = true;
                    txtAssunto.Focus();
                }

                // Verifica se o usuário possui chamados respondidos e não validados e exibe um alerta ao usuário:
                List<Chamado> chamados = ChamadoManager.GetChamadosAbertosRespondidos(Usuario);
                if (chamados.Count > 0)
                {
                    lblChamados.Visible = true;
                    lblChamados.Text = chamados.Count.ToString();
                }

                // Carrega o histórico de mensagens do usuário:
                CarregarMensagensUsuario(Usuario);
            }
            else
            {
                if (!IsPostBack)
                {
                    txtNome.Focus();
                }
            }
        }

        protected void CarregarMensagensUsuario(Usuario usuario)
        {
            List<Chamado> chamados = ChamadoManager.GetChamadosPrimarios(usuario);
            if (chamados.Count == 0)
            {
                ExibirHistorico.Controls.Add(new Literal
                {
                    Text = "<div class='card'><div class='card-header text-center'>Não há mensagens enviadas no seu histórico.</div></div>"
                });
                return;
            }
            foreach (Chamado chamado in chamados)
            {
                ExibirHistorico.Controls.Add(CriarDialogoChamado(chamado));
            }
        }

        private Panel CriarDialogoChamado(Chamado chamado)
        {
            Panel body = new Panel
            {
                ID = "id_" + chamado.IdChamado.ToString(),
                ClientIDMode = ClientIDMode.Static,
                CssClass = "collapse card-body"
            };
            body.Attributes["data-parent"] = "#ExibirHistorico";
            body.Attributes["aria-controls"] = "title_" + chamado.IdChamado.ToString();
            AdicionarMensagem(chamado, body);

            HyperLink linkBody = new HyperLink
            {
                ID = "title_" + chamado.IdChamado.ToString(),
                ClientIDMode = ClientIDMode.Static,
                CssClass = "font-weight-bolder",
                NavigateUrl = "#id_" + chamado.IdChamado.ToString(),
                Text = chamado.Titulo,
                ToolTip = chamado.Titulo
            };
            linkBody.Attributes["data-toggle"] = "collapse";
            linkBody.Attributes["aria-expanded"] = "true";
            linkBody.Attributes["aria-controls"] = "id_" + chamado.IdChamado.ToString();

            Literal flagChamado = new Literal();
            switch (ChamadoManager.GetStatusChamado(chamado))
            {
                case ChamadoManager.STATUS_FINALIZADO:
                    flagChamado.Text = "&nbsp;&nbsp;<span class='badge badge-success'>Finalizado</span>";
                    break;
                case ChamadoManager.STATUS_RESPONDIDO:
                    flagChamado.Text = "&nbsp;&nbsp;<span class='blinking badge ml-2'>Respondido</span>";
                    break;
                case ChamadoManager.STATUS_SEM_RESPOSTA:
                    flagChamado.Text = "&nbsp;&nbsp;<span class='badge badge-info ml-2'>Aguardando resposta do suporte</span>";
                    break;
                default:
                    break;
            }
            Panel titulo = new Panel { CssClass = "card-header" };
            titulo.Controls.Add(linkBody);
            titulo.Controls.Add(flagChamado);

            Panel pnlChamado = new Panel { ID = chamado.IdChamado.ToString(), CssClass = "card" };
            pnlChamado.Controls.Add(titulo);
            pnlChamado.Controls.Add(body);

            return pnlChamado;
        }

        private void AdicionarMensagem(Chamado chamado, Panel panel)
        {
            Panel pnlMsg = new Panel { CssClass = "alert alert-primary mr-5" };
            pnlMsg.Controls.Add(new Literal
            {
                Text = "<p><small> - " + Usuario.Nome + " (" + chamado.DataCriacao.ToString(@"dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("pt-BR")) + ")</small></p>" + chamado.Mensagem
            });
            panel.Controls.Add(pnlMsg);

            if (chamado.IdUsuarioSuporte != null)
            {
                Panel pnlResp = new Panel { CssClass = "alert alert-info ml-5" };
                pnlResp.Controls.Add(new Literal
                {
                    Text = "<p><small> - Suporte DOMINUS (" + chamado.DataResposta?.ToString(@"dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("pt-BR")) + ")</small></p>" + chamado.MensagemResposta
                });
                panel.Controls.Add(pnlResp);
            }
            Chamado chamadoAssociado = ChamadoManager.GetChamadoAssociado(chamado);
            if (chamadoAssociado != null)
            {
                AdicionarMensagem(chamadoAssociado, panel);
            }
            else if (chamado.IdUsuarioSuporte != null && chamado.Validado == ChamadoManager.CHAMADO_NAO_VALIDADO)
            {
                Button btnValidar = new Button
                {
                    CssClass = "btn btn-primary mx-2",
                    Text = "Finalizar Conversa",
                    ToolTip = "Finalizar Conversa",
                    OnClientClick = "ignorarForm();",
                    CommandName = "FinalizarChamado",
                    CommandArgument = chamado.IdChamado.ToString()
                };
                btnValidar.Click += GerenciarChamado;

                Literal btnNovaMsg = new Literal
                {
                    Text = "<button type='button' class='btn btn-primary mx-2' title='Escrever nova mensagem' onclick='openModalMsg(\"" + chamado.IdChamado.ToString() + "\");'>Escrever nova mensagem</button>",
                };

                Panel pnl = new Panel();
                pnl.Controls.Add(btnValidar);
                pnl.Controls.Add(btnNovaMsg);
                panel.Controls.Add(pnl);
            }
        }

        protected void GerenciarChamado(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                switch (btn.CommandName)
                {
                    case "FinalizarChamado":
                        if (Guid.TryParse(btn.CommandArgument.ToString(), out Guid idChamado))
                        {
                            Chamado chamado = ChamadoManager.GetChamadoById(idChamado);
                            ChamadoManager.FinalizaChamado(chamado);
                            Page.Response.Redirect(Page.Request.Url.ToString(), false);
                        }
                        break;
                    case "NovaMensagemChamado":
                        if (Guid.TryParse(txtRespChamado.Value.ToString(), out Guid idChamadoAssociado))
                        {
                            Chamado chamadoAssociado = ChamadoManager.GetChamadoById(idChamadoAssociado);

                            if (String.IsNullOrWhiteSpace(txtEnviarNovaMsg.Value) || txtEnviarNovaMsg.Value.Trim().Length > 1000)
                            {
                                lblNovaMsg.Text = "A mensagem deve ser preenchida (até 1000 caracteres).";
                                txtEnviarNovaMsg.Focus();
                                return;
                            }
                            ChamadoManager.AddChamado(new Chamado
                            {
                                IdUsuario = Usuario.IdUsuario,
                                Titulo = chamadoAssociado.Titulo,
                                Mensagem = txtEnviarNovaMsg.Value.Trim(),
                                IdChamadoAssociado = chamadoAssociado.IdChamado
                            });
                            Page.Response.Redirect(Page.Request.Url.ToString(), false);
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                // Limpa a mensagem de alerta, caso haja algum texto:
                lblMsg.Text = String.Empty;
                lblMsg.CssClass = "text-danger";

                // Valida se os campos estão preenchidos:
                if (String.IsNullOrWhiteSpace(txtNome.Value) || txtNome.Value.Trim().Length > 100)
                {
                    lblMsg.Text = "O nome deve ser preenchido (até 100 caracteres).";
                    txtNome.Focus();
                    return;
                }
                if (String.IsNullOrWhiteSpace(txtEmail.Value) || txtEmail.Value.Trim().Length > 100 || !UsuarioManager.ValidarEmail(txtEmail.Value))
                {
                    lblMsg.Text = "O e-mail deve ser preenchido (até 100 caracteres).";
                    txtEmail.Focus();
                    return;
                }
                // Valida se os campos estão preenchidos:
                if (String.IsNullOrWhiteSpace(txtNome.Value) || txtNome.Value.Trim().Length > 100)
                {
                    lblMsg.Text = "O nome deve ser preenchido (até 100 caracteres).";
                    txtNome.Focus();
                    return;
                }
                if (String.IsNullOrWhiteSpace(txtEmail.Value) || txtEmail.Value.Trim().Length > 100 || !UsuarioManager.ValidarEmail(txtEmail.Value))
                {
                    lblMsg.Text = "O e-mail deve ser preenchido (até 100 caracteres).";
                    txtEmail.Focus();
                    return;
                }
                if (String.IsNullOrWhiteSpace(txtAssunto.Value) || txtAssunto.Value.Trim().Length > 50)
                {
                    lblMsg.Text = "O assunto deve ser preenchido (até 50 caracteres).";
                    txtAssunto.Focus();
                    return;
                }
                if (String.IsNullOrWhiteSpace(txtMensagem.Value) || txtMensagem.Value.Trim().Length > 1000)
                {
                    lblMsg.Text = "A mensagem deve ser preenchida (até 1000 caracteres).";
                    txtMensagem.Focus();
                    return;
                }

                // Adiciona um chamado, caso o usuário esteja logado:
                if (Usuario != null)
                {
                    Chamado chamado = new Chamado
                    {
                        IdUsuario = Usuario.IdUsuario,
                        Titulo = txtAssunto.Value.Trim(),
                        Mensagem = txtMensagem.Value.Trim()
                    };
                    ChamadoManager.AddChamado(chamado);
                    Page.Response.Redirect(Page.Request.Url.ToString(), false);
                }
                else
                {
                    // Envia a mensagem de contato para a conta de e-mail do administrador do sistema:
                    ChamadoManager.EnviarMensagemContato(txtNome.Value.Trim(), txtEmail.Value.Trim(), txtAssunto.Value.Trim(), txtMensagem.Value.Trim());
                    lblMsg.Text = "Sua mensagem foi enviada com sucesso.";
                    lblMsg.CssClass = "text-success";
                }
            }
            catch (Exception ex)
            {
                switch (ex.GetType().Name)
                {
                    case "ChamadoUsuarioException":
                        txtNome.Focus();
                        break;
                    case "ChamadoTituloException":
                        txtAssunto.Focus();
                        break;
                    case "ChamadoMensagemException":
                        txtMensagem.Focus();
                        break;
                    default:
                        throw ex;
                }
                lblMsg.Text = ex.Message;
            }
        }
    }
}