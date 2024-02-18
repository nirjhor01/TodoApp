using System.Data;
using System.Data.SqlClient;

namespace TodoWebApp.Models
{
    public class DAL
    {
        public Response GetAllTodos(SqlConnection con)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("Select * from todoTBL", con);
            DataTable dt = new DataTable();
            List<Todo> listtodo = new List<Todo>();

            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for(int i = 0; i < dt.Rows.Count; ++i)
                {
                    Todo todo = new Todo();

                    todo.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    todo.Title = Convert.ToString(dt.Rows[i]["Title"]);
                    todo.Descriptions = Convert.ToString(dt.Rows[i]["Descriptions"]);
                    todo.DueDate = Convert.ToDateTime(dt.Rows[i]["DueDate"]);
                    todo.CurrentDate = Convert.ToDateTime(dt.Rows[i]["CurrentDate"]);
                    todo.isComplete = Convert.ToInt32(dt.Rows[i]["isComplete"]);
                    listtodo.Add(todo);
                }
                
                
                
            }
            if (listtodo.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Found";
                response.listTodo = listtodo;
            }
            else
            {

                response.StatusCode = 100;
                response.StatusMessage = "NotFound";
               
                response.listTodo = null;

            }
            return response;
        }

    

        public Response AddTodo(SqlConnection con, Todo todo)
        {
            Response response = new Response();

            SqlCommand cmd = new SqlCommand("INSERT INTO todoTBL(Title,Descriptions,DueDate,CurrentDate,isComplete)VALUES('" + todo.Title + "','" + todo.Descriptions + "','" + todo.DueDate + "',GETDATE(),'"+todo.isComplete +"' )", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {

                response.StatusCode = 200;
                response.StatusMessage = "ADDED";
                

            }

            else
            {

                response.StatusCode = 100;
                response.StatusMessage = "Not Added";
                response.Todo = todo;

            }
            return response;
        }

       

        public Response DeleteTodo(SqlConnection con, int id)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Delete from todoTBL  WHERE ID = '" + id + "' ", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Todo deleted";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Todo Deleted";
            }

            return response;
        }

    }
}

