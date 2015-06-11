using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//references to model
using lab2.Model;
using System.Web.ModelBinding;

namespace lab2
{
    public partial class students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //fill the grid once page loads
            if (!IsPostBack)
            {
                GetStudents();
            }
        }
        //gets my students
        protected void GetStudents()
        {
            //database string while using closes connection once done with it.
            using (defaultconn conn = new defaultconn())
            {
                //query the studunts
                var students = from s in conn.Students
                           select s;

                //adds the students from the query
                grdStudent.DataSource = students.ToList();
                grdStudent.DataBind();
            }
        }
        //deletes row from students table
        protected void grdStudent_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //connects to database with string
            using (defaultconn conn = new defaultconn())
            {
                //gets the chosen department based on its index
                Int32 StudentID = Convert.ToInt32(grdStudent.DataKeys[e.RowIndex].Values["StudentID"]);

                //query the results into s for student
                var s = (from stu in conn.Students where stu.StudentID == StudentID select stu)
                    .FirstOrDefault();

                //deletes the students
                conn.Students.Remove(s);
                //saves changes
                conn.SaveChanges();

                //updates the grid
                GetStudents();
            }
        }
    }
}