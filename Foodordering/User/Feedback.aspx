<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="Foodordering.User.Feedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        /*For disappearing alert message*/
        window.onload = function () {
            var seconds = 5;
            setTimeout(function () {
                document.getElementById("<%=lblMsg.ClientID %>").styple.display = "none";
             }, seconds * 1000);
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="book_section layout_padding">
        <div class="container">
            <div class="heading_container">
                <div class="align-self-end">
                    <asp:Label runat="server" ID="lblMsg"></asp:Label>
                </div>
                <h2>User Feedback</h2>
            </div>
            <div class="row">
                    <div class="form_container">
                        <div>
                             <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="Enter UserName"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ErrorMessage="UserName is required" ControlToValidate="txtUserName"
                                  ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <asp:HiddenField ID="hdnId" runat="server" Value="0" />
                        </div>
                        <div>
                             <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter Email" TextMode="Email"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Email is required" ControlToValidate="txtEmail"
                                 ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        </div>
                        <div>
                             <asp:TextBox ID="txtSubject" runat="server" CssClass="form-control" placeholder="Enter Subject"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Subject is required" ControlToValidate="txtSubject"
                                 ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        </div>
                        <div>
                             <asp:TextBox ID="txtFeedback" runat="server" CssClass="form-control" placeholder="Enter Feedback" TextMode="MultiLine" ></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Feedback is required" ControlToValidate="txtFeedback"
                                 ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        </div>
                        <div class="btn_box">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-warning rounded-pill pl-4 pr-4 text-white" 
                                Onclick="btnSubmit_Click" />
                            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-warning rounded-pill pl-4 pr-4 text-white" CauseValidation="false" onclick="btnClear_Click"/>
                                                </div>
                        </div>
                    </div>
                </div>
        
    </section>
</asp:Content>
