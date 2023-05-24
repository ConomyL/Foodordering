<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Foodordering.User.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <!-- about section -->
  <section class="about_section layout_padding">
    <div class="container  ">
      <div class="row">
        <div class="col-md-6 ">
          <div class="img-box">
            <img src="../TemplateFiles/images/img4.jpg" alt="">
          </div>
        </div>
        <div class="col-md-6">
          <div class="detail-box">
            <div class="heading_container">
              <h2>
                Welcome to EatWhat website!
              </h2>
            </div>
            <p>
              This website aims to provide UTS cafeteria food ordering services in the UTS cafeteria to UTS students, lecturers, and staff. The booking is only for <b>TAKING AWAY</b>. 
              In the UTS cafeteria, 5 stalls are being provided.
              Kindly remind that the sequence of stalls is counted from the front door of the cafeteria to the end of the cafeteria. 
            </p>
            <h4>
                Operation hours
            </h4>
              <p>
                  We usually closes at 3pm, but stalls close by 3pm if the food has run out.
          </div>
        </div>
      </div>
    </div>
  </section>
  <!-- end about section -->
</asp:Content>
