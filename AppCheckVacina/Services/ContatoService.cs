using AppCheckVacina.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCheckVacina.Services
{
    public class ContatoService
    {
        FirebaseClient firebase = new FirebaseClient("https://appcheckvacina-default-rtdb.firebaseio.com/");

        public async Task AddContato(int contatoId, string nome, string email, string celular, string febre, string dordecab, string faltadear)
        {
            await firebase.Child("Contatos")
                 .PostAsync(
                 new Contato() { ContatoId = contatoId, Nome = nome, Email = email, Celular = celular, Febre = febre, DordeCab = dordecab, FaltadeAr = faltadear });
        }

        public async Task<List<Contato>> GetContatos()
        {
            return (await firebase
                .Child("Contatos")
                .OnceAsync<Contato>()).Select(item => new Contato
                {
                    Nome = item.Object.Nome,
                    Email = item.Object.Email,
                    Celular = item.Object.Celular,
                    Febre = item.Object.Febre,
                    DordeCab = item.Object.DordeCab,
                    FaltadeAr = item.Object.FaltadeAr,
                    ContatoId = item.Object.ContatoId
                }).ToList();
        }

        public async Task<Contato> GetContato(int contatoId)
        {
            try
            {
                var contato = (await firebase
                    .Child("Contatos")
                    .OnceAsync<Contato>())
                    .Where(a => a.Object.ContatoId == contatoId).FirstOrDefault();

                return await firebase.Child("Contatos")
                    .Child(contato.Key).OnceSingleAsync<Contato>();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
