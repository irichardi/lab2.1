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
    public partial class student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //checks to add or not if page not post back.
            if (!IsPostBack)
            {
                //gets url if it has something
                if (Request.QueryString.Keys.Count > 0)
                {
                    GetStudent();
                }
            }
        }
        //function that gets students
        protected void GetStudent()
        {
            //connection to db from string
            using (defaultconn conn = new defaultconn())
            {
                //gets id from url parameter and stores it
                Int32 StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                //gets query
                var s = (from stu in conn.Students where stu.StudentID == StudentID select stu)
                    .FirstOrDefault();

                //adds to form the query
                txtStuID.Text = s.StudentID.ToString();
                txtName.Text = s.FirstMidName.ToString();
                txtlName.Text = s.LastName.ToString();
            }
        }
        //when user clicks button
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //connection to db from string
            using (defaultconn conn = new defaultconn())
            {
                //creates new student object
                Student s = new Student();

                //checks if it has something for updating
                if (Request.QueryString.Count > 0)
                {
                    Int32 StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                    s = (from stu in conn.Students where stu.StudentID == StudentID select stu)
                        .FirstOrDefault();
                }

                //adds values from our fields
                s.FirstMidName = txtName.Text;
                s.LastName = txtlName.Text;
                s.StudentID = Convert.ToInt32(txtStuID.Text);

                //adds to file if not updating
                if (Request.QueryString.Count == 0)
                {
                    conn.Students.Add(s);
                }

                //saves the work
                conn.SaveChanges();

                //sends user back to students table
                Response.Redirect("students.aspx");
            }
        }
    }
}