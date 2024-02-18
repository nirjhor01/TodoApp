using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoWebApp.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace TodoWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TodoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllTodos")]
        public Response GetAllTodos()
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.GetAllTodos(connection);
            return response;
        }
       
        [HttpPost]
        [Route("AddTodo")]
        public Response AddTodo(Todo employee)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.AddTodo(connection, employee);
            return response;
        }
       
      
        [HttpDelete]
        [Route("DeleteTodo/{id}")]
        public Response DeleteTodo(int id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            //SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.DeleteTodo(connection, id);
            return response;

        }

    }
}
