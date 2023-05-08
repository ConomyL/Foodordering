<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Foodordering.User.Default" %>
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
                Welcome to EatWhat website
              </h2>
            </div>
            <p>
              This website aims to provide food ordering service of UTS cafeteria to UTS students, lecturers and staffs. 
              
              In UTS cafeteria, there are 5 stalls being provided.
              Kindly remind that the sequence of stalls is counting from the front door of the cafeteria to the end of the cafeteria
            </p>

            <h4>
                Operation hours
            </h4>

              <p>
                  We usually closes at 3pm, but stall close by 3pm if the food has run out.
            
          </div>
        </div>
      </div>
    </div>
  </section>

  <!-- end about section -->

     <!-- food section -->

  <section class="food_section layout_padding">
    <div class="container">
      <div class="heading_container heading_center">
          <div class="align-self-end">
              <asp:Label ID="lblMsg" runat="server" Text="Label" Visible="false" ></asp:Label>
          </div>
        <h2>
          Our Menu
        </h2>
      </div>

      <ul class="filters_menu">
        <li class="active" data-filter="*" data-id="0">All</li>
          <asp:Repeater ID="rCategory" runat="server" >
              <ItemTemplate>
                  <li data-filter=".<%# Regex.Replace(Eval("Name").ToString().ToLower(),@"\s+", "") %>" data-id="<%# Eval("CategoryId") %>"><%# Eval("Name") %></li>
              </ItemTemplate>
          </asp:Repeater>       
      </ul>

      <div class="filters-content">
        <div class="row grid">
            <asp:Repeater ID="rProduct" runat="server" OnItemCommand="rProduct_ItemCommand">
                <ItemTemplate>
                    <div class="col-sm-6 col-lg-4 all <%# Regex.Replace(Eval("CategoryName").ToString().ToLower(),@"\s+", "") %>">
            <div class="box">
              <div>
                <div class="img-box">
                  <img src="<%# Foodordering.Utils.GetImageUrl( Eval("ImageUrl")) %>" alt="">
                </div>
                <div class="detail-box">
                  <h5>
                    <%# Eval("Name") %>
                  </h5>
                  <p>
                     <%# Eval("Description") %>
                  </p>
                  <div class="options">
                    <h6>
                       RM<%# Eval("Price") %>
                    </h6>
                    <asp:LinkButton runat="server" ID="lbAddToCart" CommandName="addToCart" CommandArgument='<%# Eval("ProductId") %>'>
                      <svg version="1.1" id="Capa_1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" viewBox="0 0 456.029 456.029" style="enable-background:new 0 0 456.029 456.029;" xml:space="preserve">
                        <g>
                          <g>
                            <path d="M345.6,338.862c-29.184,0-53.248,23.552-53.248,53.248c0,29.184,23.552,53.248,53.248,53.248
                         c29.184,0,53.248-23.552,53.248-53.248C398.336,362.926,374.784,338.862,345.6,338.862z" />
                          </g>
                        </g>
                        <g>
                          <g>
                            <path d="M439.296,84.91c-1.024,0-2.56-0.512-4.096-0.512H112.64l-5.12-34.304C104.448,27.566,84.992,10.67,61.952,10.67H20.48
                         C9.216,10.67,0,19.886,0,31.15c0,11.264,9.216,20.48,20.48,20.48h41.472c2.56,0,4.608,2.048,5.12,4.608l31.744,216.064
                         c4.096,27.136,27.648,47.616,55.296,47.616h212.992c26.624,0,49.664-18.944,55.296-45.056l33.28-166.4
                         C457.728,97.71,450.56,86.958,439.296,84.91z" />
                          </g>
                        </g>
                        <g>
                          <g>
                            <path d="M215.04,389.55c-1.024-28.16-24.576-50.688-52.736-50.688c-29.696,1.536-52.224,26.112-51.2,55.296
                         c1.024,28.16,24.064,50.688,52.224,50.688h1.024C193.536,443.31,216.576,418.734,215.04,389.55z" />
                          </g>
                        </g>
                        <g>
                        </g>
                        <g>
                        </g>
                        <g>
                        </g>
                        <g>
                        </g>
                        <g>
                        </g>
                        <g>
                        </g>
                        <g>
                        </g>
                        <g>
                        </g>
                        <g>
                        </g>
                        <g>
                        </g>
                        <g>
                        </g>
                        <g>
                        </g>
                        <g>
                        </g>
                        <g>
                        </g>
                        <g>
                        </g>
                      </svg>
                    </asp:LinkButton>
                  </div>
                </div>
              </div>
            </div>
          </div>
                </ItemTemplate>
            </asp:Repeater>
          

        </div>
      </div>
     
    </div>
  </section>

  <!-- end food section -->

      <!-- book section -->
  <section class="book_section layout_padding">
    <div class="container">
      <div class="heading_container">
        <h2>
          Send Your Query
        </h2>
      </div>
      <div class="row">
        <div class="col-md-6">
          <div class="form_container">
            <form action="">
              <div>
                <input type="text" class="form-control" placeholder="Your Name" />
              </div>
              <div>
                <input type="text" class="form-control" placeholder="Phone Number" />
              </div>
              <div>
                <input type="email" class="form-control" placeholder="Subject" />
              </div>
              <div>
                <textarea id="text" class="form-control" placeholder="Enter Your Feedback" name="text" rows="4" cols="50" required></textarea><br><br>
              </div>
              <div class="btn_box">
                <button>
                  Submit
                </button>
              </div>
            </form>
          </div>
        </div>
        <div class="col-md-6">
          <div class="map_container ">
            <div id="googleMap"></div>
          </div>
        </div>
      </div>
    </div>
  </section>
  <!-- end book section -->


</asp:Content>
