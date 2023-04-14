<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Foodordering.User.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <script>
         /*For disappearing alert message*/
         window.onload = function () {
             var seconds = 5;
             setTimeout(function () {
                 document.getElementById("<%=lblMsg.ClientID %>").styple.display = "none";
            }; seconds * 1000);
         };
     </script>
    <script>
        function ImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.omload = function (e) {
                    $('#<%=imgUser.ClientID%>').prop('src', e.target.result)
                        .width(200)
                        .height(200);
                };
                reader.readAsDataURL(input.Files[0]);
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>User Registration</h2>
    <section class="book_section layout_padding">
        <div class="container">
            <div class="heading_container">
                <div class="align-self-end">
                    <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form_container">
                             <div>
                                <asp:TextBox ID ="txtUserName" runat="server" CssClass="form-control" placeholder="Enter UserName"
                                    ToolTip="UserName"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="rfvUserName" runat="server" ErrorMessage="UserName is required" ControlToValidate="txtUserName"
                                    ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator>
                            </div>
                            <div>
                                <asp:TextBox ID ="txtEmail" runat="server" CssClass="form-control" placeholder="Enter Email"
                                    ToolTip="Email" TextMode="Email" ></asp:TextBox>
                                <asp:RegularExpressionValidator ID="rfvEmail" runat="server" ErrorMessage="Email is required" ControlToValidate="txtEmail"
                                    ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator> 
                            </div>
                            <div>
                                <asp:TextBox ID ="txtMobile" runat="server" CssClass="form-control" placeholder="Enter Mobile Number"
                                    ToolTip="Mobile Number" TextMode="Phone" ></asp:TextBox>
                                <asp:RegularExpressionValidator ID="rfvMobile" runat="server" ErrorMessage="Mobile Number is required" ControlToValidate="txtMobile"
                                    ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="revMobile" runat="server" ErrorMessage="Mobile number must in digit only"
                                    ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ValidationExpression="^[0-9]{10}$"
                                    ControlToValidate="txtMobile"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form_container">
                            <div>
                                <asp:FileUpload ID="fuUserImage" runat="server" CssClass="form-control" ToolTip="User Image" 
                                onchange="ImagePreview(this);" />
                            </div>
                            <div>
                                <asp:TextBox ID ="txtPassword" runat="server" CssClass="form-control" placeholder="Enter Password"
                                    ToolTip="Password" TextMode="Password" ></asp:TextBox>
                                <asp:RegularExpressionValidator ID="rfvPassword" runat="server" ErrorMessage="Password is required" ControlToValidate="txtMobile"
                                    ControlToValidation="txtPassword" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator>
                            </div>
                            <div>
                                <asp:TextBox ID ="txtConfirmPassword" runat="server" CssClass="form-control" placeholder="Enter Password Again"
                                    ToolTip="Password" TextMode="Password" ></asp:TextBox>
                                <asp:RegularExpressionValidator ID="rfvConfirmPassword" runat="server" ErrorMessage="Password is required" ControlToValidate="txtConfirmPassword"
                                    ControlToValidation="txtConfirmPassword" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="ComparePassword" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="Both password must be same" ForeColor="Red"></asp:CompareValidator>
                            </div>


                        </div>
                    </div>
                </div>

                 <div class="row pl-4">
                     <div class="btn_box">
                         <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-success rounded-pill pl-4 pr-4 text-white" 
                             Onclick="btnRegister_Click"/>
                         <asp:Label ID="lblAlreadyUser" runat="server" CssClass="pl-3 text-black-100"
                             Text="Already registered? <a href='Login.aspx' class='badge badge-info'>Login here..</a>">
                             </asp:Label>
                     </div>
                 </div>
                <div class="row p-5">
                    <div style="align-items:center">
                        <asp:Image ID="imgUser" runat="server" CssClass="img-thumbnail" />
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

