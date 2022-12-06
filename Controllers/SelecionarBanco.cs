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
    public class SelecionarBanco : ControllerBase
    {
        string ChaveConexao = "Data Source=10.39.45.44;Initial Catalog=Gabriel;Persist Security Info=True;User ID=Turma2022;Password=Turma2022@2022";
        [HttpGet]
        public string List_Cliente(string p_Nome)
        {
            DataSet resultadoNome = new DataSet();

            {
                SqlConnection Conexao = new SqlConnection(ChaveConexao);
                Conexao.Open();
                string wQuery = $"select * from Clientes where NomeCompleto like '%{p_Nome}%'";
                SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
                adapter.Fill(resultadoNome);

                string json = JsonConvert.SerializeObject(resultadoNome, Formatting.Indented);
                return json;
            }
        }
    }
}
