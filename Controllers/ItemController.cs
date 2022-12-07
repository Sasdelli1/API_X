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
    public class ItemController : ControllerBase
    {
        string ChaveConexao = "Data Source=10.39.45.44;Initial Catalog=Senac2022;Persist Security Info=True;User ID=Turma2022;Password=Turma2022@2022";
        [HttpGet]
        public string List_Item(string p_Item)
        {
            DataSet resultadoItem = new DataSet();

            {
                SqlConnection Conexao = new SqlConnection(ChaveConexao);
                Conexao.Open();
                string wQuery = $"select * from Item where Name like '%{p_Item}%'";
                SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
                adapter.Fill(resultadoItem);

                string json = JsonConvert.SerializeObject(resultadoItem, Formatting.Indented);
                return json;
            }
        }
    }
}
