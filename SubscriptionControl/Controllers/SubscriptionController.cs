using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubscriptionControl.Data;
using SubscriptionControl.Models;

namespace SubscriptionControl.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly SubscriptionDB _subs;

        public SubscriptionController(SubscriptionDB subs)
        {
            _subs = subs;
        }

        //Mostrando todos os itens
        
        public async Task<IActionResult> Index()
        {
            var subs = await _subs.Subscriptions.ToListAsync();
            return View(subs);
        }

        //Mostrando os Detalhes
        public async Task<IActionResult> Details(int id)
        {
            if (_subs.Subscriptions == null)
            {
                return NotFound();
            }

            var subs = await _subs.Subscriptions.FirstOrDefaultAsync();

            if (subs == null)
            {
                return NotFound();
            }
            return View(subs);
        }

        //Novo
        [Route("novo")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("novo")]
        public async Task<IActionResult> Create(Subscription subs)
        {
            if (ModelState.IsValid) // Apenas se o modelo for válido
            {
                // Adiciona 30 dias à data de início
                subs.DateExpiration = subs.StartSubscription.Date.AddDays(30);

                // Adiciona o objeto ao banco de dados
                _subs.Subscriptions.Add(subs);
                await _subs.SaveChangesAsync();

                // Redireciona para o índice após salvar
                return RedirectToAction("Index");
            }

            // Se o modelo for inválido, retorna à view "Create" com o modelo atual
            return View(subs);
        }


        // Método GET: Exibe o formulário de edição
        public async Task<IActionResult> Edit(int id)
        {
            if (_subs.Subscriptions == null)
            {
                return NotFound();
            }
            var subs = await _subs.Subscriptions.FindAsync(id);

            if (subs == null)
            {
                return NotFound();
            }
            return View(subs);
        }

        // Método POST: Processa a edição e salva as alterações

        public async Task<IActionResult> Edit(int id, Subscription subs)
        {
            if (id != subs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _subs.Subscriptions.Update(subs);
                    await _subs.SaveChangesAsync();

                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!SubscriptionExists(subs.Id))
                    {
                        return NotFound();
                    }
                    else throw;
                }

            }
            return View(subs);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (_subs.Subscriptions == null)
            {
                return NotFound();
            }
            var subs = await _subs.Subscriptions.FirstOrDefaultAsync(subs => subs.Id == id);

            if (subs == null)
            {
                return NotFound();
            }
            return View(subs);
        }

        //POST
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subs = await _subs.Subscriptions.FindAsync(id);
            if (subs != null)
            {
                _subs.Subscriptions.Remove(subs);
            }
            await _subs.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubscriptionExists(int id)
        {
            return _subs.Subscriptions.Any(_subs => _subs.Id == id);

        }


    }
}




