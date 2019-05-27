using AcessaDados;
using MetaProcessoSeletivo.AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Repositorio;
using AutoMapper;
using Modelo;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Reflection;
using System.ComponentModel;

namespace MetaProcessoSeletivo.Controllers
{
    public class SolicitacaoController : Controller
    {
        private readonly IOptions<ModeloConfiguracao> _appSettings;

        public SolicitacaoController(IOptions<ModeloConfiguracao> options)
        {
            _appSettings = options;



            //carrega o mapemanto
            //     ConfiguraMapper();
        }
        // GET: Solicitacao
        public ActionResult Index()
        {
            try
            {
                using (var uow = UnitOfWorkFactory.Create(_appSettings.Value.ConexaoBanco))
                {
                    RepositorioSolicitacao repositorioSolicitacao = new RepositorioSolicitacao(uow);
                    IEnumerable<Solicitacao> lista = repositorioSolicitacao.ObterTodos();
                    List<SolicitacaoViewModel> retorno = new List<SolicitacaoViewModel>();
                    foreach (var item in lista)
                    {
                        SolicitacaoViewModel sol = new SolicitacaoViewModel
                        {
                            Id = item.Id,
                            Descricao = item.Descricao,
                            DataConclusao = item.DataConclusao,
                            Responsavel = item.Responsavel,
                            Status = item.Status
                        };
                        retorno.Add(sol);
                    }

                    return View(retorno);
                }
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro\n {0}", ex.Message);
                return View();
            }

        }

        // GET: Solicitacao/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                using (var uow = UnitOfWorkFactory.Create(_appSettings.Value.ConexaoBanco))
                {
                    RepositorioSolicitacao repositorioSolicitacao = new RepositorioSolicitacao(uow);
                    Solicitacao solicitacao = repositorioSolicitacao.ObterPorId(id);
                    SolicitacaoViewModel sol = new SolicitacaoViewModel
                    {
                        Id = solicitacao.Id,
                        Descricao = solicitacao.Descricao,
                        DataConclusao = solicitacao.DataConclusao,
                        Responsavel = solicitacao.Responsavel,
                        Status = solicitacao.Status
                    };
                    return View(sol);
                }
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um Erro\n {0}", ex.Message);
                return RedirectToAction(nameof(Index));
            }

        }

        // GET: Solicitacao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Solicitacao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SolicitacaoViewModel solicitacaoViewModel)
        {
            try
            {
                using (var uow = UnitOfWorkFactory.Create(_appSettings.Value.ConexaoBanco))
                {
                    Solicitacao sol = new Solicitacao
                    {
                        Id = solicitacaoViewModel.Id,
                        Descricao = solicitacaoViewModel.Descricao,
                        DataConclusao = solicitacaoViewModel.DataConclusao,
                        Responsavel = solicitacaoViewModel.Responsavel,
                        Status = solicitacaoViewModel.Status
                    };

                    RepositorioSolicitacao repositorioSolicitacao = new RepositorioSolicitacao(uow);
                    repositorioSolicitacao.Inserir(sol);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um Erro {0}", ex.Message);
                return View();
            }
        }

        // GET: Solicitacao/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                using (var uow = UnitOfWorkFactory.Create(_appSettings.Value.ConexaoBanco))
                {
                    RepositorioSolicitacao repositorioSolicitacao = new RepositorioSolicitacao(uow);
                    Solicitacao solicitacao = repositorioSolicitacao.ObterPorId(id);
                    SolicitacaoViewModel sol = new SolicitacaoViewModel
                    {
                        Id = solicitacao.Id,
                        Descricao = solicitacao.Descricao,
                        DataConclusao = solicitacao.DataConclusao,
                        Responsavel = solicitacao.Responsavel,
                        Status = solicitacao.Status
                    };
                    return View(sol);
                }
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um Erro\n {0}", ex.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Solicitacao/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SolicitacaoViewModel solicitacaoViewModel)
        {
            try
            {
                using (var uow = UnitOfWorkFactory.Create(_appSettings.Value.ConexaoBanco))
                {
                    Solicitacao sol = new Solicitacao
                    {
                        Id = solicitacaoViewModel.Id,
                        Descricao = solicitacaoViewModel.Descricao,
                        DataConclusao = solicitacaoViewModel.DataConclusao,
                        Responsavel = solicitacaoViewModel.Responsavel,
                        Status = solicitacaoViewModel.Status
                    };

                    RepositorioSolicitacao repositorioSolicitacao = new RepositorioSolicitacao(uow);
                    repositorioSolicitacao.Inserir(sol);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um Erro {0}", ex.Message);
                return View();
            }
        }

        // GET: Solicitacao/Delete/5
        public ActionResult Delete(Int64 id)
        {
            try
            {
                using (var uow = UnitOfWorkFactory.Create(_appSettings.Value.ConexaoBanco))
                {
                    RepositorioSolicitacao repositorioSolicitacao = new RepositorioSolicitacao(uow);
                    Solicitacao solicitacao = repositorioSolicitacao.ObterPorId(id);
                    SolicitacaoViewModel sol = new SolicitacaoViewModel
                    {
                        Id = solicitacao.Id,
                        Descricao = solicitacao.Descricao,
                        DataConclusao = solicitacao.DataConclusao,
                        Responsavel = solicitacao.Responsavel,
                        Status = solicitacao.Status
                    };
                    return View(sol);
                }
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um Erro\n {0}", ex.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Solicitacao/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SolicitacaoViewModel solicitacaoViewModel)
        {
            try
            {
                using (var uow = UnitOfWorkFactory.Create(_appSettings.Value.ConexaoBanco))
                {
                    RepositorioSolicitacao repositorioSolicitacao = new RepositorioSolicitacao(uow);
                    bool retorno = repositorioSolicitacao.Excluir(solicitacaoViewModel.Id);

                    if (retorno)
                    {
                        TempData["mensagem"] = "Registro Removido Com Sucesso!";
                    }
                    else
                    {
                        TempData["mensagem"] = "Não Foi Possivel Remover!";
                    }
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um Erro\n {0}", ex.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        private void ConfiguraMapper()
        {
            AutoMapperConfig.RegistraMapeamento();
        }
    }
}