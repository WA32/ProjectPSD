﻿using ProjectPSD.Model;
using ProjectPSD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.View
{
    public partial class ViewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int role = Int32.Parse(Session["roleId"].ToString());
            if (Session["name"] == null) { Response.Redirect("Login.aspx"); }
            else if (role == 2 || role == 3) { Response.Redirect("Home.aspx"); }
            if (!Page.IsPostBack)
            {
                List<Users> listUsers = UserRepository.getUsers();
                gridUser.DataSource = listUsers;
                gridUser.DataBind();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void btnToggleRole_Click(object sender, EventArgs e)
        {
            int userId = toInt(txtUserId.Text);

            if (userId.Equals(0))
            {
                labErr.Text = "User ID must be filled";
            }
            else
            {
                if (userId.Equals(Session["userId"]))
                {
                    labErr.Text = "Cannot change your own data";
                }
                else
                {
                    UserRepository.toggleRole(userId);
                    Response.Redirect("ViewUser.aspx");
                }
            }
        }

        protected void btnToggleStatus_Click(object sender, EventArgs e)
        {
            int userId = toInt(txtUserId.Text);

            if (userId.Equals(0))
            {
                labErr.Text = "User ID must be filled";
            }
            else
            {
                if (userId.Equals(Session["userId"]))
                {
                    labErr.Text = "Cannot change your own data";
                }
                else
                {
                    UserRepository.toggleStatus(userId);
                    Response.Redirect("ViewUser.aspx");
                }
            }
        }

        protected int toInt(String s)
        {
            int number;
            bool isParsable = Int32.TryParse(s, out number);
            if (isParsable)
                return (number);
            else
                return (0);
        }
    }
}