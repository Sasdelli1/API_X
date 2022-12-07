using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_X.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        string ChaveConexao = "Data Source=10.39.45.44;Initial Catalog=TI_Noite;Persist Security Info=True;User ID=Turma2022;Password=Turma2022@2022";
        [HttpGet]
        public string List_Contato(string p_Contato)
        {
            DataSet resultadoContato = new DataSet();

            {
                SqlConnection Conexao = new SqlConnection(ChaveConexao);
                Conexao.Open();
                string wQuery = $"select * from Contatos where TelephoneNumber like '%{p_Contato}%'";
                SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
                adapter.Fill(resultadoContato);

                string json = JsonConvert.SerializeObject(resultadoContato, Formatting.Indented);
                return json;
            }
        }
    }
}
