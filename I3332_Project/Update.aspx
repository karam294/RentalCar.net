<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="I3332_Project.Update" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Car</title>
    <!-- Bootstrap 5 CDN -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #f8f9fa;
        }
        .form-container {
            max-width: 600px;
            margin: 50px auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container form-container">
            <div class="card shadow-sm">
                <div class="card-header bg-primary text-white">
                    <h4 class="mb-0">Edit Car</h4>
                </div>
                <div class="card-body">
                    <asp:HiddenField ID="hfCarId" runat="server" />

                    <div class="mb-3">
                        <asp:Label runat="server" AssociatedControlID="txtBrand" CssClass="form-label" Text="Brand:" />
                        <asp:TextBox ID="txtBrand" runat="server" CssClass="form-control" />
                    </div>

                    <div class="mb-3">
                        <asp:Label runat="server" AssociatedControlID="txtModel" CssClass="form-label" Text="Model:" />
                        <asp:TextBox ID="txtModel" runat="server" CssClass="form-control" />
                    </div>

                    <div class="mb-3">
                        <asp:Label runat="server" AssociatedControlID="txtType" CssClass="form-label" Text="Type:" />
                        <asp:TextBox ID="txtType" runat="server" CssClass="form-control" />
                    </div>

                    <div class="mb-3">
                        <asp:Label runat="server" AssociatedControlID="txtPricePerDay" CssClass="form-label" Text="Price per Day:" />
                        <asp:TextBox ID="txtPricePerDay" runat="server" CssClass="form-control" />
                    </div>

                    <div class="mb-3">
                        <asp:Label runat="server" AssociatedControlID="txtImagePath" CssClass="form-label" Text="Image Path:" />
                        <asp:TextBox ID="txtImagePath" runat="server" CssClass="form-control" />
                    </div>

                    <div class="form-check mb-3">
                        <asp:CheckBox ID="chkAvailable" runat="server" CssClass="form-check-input" />
                        <asp:Label runat="server" AssociatedControlID="chkAvailable" Text="Available?" CssClass="form-check-label" />
                    </div>

                    <div class="d-grid gap-2">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update Car" OnClick="btnUpdate_Click" CssClass="btn btn-success" />
                    </div>

                    <div class="mt-3">
                        <asp:Label ID="lblMessage" runat="server" CssClass="form-text text-danger" />
                    </div>
                  <div>
                      <asp:Button ID="return" runat="server" CssClass="btn btn-primary" Text="Back" OnClick="Back" />
                  </div>
                </div>
            </div>
        </div>
    </form>

    <!-- Bootstrap 5 JS (optional for interactivity) -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
